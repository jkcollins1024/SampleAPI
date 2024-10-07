using Dapper;
using MediatR;
using SampleAPI.Domains.Surveys.ViewModels;
using System.Data.SqlClient;

namespace SampleAPI.Domains.Surveys.Queries
{
    public record SurveyResultsQuery(int SurveyId) : IRequest<SurveyResultsViewModel>;

    public class SurveyResultsQueryHandler(IConfiguration configuration) : IRequestHandler<SurveyResultsQuery, SurveyResultsViewModel>
    {
        public async Task<SurveyResultsViewModel> Handle(SurveyResultsQuery query, CancellationToken cancellationToken)
        {
            var sql = @"select s.Id as SurveyId, s.Name, s.Description, AVG(CAST(pr.ResponseValue as decimal)) as AverageScore, 
                        MIN(pr.ResponseValue) as MinScore, MAX(pr.ResponseValue) as MaxScore 
                        from Surveys s
                        left join SurveyParticipants p on p.SurveyId = s.Id
                        left join ParticipantResponses pr on pr.SurveyParticipantId = p.Id
                        where s.Id = @SurveyId
                        group by s.Id, s.Name, s.Description";

            SurveyResultsViewModel? results;
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                results = await connection.QuerySingleOrDefaultAsync<SurveyResultsViewModel>(new CommandDefinition(sql, new { query.SurveyId }, cancellationToken: cancellationToken)) ?? 
                    throw new ArgumentException($"Survey {query.SurveyId} does not exist");

                var questionSql = @"select sq.Id as SurveyQuestionId, sq.Title, sq.Description, AVG(CAST(pr.ResponseValue as decimal)) as AverageScore, 
                                    MIN(pr.ResponseValue) as MinScore, MAX(pr.ResponseValue) as MaxScore 
                                    from SurveyQuestions sq 
                                    left join ParticipantResponses pr on pr.SurveyQuestionId = sq.Id
                                    where sq.SurveyId = @SurveyId
                                    group by sq.Id, sq.Title, sq.Description";

                results.ResultsByQuestion = (await connection.QueryAsync<QuestionResultsViewModel>(new CommandDefinition(questionSql, new { query.SurveyId }, cancellationToken: cancellationToken))).AsList();

                var participantSql = @"select sp.Id as SurveyParticipantId, sp.Name, AVG(CAST(pr.ResponseValue as decimal)) as AverageScore, 
                                    MIN(pr.ResponseValue) as MinScore, MAX(pr.ResponseValue) as MaxScore 
                                    from SurveyParticipants sp 
                                    left join ParticipantResponses pr on pr.SurveyParticipantId = sp.Id
                                    where sp.SurveyId = @SurveyId
                                    group by sp.Id, sp.Name";

                results.ResultsByParticipant = (await connection.QueryAsync<ParticipantResultsViewModel>(new CommandDefinition(participantSql, new { query.SurveyId }, cancellationToken: cancellationToken))).AsList();
            }

            return results;
        }
    }
}

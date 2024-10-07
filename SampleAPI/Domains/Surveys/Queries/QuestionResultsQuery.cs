using Dapper;
using MediatR;
using SampleAPI.Domains.Surveys.ViewModels;
using System.Data.SqlClient;

namespace SampleAPI.Domains.Surveys.Queries
{
    public record QuestionResultsQuery(int SurveyQuestionId) : IRequest<QuestionResultsViewModel>;

    public class QuestionResultsQueryHandler(IConfiguration configuration) : IRequestHandler<QuestionResultsQuery, QuestionResultsViewModel>
    {
        public async Task<QuestionResultsViewModel> Handle(QuestionResultsQuery query, CancellationToken cancellationToken)
        {
            var questionSql = @"select sq.Id as SurveyQuestionId, sq.Title, sq.Description, AVG(CAST(pr.ResponseValue as decimal)) as AverageScore, 
                                    MIN(pr.ResponseValue) as MinScore, MAX(pr.ResponseValue) as MaxScore 
                                    from SurveyQuestions sq 
                                    left join ParticipantResponses pr on pr.SurveyQuestionId = sq.Id
                                    where sq.Id = @SurveyQuestionId
                                    group by sq.Id, sq.Title, sq.Description";

            QuestionResultsViewModel results;
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                results = await connection.QuerySingleOrDefaultAsync<QuestionResultsViewModel>(new CommandDefinition(questionSql, new { query.SurveyQuestionId }, cancellationToken: cancellationToken)) ??
                    throw new ArgumentException($"Participant {query.SurveyQuestionId} does not exist");
            }

            return results;
        }
    }
}


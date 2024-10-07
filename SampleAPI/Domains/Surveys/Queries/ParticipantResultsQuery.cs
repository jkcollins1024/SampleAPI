using Dapper;
using MediatR;
using SampleAPI.Domains.Surveys.ViewModels;
using System.Data.SqlClient;

namespace SampleAPI.Domains.Surveys.Queries
{
    public record ParticipantResultsQuery(int SurveyParticipantId) : IRequest<ParticipantResultsViewModel>;

    public class ParticipantResultsQueryHandler(IConfiguration configuration) : IRequestHandler<ParticipantResultsQuery, ParticipantResultsViewModel>
    {
        public async Task<ParticipantResultsViewModel> Handle(ParticipantResultsQuery query, CancellationToken cancellationToken)
        {
            var participantSql = @"select sp.Id as SurveyParticipantId, sp.Name, AVG(CAST(pr.ResponseValue as decimal)) as AverageScore, 
                                    MIN(pr.ResponseValue) as MinScore, MAX(pr.ResponseValue) as MaxScore 
                                    from SurveyParticipants sp 
                                    left join ParticipantResponses pr on pr.SurveyParticipantId = sp.Id
                                    where sp.Id = @SurveyParticipantId
                                    group by sp.Id, sp.Name";

            ParticipantResultsViewModel results;
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                results = await connection.QuerySingleOrDefaultAsync<ParticipantResultsViewModel>(new CommandDefinition(participantSql, new { query.SurveyParticipantId }, cancellationToken: cancellationToken)) ??
                    throw new ArgumentException($"Participant {query.SurveyParticipantId} does not exist");
            }

            return results;
        }
    }
}


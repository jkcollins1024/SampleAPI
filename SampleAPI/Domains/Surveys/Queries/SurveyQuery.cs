using Dapper;
using MediatR;
using SampleAPI.Domains.Surveys.ViewModels;
using System.Data.SqlClient;

namespace SampleAPI.Domains.Surveys.Queries
{
    public record SurveyQuery(int SurveyId) : IRequest<SurveyViewModel>;

    public class SurveyQueryHandler(IConfiguration configuration) : IRequestHandler<SurveyQuery, SurveyViewModel>
    {
        public async Task<SurveyViewModel> Handle(SurveyQuery query, CancellationToken cancellationToken)
        {
            var sql = @"select s.Id, s.Name, s.Description
                        from Surveys s
                        where Id = @SurveyId";

            SurveyViewModel survey;
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                survey = await connection.QuerySingleOrDefaultAsync<SurveyViewModel>(new CommandDefinition(sql, new { query.SurveyId }, cancellationToken: cancellationToken)) ??
                    throw new ArgumentException($"Survey {query.SurveyId} does not exist");
            }

            return survey;
        }
    }
}

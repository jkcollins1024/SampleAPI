using Dapper;
using MediatR;
using SampleAPI.Domains.Surveys.ViewModels;
using System.Data.SqlClient;

namespace SampleAPI.Domains.Surveys.Queries
{

    public record SurveyListQuery() : IRequest<IEnumerable<SurveyViewModel>>;

    public class SurveyListQueryHandler(IConfiguration configuration) : IRequestHandler<SurveyListQuery, IEnumerable<SurveyViewModel>>
    {
        public async Task<IEnumerable<SurveyViewModel>> Handle(SurveyListQuery query, CancellationToken cancellationToken)
        {
            var sql = @"select s.Id, s.Name, s.Description from Surveys s";

            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                return await connection.QueryAsync<SurveyViewModel>(new CommandDefinition(sql, cancellationToken: cancellationToken));
            }
        }
    }
}

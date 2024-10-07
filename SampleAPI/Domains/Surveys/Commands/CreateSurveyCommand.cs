using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleAPI.Database;
using SampleAPI.Domains.Surveys.Entities;

namespace SampleAPI.Domains.Surveys.Commands
{
    public record CreateSurveyCommand(string Name, string Description) : IRequest<int>;

    public class CreateSurveyCommandHandler(SampleAPIContext context) : IRequestHandler<CreateSurveyCommand, int>
    {
        public async Task<int> Handle(CreateSurveyCommand command, CancellationToken cancellationToken)
        {
            var now = DateTimeOffset.UtcNow;
            var createUserId = 1; //fake system user for now
            var survey = new Survey(command.Name, command.Description, now, createUserId);
            await context.Surveys.AddAsync(survey, cancellationToken);
            await context.SaveChangesAsync();
            return survey.Id;
        }
    }
}

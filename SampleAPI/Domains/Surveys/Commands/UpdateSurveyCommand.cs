using MediatR;
using SampleAPI.Database;

namespace SampleAPI.Domains.Surveys.Commands
{
    public record UpdateSurveyCommand(int SurveyId, string Name, string Description) : IRequest;

    public class UpdateSurveyCommandHandler(SampleAPIContext context) : IRequestHandler<UpdateSurveyCommand>
    {
        public async Task Handle(UpdateSurveyCommand command, CancellationToken cancellationToken)
        {
            var survey = await context.Surveys.FindAsync(command.SurveyId, cancellationToken);
            if (survey == null)
            {
                throw new ArgumentException($"Survey {command.SurveyId} does not exist");
            }
            var now = DateTimeOffset.UtcNow;
            var updateUserId = 1; //fake system user for now
            survey.Name = command.Name;
            survey.Description = command.Description;
            survey.UpdatedBy = updateUserId;
            survey.UpdatedOn = now;
            await context.SaveChangesAsync();
        }
    }
}

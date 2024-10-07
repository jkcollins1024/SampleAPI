using MediatR;
using SampleAPI.Database;
using SampleAPI.Domains.Surveys.Entities;

namespace SampleAPI.Domains.Surveys.Commands
{
    public record DeleteSurveyCommand(int SurveyId) : IRequest;

    public class DeleteSurveyCommandHandler(SampleAPIContext context) : IRequestHandler<DeleteSurveyCommand>
    {
        public async Task Handle(DeleteSurveyCommand command, CancellationToken cancellationToken)
        {
            var survey = await context.Surveys.FindAsync(command.SurveyId, cancellationToken);
            if (survey == null)
            {
                throw new ArgumentException($"Survey {command.SurveyId} does not exist");
            }
            
            context.Surveys.Remove(survey);
            await context.SaveChangesAsync();
        }
    }
}

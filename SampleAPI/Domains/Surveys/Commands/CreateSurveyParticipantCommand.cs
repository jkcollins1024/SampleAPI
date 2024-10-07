using MediatR;
using SampleAPI.Database;
using SampleAPI.Domains.Surveys.Entities;

namespace SampleAPI.Domains.Surveys.Commands
{
    public record CreateSurveyParticipantCommand(string Name, int SurveyId) : IRequest<int>;

    public class CreateSurveyParticipantCommandHandler(SampleAPIContext context) : IRequestHandler<CreateSurveyParticipantCommand, int>
    {
        public async Task<int> Handle(CreateSurveyParticipantCommand command, CancellationToken cancellationToken)
        {
            var now = DateTimeOffset.UtcNow;
            var createUserId = 1; //fake system user for now
            var participant = new SurveyParticipant(command.Name, now, createUserId);
            var survey = await context.Surveys.FindAsync(command.SurveyId, cancellationToken);
            if (survey == null)
            {
                throw new ArgumentException($"Survey {command.SurveyId} does not exist");
            }

            survey.Participants.Add(participant);
            //await context.SurveyParticipants.AddAsync(participant, cancellationToken);
            await context.SaveChangesAsync();
            return participant.Id;
        }
    }
}

using MediatR;
using SampleAPI.Database;
using SampleAPI.Domains.Surveys.Entities;

namespace SampleAPI.Domains.Surveys.Commands
{
    public record CreateSurveyQuestionCommand(string Title, string Description, int SurveyId) : IRequest<int>;

    public class CreateSurveyQuestionCommandHandler(SampleAPIContext context) : IRequestHandler<CreateSurveyQuestionCommand, int>
    {
        public async Task<int> Handle(CreateSurveyQuestionCommand command, CancellationToken cancellationToken)
        {
            var now = DateTimeOffset.UtcNow;
            var createUserId = 1; //fake system user for now
            var question = new SurveyQuestion(command.Title, command.Description, now, createUserId);
            var survey = await context.Surveys.FindAsync(command.SurveyId, cancellationToken);
            if (survey == null)
            {
                throw new ArgumentException($"Survey {command.SurveyId} does not exist");
            }

            survey.Questions.Add(question);
            await context.SaveChangesAsync();
            //await context.SurveyParticipants.AddAsync(participant, cancellationToken);
            return question.Id;
        }
    }
}

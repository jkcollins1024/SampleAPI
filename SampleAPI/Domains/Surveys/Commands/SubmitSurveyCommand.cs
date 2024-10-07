using MediatR;
using Microsoft.AspNetCore.Server.Kestrel.Core.Features;
using SampleAPI.Database;
using SampleAPI.Domains.Surveys.Entities;

namespace SampleAPI.Domains.Surveys.Commands
{
    //keeping this response data record here as it is only currently used here as part of the submit command - can potentially move elsewhere
    public record ResponseData (int QuestionId, string? ResponseText, int? ResponseValue);
    public record SubmitSurveyCommand (int ParticipantId, List<ResponseData> ResponseData) : IRequest;

    public class SubmitSurveyCommandHandler(SampleAPIContext context) : IRequestHandler<SubmitSurveyCommand>
    {
        public async Task Handle(SubmitSurveyCommand command, CancellationToken cancellationToken)
        {
            var now = DateTimeOffset.UtcNow;
            var createUserId = 1; //fake system user for now

            var participant = await context.SurveyParticipants.FindAsync(command.ParticipantId, cancellationToken);
            if (participant == null)
            {
                throw new ArgumentException($"Participant {command.ParticipantId} does not exist");
            }

            foreach (var responseData in command.ResponseData)
            {
                var response = participant.Responses.FirstOrDefault(r => r.SurveyQuestionId == responseData.QuestionId);
                if (response != null)
                {
                    response.ResponseText = responseData.ResponseText;
                    response.ResponseValue = responseData.ResponseValue;
                }
                else
                {
                    response = new ParticipantResponse(responseData.QuestionId, responseData.ResponseText, responseData.ResponseValue, now, createUserId);
                    participant.Responses.Add(response);
                }
            }
            //await context.SurveyParticipants.AddAsync(participant, cancellationToken);
            await context.SaveChangesAsync();
        }
    }
}

namespace SampleAPI.Domains.Surveys.Entities
{
    public class ParticipantResponse
    {
        public ParticipantResponse() { }
        public ParticipantResponse(int surveyQuestionId, string? responseText, int? responseValue, DateTimeOffset now, int createUserId)
        {
            SurveyQuestionId = surveyQuestionId;
            ResponseText = responseText;
            ResponseValue = responseValue;
            CreatedBy = createUserId;
            UpdatedBy = createUserId;
            CreatedOn = now;
            UpdatedOn = now;
        }
        public int Id { get; set; }
        public string? ResponseText { get; set; }
        public int? ResponseValue { get; set; }
        public int SurveyParticipantId { get; set; }
        public int SurveyQuestionId { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset UpdatedOn { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }

        public SurveyParticipant Participant { get; set; }
        public SurveyQuestion Question { get; set; }
    }
}

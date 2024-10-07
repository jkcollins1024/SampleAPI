namespace SampleAPI.Domains.Surveys.Entities
{
    public class SurveyParticipant
    {
        public SurveyParticipant()
        {
            Responses = new List<ParticipantResponse>();
        }

        public SurveyParticipant(string name, DateTimeOffset now, int createUserId)
        {
            Name = name;
            CreatedBy = createUserId;
            UpdatedBy = createUserId;
            CreatedOn = now;
            UpdatedOn = now;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int SurveyId { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset UpdatedOn { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public Survey Survey { get; set; }
        public List<ParticipantResponse> Responses { get; set; }
    }
}

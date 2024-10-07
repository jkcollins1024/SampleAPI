namespace SampleAPI.Domains.Surveys.Entities
{
    public class Survey
    {
        public Survey()
        {
            Questions = new List<SurveyQuestion>();
            Participants = new List<SurveyParticipant>();
        }

        public Survey(string name, string description, DateTimeOffset now, int createUserId)
        {
            Name = name;
            Description = description;
            CreatedBy = createUserId;
            UpdatedBy = createUserId;
            CreatedOn = now;
            UpdatedOn = now;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset UpdatedOn { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public List<SurveyQuestion> Questions { get; set; }
        public List<SurveyParticipant> Participants { get; set; }
    }
}

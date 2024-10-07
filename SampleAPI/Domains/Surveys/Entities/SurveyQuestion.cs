using System.Xml.Linq;

namespace SampleAPI.Domains.Surveys.Entities
{
    public class SurveyQuestion
    {
        public SurveyQuestion()
        {
            Responses = new List<ParticipantResponse>();
        }

        public SurveyQuestion(string title, string description, DateTimeOffset now, int createUserId)
        {
            Title = title;
            Description = description;
            CreatedBy = createUserId;
            UpdatedBy = createUserId;
            CreatedOn = now;
            UpdatedOn = now;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int SurveyId { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset UpdatedOn { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public Survey Survey { get; set; }
        public List<ParticipantResponse> Responses { get; set; }
    }
}

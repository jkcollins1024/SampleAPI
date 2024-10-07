namespace SampleAPI.Domains.Surveys.ViewModels
{
    public class ParticipantResultsViewModel
    {
        public int SurveyParticipantId { get; set; }
        public string Name { get; set; }
        public float AverageScore { get; set; }
        public int MinScore { get; set; }
        public int MaxScore { get; set; }
    }
}

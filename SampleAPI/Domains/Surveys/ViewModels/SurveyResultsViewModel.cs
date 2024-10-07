namespace SampleAPI.Domains.Surveys.ViewModels
{
    public class SurveyResultsViewModel
    {
        public int SurveyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal AverageScore { get; set; }
        public int MinScore { get; set; }
        public int MaxScore { get; set; }
        public List<QuestionResultsViewModel> ResultsByQuestion { get; set; }
        public List<ParticipantResultsViewModel> ResultsByParticipant { get; set; }
    }
}

namespace SampleAPI.Domains.Surveys.ViewModels
{
    public class QuestionResultsViewModel
    {
        public int SurveyQuestionId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float AverageScore { get; set; }
        public int MinScore { get; set; }
        public int MaxScore { get; set; }

        //can put some more robust results for drilling into - list participantId/score combos if that is neededf
    }
}

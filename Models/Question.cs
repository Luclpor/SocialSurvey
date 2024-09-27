namespace SocialSurvey.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public IEnumerable<SurveyQuestion> SurveyQuestions{ get; set; }
        public IEnumerable<QuestionAnswer> QuestionAnswers { get; set; }
        public IEnumerable<Result> Results { get; set; }
    }

    public class QuestionViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public List<string> Answers { get; set; }
    }
}

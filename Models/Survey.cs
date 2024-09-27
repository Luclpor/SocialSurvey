namespace SocialSurvey.Models
{
    public class Survey
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual IEnumerable<SurveyQuestion> SurveyQuestions { get; set; }
        public IEnumerable<Interview> Interviews { get; set; }
    }

}

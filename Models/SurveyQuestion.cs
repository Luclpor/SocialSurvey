using Microsoft.EntityFrameworkCore;

namespace SocialSurvey.Models
{
    [Index(nameof(QuestionId))]
    public class SurveyQuestion
    {
        public int QuestionId { get; set; }
        public int SurveyId {  get; set; }
        public int Order { get; set; }

        public Survey Survey { get; set; }
        public Question Question { get; set; }
    }
}

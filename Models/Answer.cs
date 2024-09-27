using Microsoft.EntityFrameworkCore;

namespace SocialSurvey.Models
{
    [Index(nameof(Text), IsUnique = true)]
    public class Answer
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public IEnumerable<QuestionAnswer> QuestionAnswers { get; set; }
        public IEnumerable<Result> Results { get; set; }

    }
}

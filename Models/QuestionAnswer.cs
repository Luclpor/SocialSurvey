using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace SocialSurvey.Models
{
    [Index(nameof(AnswerId))]
    public class QuestionAnswer
    {
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }

        public Question Question { get; set; }
        public Answer Answer { get; set; }
    }
}

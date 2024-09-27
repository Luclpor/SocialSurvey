using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace SocialSurvey.Models
{
    [Index(nameof(SurveyId))]
    public class Interview
    {
        public int Id { get; set; }
        public int SurveyId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public IEnumerable<Result> Results { get; set; }
    }
}

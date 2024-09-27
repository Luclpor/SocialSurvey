using SocialSurvey.Models;

namespace SocialSurvey.Repository
{
    public interface IRepositoryContext
    {
        Task<IEnumerable<QuestionViewModel>> GetQuestionsAsync();
        Task<QuestionViewModel> GetQuestionByIDAsync(int id);

        Task<(bool, int, string)> AddResultAsync(int questionId, string[] arrAnswerTexts, int surveyId, int? interviewId = null);
    }
}

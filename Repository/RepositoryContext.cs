using Microsoft.EntityFrameworkCore;
using SocialSurvey.Context;
using SocialSurvey.Models;
using System.Linq;

namespace SocialSurvey.Repository
{
    public class RepositoryContext : IRepositoryContext
    {
        private SurveySocialDbContext _surveyContext;
        public RepositoryContext(SurveySocialDbContext surveyContext) { _surveyContext = surveyContext; }
        public async Task<QuestionViewModel> GetQuestionByIDAsync(int id)
        {
            Question question = await _surveyContext.Questions.Where(q => q.Id == id).Include(q=>q.QuestionAnswers).FirstOrDefaultAsync();
            if (question != null)
            {
                var answerIds = question.QuestionAnswers.Select(qa => qa.AnswerId).ToList();
                var answers = await  _surveyContext.Answers.Where(a => answerIds.Contains(a.Id)).Select(a=>a.Text).ToListAsync();
                return new QuestionViewModel
                {
                    Id = question.Id,
                    Text = question.Text,
                    Answers = answers
                };
            }
                
            return null;

        }

        public async Task<IEnumerable<QuestionViewModel>> GetQuestionsAsync()
        {
            var questionIds = await _surveyContext.Questions.Select(q => q.Id).ToListAsync();
            List<QuestionViewModel> questionViewModels = new List<QuestionViewModel>();
            foreach(var questionId in questionIds)
            {
                var questionViewModel = await GetQuestionByIDAsync(questionId);
                if(questionViewModel != null)
                    questionViewModels.Add(questionViewModel);
            }
            return questionViewModels;
        }

        public async Task<(bool, int, string)> AddResultAsync(int questionId, string[] arrAnswerTexts, int surveyId,int? interviewId = null )
        {
            var surveyQuestions = await _surveyContext.SurveyQuestions.Where(sq => sq.SurveyId == surveyId).Include(sq => sq.Question).OrderBy(sq => sq.Order).ToListAsync();
            if (!surveyQuestions.Any()) return (false, -1,"survey dont found");
            var currentSQ = surveyQuestions.Where(sq => sq.QuestionId == questionId).Select(sq =>new { Question = sq.Question, Order = sq.Order,SurveyId=sq.SurveyId}).FirstOrDefault();
            if(currentSQ == null) return (false, -1, "question dont found");
            int nextQuestionId = surveyQuestions.Skip(currentSQ.Order).Select(sq=>sq.QuestionId).FirstOrDefault(-1);
            Interview interview;  
            if (interviewId == null)
            {
                interview = new Interview
                {
                    SurveyId = currentSQ.SurveyId,
                    StartTime = DateTime.Now
                };
                await _surveyContext.Interviews.AddAsync(interview);
                await _surveyContext.SaveChangesAsync();
            }
            else
            {
                interview  = await _surveyContext.Interviews.FindAsync(interviewId);
                if (interview == null) return (false, -1, "interview dont found");
            }
            if (nextQuestionId == -1)
            {
                interview.EndTime = DateTime.Now;
            }
            var answerIds = await GetAnswerIdsAsync(arrAnswerTexts, questionId);
            if(answerIds == null) return (false, -1, "answers dont found");
            foreach (var answerId in answerIds)
            {
                await _surveyContext.Results.AddAsync(new Result
                {
                    InterviewId = interview.Id,
                    QuestionId = currentSQ.Question.Id,
                    AnswerId = answerId,
                });
            }
            bool successful = await _surveyContext.SaveChangesAsync() > 0;
            return (successful, nextQuestionId,"Result(s) was save successful");
            
        }

        private async Task<IEnumerable<int>> GetAnswerIdsAsync(string[] arrAnswerTexts, int questionId)
        {
            var allAnswersInQuestion = await _surveyContext.QuestionAnswers.Where(qa => qa.QuestionId == questionId).Include(qa => qa.Answer).Select(qa=>qa.Answer).ToListAsync();
            var userAnswerIds = allAnswersInQuestion.Where(a => arrAnswerTexts.Contains(a.Text)).Select(a => a.Id);
            if(userAnswerIds.Count() == arrAnswerTexts.Length) return userAnswerIds.ToList();
            return null;
        }
    }
}

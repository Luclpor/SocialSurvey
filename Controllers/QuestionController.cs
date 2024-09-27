using Microsoft.AspNetCore.Mvc;
using SocialSurvey.Context;
using SocialSurvey.Models;
using SocialSurvey.Repository;

namespace SocialSurvey.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionController : ControllerBase
    {
        private IRepositoryContext _repositoryContext;
        public QuestionController(IRepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetQuestionByIDAsync([FromQuery]int id)
        {
            QuestionViewModel questionVM =await _repositoryContext.GetQuestionByIDAsync(id);
            if(questionVM == null)
            {
                return BadRequest("Survey dont exist");
            }
            return Ok(questionVM);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetQuestionsAsync()
        {
            IEnumerable<QuestionViewModel> questionVM =await _repositoryContext.GetQuestionsAsync();
            if(questionVM.Count() ==0)
            {
                return BadRequest("Surveys dont exist");
            }
            return Ok(questionVM);
        }

        [HttpPost]
        [Route("AddResult")]
        public async Task<IActionResult> AddResultAsync([FromBody]string[] arrAnswerTexts,[FromQuery] int questionId, [FromQuery] int surveyId, [FromQuery]int? interviewId)
        {
            (bool successful,int nextQuestionId,string message) =await _repositoryContext.AddResultAsync(questionId, arrAnswerTexts, surveyId, interviewId);
            if(!successful)
            {
                return BadRequest(message);
            }
            if(nextQuestionId == -1)
            {
                return Ok($"{message}. Dont find nextQuestionId");
            }
            return Ok($"{message}. NextQuestionId:{nextQuestionId}");
            
        }
    }
}

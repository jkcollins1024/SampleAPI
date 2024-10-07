using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleAPI.Domains.Surveys.Commands;
using SampleAPI.Domains.Surveys.Queries;
using SampleAPI.Domains.Surveys.ViewModels;

namespace SampleAPI.Domains.Surveys.Controllers
{
    [Route("api/surveyquestions")]
    [ApiController]
    public class SurveyQuestionsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SurveyQuestionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("results/{id}")]
        public async Task<QuestionResultsViewModel> GetResults(int id)
        {
            return await _mediator.Send(new QuestionResultsQuery(id));
        }

        [HttpPost]
        public async Task<int> Post([FromBody] CreateSurveyQuestionCommand command)
        {
            var surveyQuestionId = await _mediator.Send(command);
            return surveyQuestionId;
        }
    }
}

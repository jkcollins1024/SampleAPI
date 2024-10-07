using MediatR;
using Microsoft.AspNetCore.Mvc;
using SampleAPI.Domains.Surveys.Commands;
using SampleAPI.Domains.Surveys.Entities;
using SampleAPI.Domains.Surveys.Queries;
using SampleAPI.Domains.Surveys.ViewModels;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SampleAPI.Controllers
{
    [Route("api/surveys")]
    [ApiController]
    public class SurveysController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SurveysController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<SurveysController>
        [HttpGet]
        public async Task<IEnumerable<SurveyViewModel>> Get()
        {
            return await _mediator.Send(new SurveyListQuery());
        }

        // GET api/<SurveysController>/5
        [HttpGet("{id}")]
        public async Task<SurveyViewModel> Get(int id)
        {
            return await _mediator.Send(new SurveyQuery(id));
        }

        [HttpGet("results/{id}")]
        public async Task<SurveyResultsViewModel> GetResults(int id)
        {
            return await _mediator.Send(new SurveyResultsQuery(id));
        }

        // POST api/<SurveysController>
        [HttpPost]
        public async Task<int> Post([FromBody] CreateSurveyCommand command)
        {
            var surveyId = await _mediator.Send(command);
            return surveyId;
        }

        // PUT api/<SurveysController>/5
        [HttpPut]
        public async Task Put([FromBody] UpdateSurveyCommand command)
        {
            await _mediator.Send(command);
        }

        // DELETE api/<SurveysController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _mediator.Send(new DeleteSurveyCommand(id));
        }
    }
}

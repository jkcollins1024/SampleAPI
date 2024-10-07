using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleAPI.Domains.Surveys.Commands;
using SampleAPI.Domains.Surveys.Queries;
using SampleAPI.Domains.Surveys.ViewModels;

namespace SampleAPI.Domains.Surveys.Controllers
{
    [Route("api/surveyparticipants")]
    [ApiController]
    public class SurveyParticipantsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SurveyParticipantsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("results/{id}")]
        public async Task<ParticipantResultsViewModel> GetResults(int id)
        {
            return await _mediator.Send(new ParticipantResultsQuery(id));
        }

        [HttpPost]
        public async Task<int> Post([FromBody] CreateSurveyParticipantCommand command)
        {
            var surveyQuestionId = await _mediator.Send(command);
            return surveyQuestionId;
        }
    }
}

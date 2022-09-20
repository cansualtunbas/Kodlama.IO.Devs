using Application.Features.Technologies.Commands.CreateTechnology;
using Application.Features.Technologies.Commands.DeleteTechnology;
using Application.Features.Technologies.Commands.UpdateTechnology;
using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Models;
using Application.Features.Technologies.Queries.GetByIdTechnology;
using Application.Features.Technologies.Queries.GetListTechnology;
using Core.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologyController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateTechnologyCommand createSomeFeatureEntityCommand)
        {
            CreatedTechnologyEntityDto result = await Mediator.Send(createSomeFeatureEntityCommand);
            return Created("", result);
        }
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListTechnologyQuery getListTechnologyQuery= new() { PageRequest = pageRequest };

            TechnologyListModel result= await Mediator.Send(getListTechnologyQuery);
            return Ok(result);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdTechnologyQuery getByIdTechnologyQuery)
        {
            TechnologyGetByIdDto technologyGetByIdDto= await Mediator.Send(getByIdTechnologyQuery);
            return Ok(technologyGetByIdDto);
        }

        [HttpPost("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteTechnologyCommand deleteSomeFeatureEntityCommand)
        {
            DeletedTechnologyEntityDto result = await Mediator.Send(deleteSomeFeatureEntityCommand);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTechnologyCommand updateSomeFeatureEntityCommand)
        {
            UpdatedTechnologyEntityDto result = await Mediator.Send(updateSomeFeatureEntityCommand);
            return Accepted("", result);
        }
    }
}

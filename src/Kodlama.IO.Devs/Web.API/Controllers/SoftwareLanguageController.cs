using Application.Features.SoftwareLanguages.Commands.CreateSoftwareLanguage;
using Application.Features.SoftwareLanguages.Commands.DeleteSoftwareLanguage;
using Application.Features.SoftwareLanguages.Commands.UpdateSoftwareLanguage;
using Application.Features.SoftwareLanguages.Dtos;
using Application.Features.SoftwareLanguages.Models;
using Application.Features.SoftwareLanguages.Queries.GetByIdSoftwareLanguage;
using Application.Features.SoftwareLanguages.Queries.GetListSoftwareLanguage;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoftwareLanguageController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateSoftwareLanguageCommand createSomeFeatureEntityCommand)
        {
            CreatedSoftwareLanguageEntityDto result = await Mediator.Send(createSomeFeatureEntityCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListSoftwareLanguageQuery getListBrandQuery = new() { PageRequest = pageRequest };
            SoftwareLanguageListModel result = await Mediator.Send(getListBrandQuery);
            return Ok(result);

        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdSoftwareLanguageQuery getByIdSoftwareLanguageQuery)
        {
            SoftwareLanguageGetByIdDto softwareLanguageGetByIdDto = await Mediator.Send(getByIdSoftwareLanguageQuery);
            return Ok(softwareLanguageGetByIdDto);
        }

        [HttpPost("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteSoftwareLanguageCommand deleteSomeFeatureEntityCommand)
        {
            DeletedSoftwareLanguageEntityDto result = await Mediator.Send(deleteSomeFeatureEntityCommand);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSoftwareLanguageCommand updateSomeFeatureEntityCommand)
        {
            UpdatedSoftwareLanguageEntityDto result = await Mediator.Send(updateSomeFeatureEntityCommand);
            return Accepted("", result);
        }
    }
}

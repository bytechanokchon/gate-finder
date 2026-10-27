using GateFinderAPI.DTOs.Bases;
using GateFinderAPI.DTOs.Requests;
using GateFinderAPI.DTOs.Responses;
using GateFinderAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GateFinderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GateController : ControllerBase
    {
        private readonly IGateService _gateService;

        public GateController(IGateService gateService)
        {
            this._gateService = gateService;
        }

        [HttpGet("HealthCheckup")]
        public IActionResult GetHealthCheckup()
        {
            return Ok(new BaseResponseDto<object>(true, "Successful", null));
        }

        [HttpPost("Search")]
        public IActionResult SearchGate([FromBody] List<SearchGateRequestDto> dtos)
        {
            List<SearchGateResponseDto> responses = new List<SearchGateResponseDto>();

            foreach (var dto in dtos)
            {
                string? gate = _gateService.SearchGate(dto.ProductAddress);
                responses.Add(new SearchGateResponseDto(dto.ProductId, dto.ProductAddress, gate));
            }

            return Ok(new BaseResponseDto<object>(true, "Successful", responses));
        }
    }
}

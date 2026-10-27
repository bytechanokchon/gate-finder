using GateFinderAPI.DTOs.Bases;
using GateFinderAPI.DTOs.Requests;
using GateFinderAPI.DTOs.Services;
using GateFinderAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GateFinderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OcrController : ControllerBase
    {
        private readonly IOcrService _ocrService;

        public OcrController(IOcrService ocrService)
        {
            this._ocrService = ocrService;
        }

        [HttpGet("HealthCheckup")]
        public IActionResult GetHealthCheckup()
        {
            return Ok(new BaseResponseDto<object>(true, "Successful", null));
        }

        [HttpPost("Extract")]
        public async Task<IActionResult> Extract([FromForm] List<IFormFile> images)
        {
            List<List<ExtractDataResponseDto>> responses = new List<List<ExtractDataResponseDto>>();

            foreach (var image in images)
            {
                await using var stream = new MemoryStream();
                await image.CopyToAsync(stream);

                byte[] imageBytes = stream.ToArray();
                List<ExtractDataDto> extractDataDtos = _ocrService.Extract(imageBytes);

                List<ExtractDataResponseDto> extractDataResponseDtos = new List<ExtractDataResponseDto>();
                foreach (var extractDataDto in extractDataDtos)
                {
                    extractDataResponseDtos.Add(new ExtractDataResponseDto(extractDataDto.Title.Trim(), extractDataDto.Value.ToString().Trim()));
                }

                responses.Add(extractDataResponseDtos);
            }

            return Ok(new BaseResponseDto<List<List<ExtractDataResponseDto>>>(true, "Successful", responses));
        }
    }
}

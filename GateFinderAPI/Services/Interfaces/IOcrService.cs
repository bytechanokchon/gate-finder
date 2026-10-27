using GateFinderAPI.DTOs.Services;

namespace GateFinderAPI.Services.Interfaces
{
    public interface IOcrService
    {
        List<ExtractDataDto> Extract(byte[] imageByte);
    }
}

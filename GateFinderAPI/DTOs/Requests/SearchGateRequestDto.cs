namespace GateFinderAPI.DTOs.Requests
{
    public class SearchGateRequestDto
    {
        public required string ProductId { get; set; }
        public required string ProductAddress { get; set; }
    }
}

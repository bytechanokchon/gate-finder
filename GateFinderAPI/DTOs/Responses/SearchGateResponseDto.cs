namespace GateFinderAPI.DTOs.Responses
{
    public class SearchGateResponseDto
    {
        public SearchGateResponseDto(string productId, string productAddress, string? gate)
        {
            ProductId = productId;
            ProductAddress = productAddress;
            Gate = gate;
        }

        public string ProductId { get; set; }
        public string ProductAddress { get; set; }
        public string? Gate { get; set; }
    }
}

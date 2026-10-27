namespace GateFinderAPI.DTOs.Requests
{
    public class ExtractDataResponseDto
    {
        public ExtractDataResponseDto(string title, string value)
        {
            this.Title = title;
            this.Value = value;
        }

        public string Title { get; set; }
        public string Value { get; set; }
    }
}

using System.Text;

namespace GateFinderAPI.DTOs.Services
{
    public class ExtractDataDto
    {
        public required string Title { get; set; }
        public required StringBuilder Value  { get; set; }
    }
}

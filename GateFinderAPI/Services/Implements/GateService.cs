using GateFinderAPI.Services.Interfaces;

namespace GateFinderAPI.Services.Implements
{
    public class GateService : IGateService
    {
        public string? SearchGate(string address)
        {
            if (address.Contains("เชียงใหม่")) return "A20";
            if (address.Contains("เชียงราย")) return "A21";
            if (address.Contains("ลําปาง")) return "A22";

            if (address.Contains("พระนครศรีอยุธยา")) return "B40";
            if (address.Contains("จังหวัดนครปฐม")) return "B41";
            if (address.Contains("จังหวัดลพบุรี")) return "B42";

            if (address.Contains("นครราชสีมา")) return "C60";
            if (address.Contains("ขอนแก่น")) return "C61";
            if (address.Contains("อุบลราชธานี")) return "C62";

            if (address.Contains("สุราษฎร์ธานี")) return "D80";
            if (address.Contains("นครศรีธรรมราช")) return "D81";
            if (address.Contains("สงขลา")) return "D82";

            return null;
        }
    }
}

using GateFinderAPI.DTOs.Services;
using GateFinderAPI.Services.Interfaces;
using System.Text;
using Tesseract;

namespace GateFinderAPI.Services.Implements
{
    public class OcrService : IOcrService
    {
        private readonly TesseractEngine _engine;

        public OcrService()
        {
            var tessDataPath = Path.Combine(AppContext.BaseDirectory, "tessdata");

            _engine = new TesseractEngine(tessDataPath, "tha+eng", EngineMode.Default);
        }

        public List<ExtractDataDto> Extract(byte[] imageByte)
        {
            using var image = Pix.LoadFromMemory(imageByte);
            using var page = _engine.Process(image);

            string text = page.GetText();
            string[] textLines = text.Split('\n');

            List<ExtractDataDto> extractDataDtos = new List<ExtractDataDto>();
            foreach (string line in textLines)
            {
                string[] datas = line.Split(':');

                if (datas.Length == 2)
                {
                    string title = datas[0];
                    string value = datas[1];

                    extractDataDtos.Add(new ExtractDataDto()
                    {
                        Title = title,
                        Value = new StringBuilder(value)
                    });
                }
                else
                {
                    if (extractDataDtos.Count > 0)
                    {
                        extractDataDtos[extractDataDtos.Count - 1].Value.Append($" {line}");
                    }
                }
            }

            return extractDataDtos;
        }
    }
}

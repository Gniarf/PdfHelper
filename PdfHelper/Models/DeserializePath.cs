using iText.IO.Image;
using System.Text.Json.Serialization;

namespace PdfHelper.Models
{
    public class DeserializePath
    {
        [JsonPropertyName("Name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("ImagePathList")]
        public IEnumerable<FilePath> ImagePathList { get; set; } = Array.Empty<FilePath>();

    }
}

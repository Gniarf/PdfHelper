using System.Text.Json.Serialization;

namespace PdfHelper.Models
{
    public class FilePath
    {
        [JsonPropertyName("path")]
        public string Path { get; set; } = string.Empty;
    }
}

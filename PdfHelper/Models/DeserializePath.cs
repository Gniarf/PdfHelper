using System.Text.Json.Serialization;


namespace PdfHelper.Models
{
    public class DeserializePath
    {
        public IEnumerable<FilePath> File { get; set; } = Array.Empty<FilePath>();

        public DeserializePath(IEnumerable<FilePath> file)
        {
            File = file;
        }
        public DeserializePath() { }
    }
}

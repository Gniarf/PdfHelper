namespace PdfHelper.Models
{
    public class PagePdf
    {
        public IEnumerable<PageCoordinates> Page { get; set; } = Array.Empty<PageCoordinates>();
    }
  
}
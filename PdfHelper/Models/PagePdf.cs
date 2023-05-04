namespace PdfHelper.Models
{
    public class PagePdf
    {
        public IEnumerable<PageCoordinates> Page { get; set; } = Array.Empty<PageCoordinates>();
    }
    public class GroupByPage
    {
        public IEnumerable<PagePdf> GroupPage { get; set; } = Array.Empty<PagePdf>();
    }
}
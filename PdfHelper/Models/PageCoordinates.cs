namespace PdfHelper.Models
{
    public class PageCoordinates
    {
        public string Text { get; set; } = string.Empty;
        public float X1 { get; set; }
        public float Y1 { get; set; }
        public float X2 { get; set; }
        public float Y2 { get; set; }
        public float PageWidth { get; set; }
        public float PageHeight { get; set; }
    }
}
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Data;
using iText.Kernel.Pdf.Canvas.Parser.Listener;

namespace PdfHelper.Models
{
    public class ImageRenderListener : IEventListener
    {
        private readonly string outputFolderPath;
        private readonly string pdfFileName;
        private readonly int pageNumber;
        private readonly IList<byte[]> extractedImages = new List<byte[]>();

        public ImageRenderListener(string outputFolderPath, string pdfFileName, int pageNumber)
        {
            this.outputFolderPath = outputFolderPath;
            this.pdfFileName = pdfFileName;
            this.pageNumber = pageNumber;
        }

        public void EventOccurred(IEventData data, EventType type)
        {
            if (type.Equals(EventType.RENDER_IMAGE))
            {
                ImageRenderInfo renderInfo = (ImageRenderInfo)data;
                byte[] imageData = renderInfo.GetImage().GetImageBytes();
                extractedImages.Add(imageData);
            }
        }

        public IList<byte[]> GetExtractedImages()
        {
            return extractedImages;
        }
        public ICollection<EventType> GetSupportedEvents()
        {
            return new List<EventType> { EventType.RENDER_IMAGE };
        }
    }
}

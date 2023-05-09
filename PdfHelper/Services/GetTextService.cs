using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using PdfHelper.Contracts;
using PdfHelper.Models;

namespace PdfHelper.Services
{
    public class GetTextService : IExtractServicesText
    {
        public PagePdf ExtractResultv2(string pathFile)
        {
            PagePdf pageC = new();

            CustomTextRenderListener listener = new();

            if (pathFile != null)
            {

                PdfReader reader = new(pathFile);
                PdfDocument pdfDoc = new(reader);

                pdfDoc = new PdfDocument(new PdfReader(pathFile));
                Rectangle pageSize = pdfDoc.GetPage(1).GetPageSize();

                // Extract text with coordinates from all pages
                for (int pageNum = 1; pageNum <= pdfDoc.GetNumberOfPages(); pageNum++)
                {
                    PdfPage page = pdfDoc.GetPage(pageNum);

                    PdfCanvasProcessor parser = new(listener);
                    parser.ProcessPageContent(page);

                }
                foreach (PageCoordinates word in listener.Words)
                {
                    word.PageWidth = pageSize.GetWidth();
                    word.PageHeight = pageSize.GetHeight();
                }


                pageC = new() { Page = listener.Words };
                pdfDoc.Close();
            }
            return pageC;
        }
     
    }
}

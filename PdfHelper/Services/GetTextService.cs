using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf;
using Newtonsoft.Json;
using PdfHelper.Contracts;
using PdfHelper.Models;
using iText.Kernel.Geom;

namespace PdfHelper.Services
{
    public class GetTextService : IExtractServices
    {
        public void ExtractResult(DeserializePath pathFile)
        {
            CustomTextRenderListener listener = new();
           
            if (pathFile != null)
            {
                var item = pathFile.File.First().Path;

                PdfDocument pdfDoc = new(new PdfReader(item));
                foreach (var pdfFilePath in pathFile.File)
                {
                    pdfDoc = new PdfDocument(new PdfReader(pdfFilePath.Path));
                    Rectangle pageSize = pdfDoc.GetPage(1).GetPageSize();



                    // Extract text with coordinates from all pages
                    for (int pageNum = 1; pageNum <= pdfDoc.GetNumberOfPages(); pageNum++)
                    {
                        PdfPage page = pdfDoc.GetPage(pageNum);

                        PdfCanvasProcessor parser = new(listener);
                        parser.ProcessPageContent(page);

                        // Add the page dimensions to the list of coordinates for each word
                        foreach (PageCoordinates word in listener.Words)
                        {
                            word.PageWidth = pageSize.GetWidth();
                            word.PageHeight = pageSize.GetHeight();
                        }
                    }
                }
           


            // Serialize the list of words with coordinates to JSON
            PagePdf pagePdf = new() { Page = listener.Words };
            string json = JsonConvert.SerializeObject(pagePdf, Formatting.Indented);
            string FileOutput= $@"PdfHelper\Results\JsonResults";
            var date= DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
            string jsonFilePath = $@".\PdfHelper\Results\JsonResults\resultPdf_{date}_{Guid.NewGuid()}.json";
            if (!Directory.Exists(FileOutput))
            {
                Directory.CreateDirectory(FileOutput);
            }
            // Write the JSON to file
            File.WriteAllText(jsonFilePath, json);

            pdfDoc.Close();
            }
        }
    }
}

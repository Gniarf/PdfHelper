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
        public void ExtractResult(DeserializePath pathFile, string Folder)
        {
            
            CustomTextRenderListener listener = new();

            if (pathFile.ImagePathList != null)
            {
                var item = pathFile.ImagePathList.First().Path;

                PdfDocument pdfDoc = new(new PdfReader(item));
                foreach (var pdfFilePath in pathFile.ImagePathList)
                {
                    pdfDoc = new PdfDocument(new PdfReader(pdfFilePath.Path));
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

                }
                    PagePdf pageC = new() { Page = listener.Words };
               
                // Serialize the list of words with coordinates to JSON
                string json = JsonConvert.SerializeObject(pageC, Formatting.Indented);
                var date = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
                var FolderPath = $@"{Folder}\JsonResults";
                string jsonFilePath = $@"{FolderPath}\resultPdf_{date}_{Guid.NewGuid()}.json";
                if (!Directory.Exists(FolderPath))
                {
                    Directory.CreateDirectory(FolderPath);
                }
                // Write the JSON to file
                File.WriteAllText(jsonFilePath, json);

                pdfDoc.Close();
            }
        }
    }
}

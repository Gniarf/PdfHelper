using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using PdfHelper.Contracts;
using PdfHelper.Models;

namespace PdfHelper.Services
{
    public class GetTextService : IExtractServicesText
    {
        /* public PagePdf ExtractResultv2(string pathFile)
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
         }*/
        public List<WordData> ExtractResultv2(string pathFile)
        {
            List<WordData> wordDataList = new List<WordData>();

            // Création d'un objet PdfDocument à partir du fichier PDF
            using (PdfDocument pdfDocument = new PdfDocument(new PdfReader(pathFile)))
            {
                // Parcours de chaque page du document
                for (int pageNum = 1; pageNum <= pdfDocument.GetNumberOfPages(); pageNum++)
                {
                    // Extraction du contenu texte et des coordonnées de chaque mot de la page
                    var listener = new CustomTextRenderListener();
                    PdfCanvasProcessor parser = new PdfCanvasProcessor(listener);
                    parser.ProcessPageContent(pdfDocument.GetPage(pageNum));

                    // Récupération des données de chaque mot
                    List<WordData> pageWordData = listener.GetWordDataList();

                    // Ajout des données de chaque mot à la liste globale
                    wordDataList.AddRange(pageWordData);
                }
            }
            //PagePdf pagePdf = new PagePdf() { Page= wordDataList};
            return wordDataList;
        }

    }
}

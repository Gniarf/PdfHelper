using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using PdfHelper.Contracts;
using PdfHelper.Models;

namespace PdfHelper.Services
{
    public class GetTextService : IExtractServicesText
    {
       
        public List<WordData> ExtractResultv2(string pathFile)
        {
            List<WordData> wordDataList = new();

            // Création d'un objet PdfDocument à partir du fichier PDF
            using (PdfDocument pdfDocument = new (new PdfReader(pathFile)))
            {
                // Parcours de chaque page du document
                for (int pageNum = 1; pageNum <= pdfDocument.GetNumberOfPages(); pageNum++)
                {
                    // Extraction du contenu texte et des coordonnées de chaque mot de la page
                    var listener = new CustomTextRenderListener();
                    PdfCanvasProcessor parser = new (listener);
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

using iText.Kernel.Pdf.Canvas.Parser.Listener;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf;
using PdfHelper.Contracts;
using PdfHelper.Models;


namespace PdfHelper.Services
{
    public class PdfService : IPdfServices
    {
        public void Extract(DeserializePath deserialisePath, string Folder)
        {
            IExtractServices extractServices = null;
            var count = deserialisePath.ImagePathList.Count();
            var file = deserialisePath.ImagePathList.First().Path;
            bool test = EstScanPdf(file);
            if (test)
            {
                extractServices = new GetImageService();
                extractServices.ExtractResult(deserialisePath,Folder);
            }
            else
            {
                extractServices = new GetTextService();
                extractServices.ExtractResult(deserialisePath, Folder);
            }
        }
        
        public bool EstScanPdf(string cheminFichierPdf)
        {
            using PdfDocument pdfDocument = new(new PdfReader(cheminFichierPdf));
            int nbPages = pdfDocument.GetNumberOfPages();

            for (int i = 1; i <= nbPages; i++)
            {
                LocationTextExtractionStrategy strategy = new();
                PdfCanvasProcessor parser = new(strategy);
                parser.ProcessPageContent(pdfDocument.GetPage(i));
                string texte = strategy.GetResultantText();

                if (texte.Length > 1000)
                {
                    return false; // le fichier contient plus de 1000 caractères, probablement un document numérique
                }

                int nbMots = texte.Split(' ', '\n').Length;
                double densiteTexte = (double)nbMots / (pdfDocument.GetPage(i).GetPageSize().GetWidth() * pdfDocument.GetPage(i).GetPageSize().GetHeight());

                if (densiteTexte > 0.01)
                {
                    return false; // la densité de texte sur la page est supérieure à 1%, probablement un document numérique
                }
            }

            return true; // le fichier est probablement un scan
        }

    }
}

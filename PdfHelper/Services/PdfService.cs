using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using Newtonsoft.Json;
using PdfHelper.Contracts;
using PdfHelper.Models;

namespace PdfHelper.Services
{
    public class PdfService : IPdfServices
    {
        private readonly IExtractServicesImage extractServicesImage;
        private readonly IExtractServicesText extractServicesText;

        public PdfService(IExtractServicesImage extractServicesImage, IExtractServicesText extractServicesText)
        {
            this.extractServicesImage = extractServicesImage;
            this.extractServicesText = extractServicesText;
        }
        public void Extract(DeserializePath deserialisePath, string Folder)
        {
            var file = deserialisePath.ImagePathList;

            List<PagePdf> pagePdfs = new();
            foreach (var item in file)
            {
                bool verif = EstScanPdf(item.Path);

                if (!verif)
                {
                  PagePdf page = extractServicesText.ExtractResultv2(item.Path);
                    pagePdfs.Add(page);
                }
                else
                    extractServicesImage.ExtractResultv2(item.Path, Folder);
            }
            if (pagePdfs.Count > 0)
            {
                string json = JsonConvert.SerializeObject(pagePdfs, Formatting.Indented);
                var date = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
                var FolderPath = $@"{Folder}\JsonResults";
                string jsonFilePath = $@"{FolderPath}\resultPdf_{date}_{Guid.NewGuid()}.json";
                if (!Directory.Exists(FolderPath))
                {
                    Directory.CreateDirectory(FolderPath);
                }
                // Write the JSON to file
                File.WriteAllText(jsonFilePath, json);
            }
        }

        
         private static bool EstScanPdf(string cheminFichierPdf)
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

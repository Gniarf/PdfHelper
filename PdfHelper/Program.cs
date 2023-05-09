using Newtonsoft.Json;
using PdfHelper.Contracts;
using PdfHelper.Models;
using PdfHelper.Services;

namespace PdfHelper;

public class Program
{
    public static void Main(string[] args)
    {
        IExtractServicesImage extractServicesImage = new GetImageService();
        IExtractServicesText extractServicesText = new GetTextService();
        IPdfServices pdfServices = new PdfService(extractServicesImage,extractServicesText);
        string target = @"";
        string FolderResult= @"";
        if (args.Length > 0)
        {
            target = args[0];
            FolderResult = args[1];
        }
        if (target.Length > 0)
        {
            string json = File.ReadAllText(target);
            DeserializePath deserializePath = JsonConvert.DeserializeObject<DeserializePath>(json) ?? new DeserializePath();
            pdfServices.Extract(deserializePath,FolderResult);
        }

    }
}
using Newtonsoft.Json;
using PdfHelper.Contracts;
using PdfHelper.Models;
using PdfHelper.Services;

namespace PdfHelper;

public class Program
{
    public static void Main(string[] args)
    {
        IpdfServices pdfServices = new PdfService();
        string target = string.Empty;
        if (args.Length > 0)
        {
            target = args[0];
        }
        if (target.Length > 0)
        {
            string json = File.ReadAllText(target);
            DeserializePath deserializePath = JsonConvert.DeserializeObject<DeserializePath>(json) ?? new DeserializePath();
            pdfServices.Extract(deserializePath);
        }

    }
}
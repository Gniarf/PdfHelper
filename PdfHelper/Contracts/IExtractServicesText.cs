using PdfHelper.Models;

namespace PdfHelper.Contracts
{
    public interface IExtractServicesText
    {
      //  void ExtractResult(DeserializePath pathFile,string Folder);
        public PagePdf ExtractResultv2(string pathFile);
    }
}

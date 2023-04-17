using PdfHelper.Models;

namespace PdfHelper.Contracts
{
    public interface IExtractServices
    {
        void ExtractResult(DeserializePath pathFile);
    }
}

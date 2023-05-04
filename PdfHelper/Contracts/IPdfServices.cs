using PdfHelper.Models;

namespace PdfHelper.Contracts
{
    public interface IPdfServices
    {
        void Extract(DeserializePath deserialisePath, string Folder);

    }
}

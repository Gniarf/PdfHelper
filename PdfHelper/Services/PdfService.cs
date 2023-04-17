using PdfHelper.Contracts;
using PdfHelper.Models;

namespace PdfHelper.Services
{
    public class PdfService : IpdfServices
    {
        public void Extract(DeserializePath deserialisePath)
        {
            IEnumerable<IExtractServices> Services = new IExtractServices[] { new GetImageService(), new GetTextService() };
            if (deserialisePath != null)
            {
                Parallel.ForEach(Services, svc =>
                {
                    svc.ExtractResult(deserialisePath);
                });
            }
        }
       
    }
}

using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using PdfHelper.Contracts;
using PdfHelper.Models;



namespace PdfHelper.Services
{
    public class GetImageService : IExtractServicesImage
    {

        public void ExtractResultv2(string pathFile, string Folder)
        {
            if (pathFile is not null)
            {
                string outputFolderPath = @$"{Folder}\Images";

                
                    using PdfDocument pdfDoc = new(new PdfReader(pathFile));
                    int pageCount = pdfDoc.GetNumberOfPages();

                    for (int i = 1; i <= pageCount; i++)
                    {
                        PdfPage pdfPage = pdfDoc.GetPage(i);

                        ImageRenderListener listener = new(outputFolderPath, Path.GetFileNameWithoutExtension(pathFile), i);

                        new PdfCanvasProcessor(listener).ProcessPageContent(pdfPage);

                        IList<byte[]> extractedImages = listener.GetExtractedImages();

                        foreach (byte[] imageData in extractedImages)
                        {
                            string imageName = $@"page_{i}_{Guid.NewGuid()}.jpg";
                            if (!Directory.Exists(outputFolderPath))
                            {
                                Directory.CreateDirectory(outputFolderPath);
                            }
                            string imagePath = Path.Combine(outputFolderPath, imageName);

                            using FileStream outputStream = new(imagePath, FileMode.Create);
                            outputStream.Write(imageData, 0, imageData.Length);
                        }
                    }
                
            }

        }
    }
}

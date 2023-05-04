using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using PdfHelper.Contracts;
using PdfHelper.Models;



namespace PdfHelper.Services
{
    public class GetImageService : IExtractServices
    {
        public void ExtractResult(DeserializePath pathFile, string Folder)
        {
            if (pathFile is not null)
            {
                string outputFolderPath = @$"{Folder}\Images";
               
                foreach (var pdfFilePath in pathFile.ImagePathList)
                {
                    using PdfDocument pdfDoc = new(new PdfReader(pdfFilePath.Path));
                    int pageCount = pdfDoc.GetNumberOfPages();

                    for (int i = 1; i <= pageCount; i++)
                    {
                        PdfPage pdfPage = pdfDoc.GetPage(i);

                        ImageRenderListener listener = new(outputFolderPath, Path.GetFileNameWithoutExtension(pdfFilePath.Path), i);

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
}

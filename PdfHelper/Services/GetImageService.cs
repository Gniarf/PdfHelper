using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using PdfHelper.Contracts;
using PdfHelper.Models;



namespace PdfHelper.Services
{
    public class GetImageService : IExtractServices
    {
        public void ExtractResult(DeserializePath pathFile)
        {
            if(pathFile is not null)
            {
                string outputFolderPath = @".\PdfHelper\Results\Images";
                if (!Directory.Exists(outputFolderPath))
                {
                    Directory.CreateDirectory(outputFolderPath);
                }
                foreach (var pdfFilePath in pathFile.File)
                {
                    using (PdfDocument pdfDoc = new(new PdfReader(pdfFilePath.Path)))
                    {
                        int pageCount = pdfDoc.GetNumberOfPages();

                        for (int i = 1; i <= pageCount; i++)
                        {
                            PdfPage pdfPage = pdfDoc.GetPage(i);

                            ImageRenderListener listener = new(outputFolderPath, Path.GetFileNameWithoutExtension(pdfFilePath.Path), i);

                            new PdfCanvasProcessor(listener).ProcessPageContent(pdfPage);

                            IList<byte[]> extractedImages = listener.GetExtractedImages();

                            foreach (byte[] imageData in extractedImages)
                            {
                                string imageName = $"page_{i}_{Guid.NewGuid()}.jpg";
                                string imagePath = Path.Combine(outputFolderPath, imageName);

                                using (FileStream outputStream = new(imagePath, FileMode.Create))
                                {
                                    outputStream.Write(imageData, 0, imageData.Length);
                                }
                            }
                        }
                    }
                }
            }
           
        }
    }
}

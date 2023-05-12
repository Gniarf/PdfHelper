using Moq;
using PdfHelper.Services;

namespace PdfHelper.Tests
{
    public class GetImageServiceTest
    {
        [Fact]
        public void ExtractResult_ShouldDeserializePathBeNull()
        {
            // Arrange
            var sut = new GetImageService();
            string folder = "D:\\ResultRalevisuer\\Resultpdf";

            // Act & Assert
            sut.ExtractResultv2(null, folder);
        }
        [Fact]
        public void ExtractResult_ShouldDeserializePathNotNull()
        {

            var sut = new GetImageService();
            string folder = "D:\\ResultRalevisuer\\Resultpdf";
            sut.ExtractResultv2(It.IsAny<string>(), folder);

        }
    }
}

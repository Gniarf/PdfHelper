using Moq;
using PdfHelper.Models;
using PdfHelper.Services;

namespace PdfHelper.Tests
{
    public class GetTextServiceTest
    {
        [Fact]
        public void ExtractResult_ShouldDeserializePathBeNull()
        {
            // Arrange
            var sut = new GetTextService();

            // Act & Assert
            sut.ExtractResult(null);
        }
        [Fact]
        public void ExtractResult_ShouldDeserializePathNotNull()
        {
            var MockDeserialize = new Mock<CustomDeserializePath>(new List<FilePath> { new FilePath { Path = "C:/Users/AN/proj/test/Doctestimage.pdf" } });
            var sut = new GetTextService();
            sut.ExtractResult(MockDeserialize.Object);

        }
    }
}

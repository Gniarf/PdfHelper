using Moq;
using PdfHelper.Contracts;
using PdfHelper.Models;
using PdfHelper.Services;

namespace PdfHelper.Tests
{
    
    public class PdfServiceTest
    {
        [Fact]
        public void Extract_WhenDeserializePathIsNull_ShouldNotExtractAnyResult()
        {
            // Arrange
            var MockDeserialize = new Mock<CustomDeserializePath>(new List<FilePath> { new FilePath { Path = "C:/Users/AN/proj/test/Doctestimage.pdf" } });


            var getImageServiceMock = new Mock<GetImageService>();
            var getTextServiceMock = new Mock<GetTextService>();
            var services = new List<IExtractServices> { getImageServiceMock.Object, getTextServiceMock.Object };

            var sut = new PdfService();

            // Act
            sut.Extract(MockDeserialize.Object);

            
        }
        [Fact]
        public void Extract_ShouldExtractResultsUsingAllServicesInParallel()
        {
            // Arrange
            var MockDeserialize = new Mock<CustomDeserializePath>(new List<FilePath> { new FilePath { Path = "C:/Users/AN/proj/test/Doctestimage.pdf" } });


            var getImageServiceMock = new Mock<GetImageService>();
            var getTextServiceMock = new Mock<GetTextService>();
            var services = new List<IExtractServices> { getImageServiceMock.Object, getTextServiceMock.Object };

            var sut = new PdfService();

            // Act
            sut.Extract(MockDeserialize.Object);

          
            
        }
    }
}

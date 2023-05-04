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

            var sut = new PdfService();
            string folder = It.IsAny<string>();

            // Act
            sut.Extract(MockDeserialize.Object,folder);


        }
        [Fact]
        public void Extract_ShouldExtractResultsUsingAllServicesInParallel()
        {
            // Arrange
            var MockDeserialize = new Mock<CustomDeserializePath>(new List<FilePath> { new FilePath { Path = "C:/Users/AN/proj/test/Doctestimage.pdf" } });

            var sut = new PdfService();
            string folder = It.IsAny<string>();

            // Act
            sut.Extract(MockDeserialize.Object,folder);



        }
    }
}

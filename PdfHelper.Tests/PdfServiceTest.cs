using Moq;
using PdfHelper.Contracts;
using PdfHelper.Models;
using PdfHelper.Services;

namespace PdfHelper.Tests
{

    public class PdfServiceTest
    {
        private readonly Mock<IExtractServicesImage> MockGetImage;
        private readonly Mock<IExtractServicesText> MockGetText;
        public PdfServiceTest()
        {
            MockGetImage = new Mock<IExtractServicesImage>();
            MockGetText = new Mock<IExtractServicesText>();
        } 
        [Fact]
        public void Extract_WhenDeserializePathIsNotNull()
        {
            MockGetImage.Setup(s => s.ExtractResultv2(It.IsAny<string>(), It.IsAny<string>()));
            MockGetText.Setup(s=>s.ExtractResultv2(It.IsAny<string>())).Returns(new PagePdf() { Page= new List<PageCoordinates>() });
            // Arrange
            var MockDeserialize = new DeserializePath() {ImagePathList= new List<FilePath> { new FilePath { Path = "C:/Users/AN/proj/test/Doctestimage.pdf" } },Name="test" };
            var sut = new PdfService(MockGetImage.Object,MockGetText.Object);
            string folder = "D:\\ResultRalevisuer\\Resultpdf";
            // Act
            sut.Extract(MockDeserialize,folder);
        }
        [Fact]
        public void Extract_WhenDeserializePathIsNull()
        {
            MockGetImage.Setup(s => s.ExtractResultv2(It.IsAny<string>(), It.IsAny<string>()));
            MockGetText.Setup(s => s.ExtractResultv2(It.IsAny<string>())).Returns(new PagePdf() { Page = new List<PageCoordinates>() });
            // Arrange
            var MockDeserialize = new DeserializePath() { ImagePathList = new List<FilePath> { new FilePath() }, Name = "test" };
            var sut = new PdfService(MockGetImage.Object, MockGetText.Object);
            string folder = "D:\\ResultRalevisuer\\Resultpdf";
            // Act
            sut.Extract(MockDeserialize, folder);


        }
    }
}

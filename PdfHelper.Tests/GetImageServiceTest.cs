using Moq;
using PdfHelper.Models;
using PdfHelper.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var MockDeserialize = new Mock<CustomDeserializePath>(new List<FilePath> { new FilePath { Path = "C:/Users/AN/proj/test/Doctestimage.pdf" } });
            var sut = new GetImageService();
            string folder = "D:\\ResultRalevisuer\\Resultpdf";
            sut.ExtractResultv2(It.IsAny<string>(),folder);

        }
    }
}

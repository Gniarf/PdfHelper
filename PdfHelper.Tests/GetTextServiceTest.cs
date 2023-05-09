using Moq;
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
            sut.ExtractResultv2("");
        }
        [Fact]
        public void ExtractResult_ShouldDeserializePathNotNull()
        {
            var sut = new GetTextService();
            sut.ExtractResultv2(It.IsAny<string>());

        }
    }
}

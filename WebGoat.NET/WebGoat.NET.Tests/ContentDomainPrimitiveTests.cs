using Microsoft.AspNetCore.Authorization.Infrastructure;
using Xunit;
using WebGoatCore.Models;

namespace WebGoat.NET.Tests;


public class ContentDomainPrimitiveTests
{
    [Fact]
    public void Constructor_ValidContent_DoesNotThrow()
    {
        // Arrange
        string validContent = "Dette er valid content!";

        // Act & Assert
        var result = new ContentDomainPrimitive(validContent);
        Assert.NotNull(result);
    }

    [Theory]
    [InlineData("<script>")]
    [InlineData("Hello > World")]
    [InlineData("<div>")]
    public void Constructor_InvalidCharacters_ThrowsArgumentException(string invalid)
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
            new ContentDomainPrimitive(invalid)
        );
    }

    [Fact]
    public void Constructor_EmptyOrWhitespace_DoesThrow()
    {
        // Arrange
        string nullString = null;

       //Act & Assert
       var exception = Assert.Throws<ArgumentException>(() => 
            new ContentDomainPrimitive(nullString)
        );
        
        Assert.Contains("Content cannot be empty.", exception.Message);
    }

    [Fact]
    public void Constructor_ContentTooLong_ThrowsArgumentException()
    {
        // Arrange
        string tooLong = new string('a', 501);

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() =>
            new ContentDomainPrimitive(tooLong)
        );

        Assert.Contains("Content length exceeds the maximum allowed limit of 500 characters.", exception.Message);
    }

}

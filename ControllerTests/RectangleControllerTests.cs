using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using RectangleSearchApi;
using RectangleSearchApi.RectangleServices;

public class RectangleControllerTests
{
    [Fact]
    public void SearchRectangles_ValidRequest_ReturnsOkResult()
    {
        // Arrange
        var mockService = new Mock<IRectangleServices>();
        mockService.Setup(s => s.SearchRectangles(It.IsAny<List<Coordinate>>()))
            .Returns(new List<Rectangle>());

        var controller = new RectangleController(mockService.Object);
        var request = new RectangleSearchRequest
        {
            Coordinates = new List<Coordinate>
            {
                new Coordinate { X = 1, Y = 2 },
                new Coordinate { X = 3, Y = 4 }
            }
        };

        // Act
        var result = controller.SearchRectangles(request);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void SearchRectangles_InvalidRequest_ReturnsBadRequest()
    {
        // Arrange
        var mockService = new Mock<IRectangleServices>();
        var controller = new RectangleController(mockService.Object);
        var request = new RectangleSearchRequest(); // Empty request

        // Act
        var result = controller.SearchRectangles(request);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }

}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MongoDB.Driver.Linq;
using System.Linq;
using RectangleSearchApi;
using RectangleSearchApi.RectangleServices;

[ApiController]
[Route("api/rectangles")]
public class RectangleController : ControllerBase
{
    public IRectangleServices _rectangleServices;

    public RectangleController(IRectangleServices rectangleServices)
    {
        _rectangleServices = rectangleServices;
    }

    /// <summary>
    /// Gives all the records of Rectangles present in Database.
    /// </summary>
    /// <returns>Rectangle List</returns>
    [HttpGet("displayAll")]
    [Authorize]
    public IActionResult Index()
    {
        List<Rectangle> rectangles = _rectangleServices.GetAllRectangles();
        
        return Ok(rectangles);
    }

    /// <summary>
    /// Gives the records of Rectangles from database based on input Coordinates
    /// </summary>
    /// <param name="request"></param>
    /// <returns>Rectangle List</returns>
    [HttpPost("search")]
    [Authorize]
    public IActionResult SearchRectangles([FromBody] RectangleSearchRequest request)
    {
        if (request == null || request.Coordinates == null || request.Coordinates.Count == 0)
        {
            return BadRequest("Invalid request body. Please provide a valid list of coordinates.");
        }

        var rectangles = _rectangleServices.SearchRectangles(request.Coordinates);

        return Ok(rectangles);
    }
}



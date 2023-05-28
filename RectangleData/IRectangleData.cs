using System;
namespace RectangleSearchApi.RectangleData
{
	public interface IRectangleData
	{
        public List<Rectangle> SearchRectangles(List<Coordinate> coordinates);

        public List<Rectangle> GetAllRectangles();
    }
}


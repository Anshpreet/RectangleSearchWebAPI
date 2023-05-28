using System;
using RectangleSearchApi.RectangleData;

namespace RectangleSearchApi.RectangleServices
{
	public class RectangleServices : IRectangleServices
	{
        public readonly IRectangleData _rectangleData;

        public RectangleServices(IRectangleData rectangleData)
		{
            _rectangleData = rectangleData;
		}

        public List<Rectangle> GetAllRectangles()
        {
           return _rectangleData.GetAllRectangles();
        }

        public List<Rectangle> SearchRectangles(List<Coordinate> coordinates)
        {
            return _rectangleData.SearchRectangles(coordinates);
        }
    }
}


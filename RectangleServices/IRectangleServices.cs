using System;
using Microsoft.AspNetCore.Mvc;

namespace RectangleSearchApi.RectangleServices
{
	public interface IRectangleServices
	{
        public List<Rectangle> SearchRectangles(List<Coordinate> coordinates);

        public List<Rectangle> GetAllRectangles();

    }
}


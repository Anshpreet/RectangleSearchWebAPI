using System;
using Azure.Core;

namespace RectangleSearchApi.RectangleData
{
	public class RectangleData : IRectangleData
	{
        private readonly RectangleDbContext _dbContext;

        public RectangleData(RectangleDbContext dbContext)
		{
            _dbContext = dbContext;
		}

        public List<Rectangle> GetAllRectangles()
        {
            var rectangles = new List<Rectangle>();

            try
            {
                rectangles = _dbContext.RectanglesList.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rectangles;
        }



        public List<Rectangle> SearchRectangles(List<Coordinate> coordinates)
        {
            var rectangles = new List<Rectangle>();

            try
            {
                
                foreach (var coordinate in coordinates)
                {
                    var x = coordinate.X;
                    var y = coordinate.Y;

                    var rectangle = _dbContext.RectanglesList.FirstOrDefault(r =>
                        x >= r.XCoordinate && x <= r.XCoordinate + r.Width &&
                        y >= r.YCoordinate && y <= r.YCoordinate + r.Height
                    );

                    if (rectangle != null)
                    {
                        rectangles.Add(rectangle);
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return rectangles;
        }
    }
}


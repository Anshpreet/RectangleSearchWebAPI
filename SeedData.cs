using MongoDB.Driver;
using RectangleSearchApi;

public class SeedData
{

    public static void SeedRectangles(RectangleDbContext dbContext)
    {
        var rectanglesCollection = dbContext.Rectangles;

        if (rectanglesCollection.Find(r => true).Any())
        {
            return; // Data already seeded
        }

        Random random = new Random();
        var rectangles = new List<Rectangle>();

        for (int i = 0; i < 200; i++)
        {
            var rectangle = new Rectangle
            {
                XCoordinate = random.Next(0, 100),
                YCoordinate = random.Next(0, 100),
                Width = random.Next(1, 50),
                Height = random.Next(1, 50)
            };

            rectangles.Add(rectangle);
        }

        rectanglesCollection.InsertMany(rectangles);
    }

}

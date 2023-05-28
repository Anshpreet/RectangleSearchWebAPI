using System.Collections.Generic;
using RectangleSearchApi;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Data.Common;
using MongoDB.Driver;

public class RectangleDbContext
{

    private readonly IMongoDatabase _database;

    public RectangleDbContext(IMongoDatabase database)
    {
        _database = database;
    }

    public IMongoCollection<Rectangle> Rectangles => _database.GetCollection<Rectangle>("rectangles");

    public List<Rectangle> RectanglesList => _database.GetCollection<Rectangle>("rectangles").AsQueryable().ToList();
}


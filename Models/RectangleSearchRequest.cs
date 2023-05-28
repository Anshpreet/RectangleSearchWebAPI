using System;
using System.ComponentModel.DataAnnotations;

public class Coordinate
{
    [Required]
    public int X { get; set; }
    [Required]
    public int Y { get; set; }
}

public class RectangleSearchRequest
{
    [Required]
    public List<Coordinate> Coordinates { get; set; }
}



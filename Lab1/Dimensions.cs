using System;
namespace Lab1
{
    public class Dimensions
    {
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Dimensions()
        {
        }

        public Dimensions(int length, int width, int height)
        {
            Length = length;
            Width = width;
            Height = height;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;

namespace SNNClassifier.Graphic
{
    public static class BitmapVariation
    {
        public static List<Bitmap> Variation(this Bitmap bitmap, int delta)
        {
            if (delta < 0)
                throw new ArgumentException("delta must be positive");
            if (delta == 0)
                return new List<Bitmap>() { bitmap };
            List<Bitmap> images = new List<Bitmap>();
            var visited = new bool[delta*2+1,delta*2+1];


            for (int i = 0; i <= delta; i++)
            {
                for (int j = -i; j <= i; j++)
                {
                    for (int k = -i; k <= i; k++)
                    {
                        if (visited[j>0? j : 2 *j*-1, k > 0 ? k : k*2*-1])
                            continue;
                        Bitmap img = new Bitmap(bitmap.Width, bitmap.Height);
                        for (int y = 0; y < img.Height; y++)
                        {
                            for (int x = 0; x < img.Width; x++)
                            {
                                img.SetPixel(x, y, bitmap.GetColor(x + j, y + k));
                            }
                        }
                        images.Add(img);
                        visited[j > 0 ? j : 2 * j * -1, k > 0 ? k : k * 2 * -1] = true;
                    }
                }
            }

            return images;
        }

        private static Color GetColor(this Bitmap image, int x, int y)
        {
            if (x < 0 || y < 0 || x > image.Width - 1 || y > image.Width - 1)
            {
                return Color.FromArgb(255, 255, 255);
            }
            else
            {
                return image.GetPixel(x, y);
            }
        }
    }
}
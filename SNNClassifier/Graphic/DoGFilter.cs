using System;
using System.Collections.Generic;
using System.Drawing;

namespace SNNClassifier.Graphic
{
    public enum GaborAngel
    {
        _0=0,
        _45=1,
        _90=2,
        _135=3
    }

    public class DoGFilter
    {

        public static Image CreateFromArray(int [,] array)
        {
            Bitmap bmp = new Bitmap(array.GetLength(0), array.GetLength(1));
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    var val = array[i, j];
                    val =255- (val < 0 ? 0 : val > 255 ? 255 : val);
                    bmp.SetPixel(i,j,Color.FromArgb(val, val,val));
                }
            }
            return bmp;
        }

        private static int[,,] gabors;

        public Dictionary<GaborAngel,int[,]> Result { get; private set; }

        static DoGFilter()
        {
            gabors = new int[4, 3, 3]
            {
                {
                    {-1,-1,-1 },
                    { 2, 2, 2 },
                    {-1,-1,-1 }
                },
                {
                    {-1,-1, 2 },
                    {-1, 2,-1 },
                    { 2,-1,-1 }
                },
                {
                    {-1,2,-1 },
                    {-1, 2,-1 },
                    {-1, 2,-1 }
                },
                {
                    { 2,-1,-1},
                    {-1, 2,-1},
                    {-1,-1, 2}
                }
            };

        }

        public void CreateFromBitmap(Bitmap img)
        {
            var array = new int[img.Width, img.Height];
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    var pic = img.GetPixel(i,j);
                    array[i, j] = 255-(pic.R+pic.B+pic.G)/3;
                }
            }
            Create(array);
        }

        public void CreateFromFile(string FileName)
        {
            using (Bitmap image = (Bitmap)Bitmap.FromFile(FileName))
            {
                CreateFromBitmap(image);
            }
        }
        private void Create(int[,] pic)
        {
            this.Result = new Dictionary<GaborAngel, int[,]>(4);
            foreach (GaborAngel item in Enum.GetValues(typeof(GaborAngel)))
            {
                var res = new int[pic.GetLength(0), pic.GetLength(1)];
                for (int i = 0; i < pic.GetLength(0); i++)
                {
                    for (int j = 0; j < pic.GetLength(1); j++)
                    {
                        res[i, j] = Gabor(pic, i, j, item);
                    }
                }
                Result.Add(item, res);
            }
        }

        private int Gabor(int[,] pic, int x, int y, GaborAngel angle)
        {
            int value = 0;
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    var v1 = (x + i) < 0 || (x + i) >= pic.GetLength(0) || (y + j) < 0 || (y + j) >= pic.GetLength(1) ? 0 : pic[(x + i), (y + j)];
                    var v2 = gabors[(int)angle,(i + 1), (j + 1)];
                    value += (v1 * v2);
                }
            }
            return value<0 ? 0: (value * 255) / 1530;
        }
    }
}
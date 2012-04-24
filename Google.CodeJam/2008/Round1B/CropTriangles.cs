using System.IO;
using System.Numerics;
using Google.CodeJam.Support;

namespace Google.CodeJam._2008.Round1B
{
    class CropTriangles : ISolver
    {
        public void Solve(StreamWriter writer, StreamReader reader)
        {
            var T = int.Parse(reader.ReadLine());
            for (int t = 0; t < T; t++)
            {
                var count = new long[9];
                BigInteger triangles = 0;

                var temp = reader.ReadLine().Split();
                var n = long.Parse(temp[0]);
                var A = long.Parse(temp[1]);
                var B = long.Parse(temp[2]);
                var C = long.Parse(temp[3]);
                var D = long.Parse(temp[4]);
                var x0 = long.Parse(temp[5]);
                var y0 = long.Parse(temp[6]);
                var M = long.Parse(temp[7]);

                var X = x0;
                var Y = y0;
                for (int i = 0; i < n; i++)
                {
                    count[(X % 3) * 3 + (Y % 3)]++;
                    X = (A * X + B) % M;
                    Y = (C * Y + D) % M;
                }

                for (int i = 0; i < 9; i++)
                    if (count[i] >= 3)
                        triangles += count[i] * (count[i] - 1) * (count[i] - 2) / 6;

                for (int i = 0; i < 9; i++)
                    for (int j = i + 1; j < 9; j++)
                        for (int k = j + 1; k < 9; k++)
                            if ((((i / 3) + (j / 3) + (k / 3)) % 3 == 0) && ((i + j + k) % 3 == 0))
                                triangles += count[i] * count[j] * count[k];

                writer.WriteLine("Case #{0}: {1}", t + 1, triangles);
            }
        }
    }
}

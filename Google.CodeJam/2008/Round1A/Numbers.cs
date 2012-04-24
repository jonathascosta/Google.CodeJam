using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.CodeJam.Support;
using System.IO;
using System.Numerics;

namespace Google.CodeJam._2008.Round1A
{
    class Numbers : ISolver
    {
        public void Solve(StreamWriter writer, StreamReader reader)
        {
            var T = int.Parse(reader.ReadLine());
            for (int i = 0; i < T; i++)
            {
                var n = int.Parse(reader.ReadLine());
                var A = new long[,] { { 3, 5 }, { 1, 3 } };
                var C = FastExpo(A, n);

                var X = 2 * C[0, 0];
                var Y = (X - 1) % 1000;
                writer.WriteLine("Case #{0}: {1:D3}", i + 1, Y);
            }
        }

        private long[,] FastExpo(long[,] A, int n)
        {
            if (n == 1)
                return A;
            else
            {
                var B = FastExpo(A, n / 2);
                var C = Multiply(B, B);
                if (n % 2 == 0)
                    return C;
                else
                    return Multiply(C, A);
            }
        }

        private long[,] Multiply(long[,] A, long[,] B)
        {
            var C = new long[2, 2];

            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                    for (int k = 0; k < 2; k++)
                        C[i, j] += A[i, k] * B[k, j] % 1000;

            return C;
        }
    }
}

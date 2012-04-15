using System;
using System.Collections.Generic;
using Google.CodeJam.Support;

namespace Google.CodeJam._2012.QualificationRound
{
    class RecycledNumbers : ISolver
    {
        public void Solve(System.IO.StreamWriter writer, System.IO.StreamReader reader)
        {
            int T = int.Parse(reader.ReadLine());
            for (int i = 0; i < T; i++)
            {
                string[] parameters = reader.ReadLine().Split(' ');
                int A = int.Parse(parameters[0]);
                int B = int.Parse(parameters[1]);
                int count = 0;

                for (int j = A; j <= B; j++)
                {
                    var log = (int)Math.Log10(j);
                    var existent = new List<int>();
                    for (int k = 1; k <= log; k++)
                    {
                        var shifted = (j / (int)Math.Pow(10, k)) + (j % (int)Math.Pow(10, k)) * (int)Math.Pow(10, log - k + 1);
                        if (shifted <= B && shifted > j && !existent.Contains(shifted))
                        {
                            existent.Add(shifted);
                            count++;
                        }
                    }
                }

                writer.WriteLine("Case #{0}: {1}", i + 1, count);
            }
        }
    }
}

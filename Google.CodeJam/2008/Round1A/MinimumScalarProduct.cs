using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.CodeJam.Support;
using System.IO;

namespace Google.CodeJam._2008.Round1A
{
    class MinimumScalarProduct : ISolver
    {
        public void Solve(StreamWriter writer, StreamReader reader)
        {
            int T = int.Parse(reader.ReadLine());
            for (int t = 0; t < T; t++)
            {
                int n = int.Parse(reader.ReadLine());
                var x = reader.ReadLine().Split(' ').Select(s => long.Parse(s)).OrderBy(number => number).ToArray();
                var y = reader.ReadLine().Split(' ').Select(s => long.Parse(s)).OrderByDescending(number => number).ToArray();
                var result = 0L;
                for (int i = 0; i < n; i++)
                    result += x[i] * y[i];

                writer.WriteLine("Case #{0}: {1}", t + 1, result);
            }
        }
    }
}

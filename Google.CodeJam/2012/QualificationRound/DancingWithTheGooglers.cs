using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.CodeJam.Support;

namespace Google.CodeJam._2012.QualificationRound
{
    class DancingWithTheGooglers : ISolver
    {
        public void Solve(System.IO.StreamWriter writer, System.IO.StreamReader reader)
        {
            int T = int.Parse(reader.ReadLine());
            for (int i = 0; i < T; i++)
            {
                string[] parameters = reader.ReadLine().Split(' ');
                int N = int.Parse(parameters[0]);
                int S = int.Parse(parameters[1]);
                int p = int.Parse(parameters[2]);
                var t = parameters.Skip(3).Select(s => int.Parse(s)).OrderBy(x => x).ToArray();
                int y = 0;

                if (p == 0)
                    y = N;
                else if (p == 1)
                    y = t.Count(x => x > 0);
                else
                    for (int j = 0; j < N; j++)
                        if (t[j] - p - 2 * ((S > 0) ? (p - 2) : (p - 1)) >= 0)
                        {
                            S--;
                            y++;
                        }

                writer.WriteLine("Case #{0}: {1}", i + 1, y);
            }
        }
    }
}

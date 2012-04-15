using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Google.CodeJam.Support;

namespace Google.CodeJam._2009.QualificationRound
{
    class WelcomeToCodeJam : ISolver
    {
        private string phrase = "welcome to code jam";
        const int limit = 10 * 1000;

        private int Search(int c, int start, string row)
        {
            int times = 0;
            int index = row.IndexOf(phrase[c], start);

            while (index >= 0)
            {
                if (c != (phrase.Length - 1))
                    times += Search(c + 1, index + 1, row);
                else
                {
                    times++;

                    if (times > limit)
                        times -= limit;
                }

                if ((index + 1) < row.Length)
                    index = row.IndexOf(phrase[c], index + 1);
                else
                    break;
            }

            return times;
        }

        public void Solve(StreamWriter writer, StreamReader reader)
        {
            int T = int.Parse(reader.ReadLine());
            for (int t = 0; t < T; t++)
            {
                var row = reader.ReadLine();
                var times = Search(0, 0, row);
                writer.WriteLine("Case #{0}: {1}", t + 1, times.ToString("D4"));
            }
        }
    }
}

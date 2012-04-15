using System.Collections.Generic;
using System.Linq;
using Google.CodeJam.Support;
using System.IO;
using System.Text.RegularExpressions;

namespace Google.CodeJam._2009.QualificationRound
{
    class AlienLanguage : ISolver
    {
        public void Solve(StreamWriter writer, StreamReader reader)
        {
            var parameters = reader.ReadLine().Split(' ');
            var L = int.Parse(parameters[0]);
            var D = int.Parse(parameters[1]);
            var N = int.Parse(parameters[2]);

            var words = new List<string>(D + 1);
            for (int i = 0; i < D; i++)
                words.Add(reader.ReadLine());

            for (int i = 0; i < N; i++)
            {
                var format = reader.ReadLine().Replace('(', '[').Replace(')', ']');
                var wordCount = words.Count(p => Regex.IsMatch(p, format));
                writer.WriteLine("Case #{0}: {1}", i + 1, wordCount);
            }
        }
    }
}

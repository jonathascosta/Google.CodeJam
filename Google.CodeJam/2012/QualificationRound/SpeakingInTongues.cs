﻿using Google.CodeJam.Support;

namespace Google.CodeJam
{
    class SpeakingInTongues : ISolver
    {
        public void Solve(System.IO.StreamWriter writer, System.IO.StreamReader reader)
        {
            char[] english = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', ' ' };
            string googlerese = "ynficwlbkuomxsevzpdrjgthaq ";

            int T = int.Parse(reader.ReadLine());
            for (int i = 0; i < T; i++)
            {
                string G = reader.ReadLine();
                string S = "";

                foreach (var c in G)
                    S += english[googlerese.IndexOf(c)];

                writer.WriteLine("Case #{0}: {1}", i + 1, S);
            }
        }
    }
}

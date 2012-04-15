using System;
using System.Linq;
using System.IO;
using Google.CodeJam.Support;
using System.Collections.Generic;
using System.Drawing;

namespace Google.CodeJam._2009.QualificationRound
{
    class Watersheds : ISolver
    {
        private int H, W;
        private Dictionary<short, List<Point>> altitudes;
        private short[,] map;
        private char[,] watersheds;
        private char label;
        private short watershedsCount;

        private Point FindLowestNeighbor(Point p)
        {
            Point lowest = p;

            if ((p.X > 0) && (map[p.X - 1, p.Y] < map[lowest.X, lowest.Y]))
                lowest = new Point(p.X - 1, p.Y);

            if ((p.Y > 0) && (map[p.X, p.Y - 1] < map[lowest.X, lowest.Y]))
                lowest = new Point(p.X, p.Y - 1);

            if ((p.Y < (W - 1)) && (map[p.X, p.Y + 1] < map[lowest.X, lowest.Y]))
                lowest = new Point(p.X, p.Y + 1);

            if ((p.X < (H - 1)) && (map[p.X + 1, p.Y] < map[lowest.X, lowest.Y]))
                lowest = new Point(p.X + 1, p.Y);

            return lowest;
        }

        private char FindPath(Point p)
        {
            Point lowest = FindLowestNeighbor(p);

            if (lowest != p)
            {
                if (watersheds[lowest.X, lowest.Y] == 0)
                {
                    watersheds[lowest.X, lowest.Y] = FindPath(lowest);
                    watershedsCount++;
                }

                return watersheds[lowest.X, lowest.Y];
            }

            return ++label;
        }

        private void OrderLabels()
        {
            var labels = new List<char>();

            for (int i = 0; i < H; i++)
            {
                for (int j = 0; j < W; j++)
                {
                    if (!labels.Contains(watersheds[i, j]))
                        labels.Add(watersheds[i, j]);

                    if (labels.Count == (label - 'A' + 1))
                        break;
                }

                if (labels.Count == (label - 'A' + 1))
                    break;
            }

            var newLabel = 'a';

            for (int c = 0; c < labels.Count; c++)
            {
                for (int i = 0; i < H; i++)
                    for (int j = 0; j < W; j++)
                        if (watersheds[i, j] == labels[c])
                            watersheds[i, j] = newLabel;

                newLabel++;
            }
        }

        private void WriteResult(StreamWriter writer, int testCase)
        {
            writer.WriteLine("Case #{0}:", testCase + 1);

            for (int i = 0; i < H; i++)
            {
                writer.Write("{0}", watersheds[i, 0]);

                for (int j = 1; j < W; j++)
                    writer.Write(" {0}", watersheds[i, j]);

                writer.Write("\r\n");
            }
        }

        public void Solve(StreamWriter writer, StreamReader reader)
        {
            int T = int.Parse(reader.ReadLine());
            for (int t = 0; t < T; t++)
            {
                var parameters = reader.ReadLine().Split(' ');
                H = int.Parse(parameters[0]);
                W = int.Parse(parameters[1]);

                watershedsCount = 0;
                label = (char)('A' - 1);
                map = new short[H, W];
                altitudes = new Dictionary<short, List<Point>>();
                watersheds = new char[H, W];

                for (int i = 0; i < H; i++)
                {
                    parameters = reader.ReadLine().Split(' ');
                    for (int j = 0; j < W; j++)
                    {
                        map[i, j] = short.Parse(parameters[j]);

                        if (!altitudes.Keys.Contains(map[i, j]))
                            altitudes.Add(map[i, j], new List<Point>());
                        altitudes[map[i, j]].Add(new Point(i, j));
                    }
                }

                var altitudesOrdenadas = altitudes.Keys.OrderBy(x => x);

                foreach (short a in altitudesOrdenadas)
                {
                    foreach (Point p in altitudes[a])
                    {
                        if (watersheds[p.X, p.Y] == 0)
                        {
                            watersheds[p.X, p.Y] = FindPath(p);
                            watershedsCount++;

                            if (watershedsCount == H * W)
                                break;
                        }
                    }

                    if (watershedsCount == H * W)
                        break;
                }

                OrderLabels();
                WriteResult(writer, t);
            }
        }
    }
}

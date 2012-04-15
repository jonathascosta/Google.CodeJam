using System.IO;
using Google.CodeJam._2012.QualificationRound;

namespace Google.CodeJam
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamWriter writer = new StreamWriter("result.out"))
            {
                foreach (var item in Directory.GetFiles(".", "*.in"))
                {
                    using (StreamReader reader = new StreamReader(item))
                    {
                        //new SpeakingInTongues().Solve(writer, reader);
                        //new DancingWithTheGooglers().Solve(writer, reader);
                        new RecycledNumbers().Solve(writer, reader);
                    }
                    File.Move(item, string.Format("{0}.processed", item));
                }
            }
        }
    }
}

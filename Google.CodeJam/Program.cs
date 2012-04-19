using System.IO;

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
                        new Google.CodeJam._2008.Round1A.MinimumScalarProduct().Solve(writer, reader);
                        //new Google.CodeJam._2008.Round1A.Milkshakes().Solve(writer, reader);
                        //new Google.CodeJam._2008.Round1A.MilkshakesEventDrivenApproach().Solve(writer, reader);

                        //new Google.CodeJam._2009.QualificationRound.AlienLanguage().Solve(writer, reader);
                        //new Google.CodeJam._2009.QualificationRound.Watersheds().Solve(writer, reader);
                        //new Google.CodeJam._2009.QualificationRound.WelcomeToCodeJam().Solve(writer, reader);

                        //new Google.CodeJam._2012.QualificationRound.SpeakingInTongues().Solve(writer, reader);
                        //new Google.CodeJam._2012.QualificationRound.DancingWithTheGooglers().Solve(writer, reader);
                        //new Google.CodeJam._2012.QualificationRound.RecycledNumbers().Solve(writer, reader);
                    }
                    File.Move(item, string.Format("{0}.processed", item));
                }
            }
        }
    }
}

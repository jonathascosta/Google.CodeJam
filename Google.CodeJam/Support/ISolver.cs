using System.IO;

namespace Google.CodeJam.Support
{
    interface ISolver
    {
        void Solve(StreamWriter writer, StreamReader reader);
    }
}

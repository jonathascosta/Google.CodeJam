using System.Collections.Generic;
using System.Linq;
using Google.CodeJam.Support;
using System.IO;
using System.Text.RegularExpressions;

namespace Google.CodeJam
{
    class LuckyNumber : ISolver
    {
        public void Solve(StreamWriter writer, StreamReader reader)
        {
            var list = new LinkedList<int>(Enumerable.Range(1, 100));
            var current = list.First.Next;

            while (current != null)
            {
                var value = current.Value;
                var removing = list.First;
                while (removing != null)
                {
                    for (int i = 1; i < value && removing != null; i++)
                        removing = removing.Next;

                    if (removing == null)
                        break;

                    if (removing == current)
                        current = current.Previous;

                    var next = removing.Next;
                    list.Remove(removing);
                    removing = next;
                }
                current = current.Next;
            }
        }
    }
}

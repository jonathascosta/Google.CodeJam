using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.CodeJam.Support;
using System.IO;

namespace Google.CodeJam._2008.Round1A
{
    class MilkshakesEventDrivenApproach : ISolver
    {
        class Customer
        {
            public IList<Flavor> Flavors = new List<Flavor>();

            public bool IsSatisfiedBy(IEnumerable<Flavor> flavors)
            {
                return this.Flavors.Intersect(flavors).Any();
            }

            public bool HasMaltedFlavor()
            {
                return this.Flavors.Any(f => f.Malted);
            }

            public Flavor GetMaltedFlavor()
            {
                return this.Flavors.SingleOrDefault(f => f.Malted);
            }

            public void FlavorChanged(object sender, EventArgs e)
            {
                var flavors = (IEnumerable<Flavor>)sender;
                if (!IsSatisfiedBy(flavors))
                {
                    if (HasMaltedFlavor())
                    {
                        var malted = GetMaltedFlavor();
                        var flavor = flavors.Single(f => f.Number == malted.Number);
                        flavor.Malted = true;
                    }
                    else
                        throw new Exception();
                }
            }
        }

        class Flavor : IEquatable<Flavor>
        {
            public int Number;

            private bool malted;
            public bool Malted
            {
                get
                {
                    return malted;
                }
                set
                {
                    malted = value;
                    if (Changed != null)
                        Changed(Parent, EventArgs.Empty);
                }
            }

            public object Parent;

            public event EventHandler Changed;

            public bool Equals(Flavor other)
            {
                return this.Number == other.Number && this.Malted == other.Malted;
            }

            public override bool Equals(object obj)
            {
                return this.Equals((Flavor)obj);
            }

            public override int GetHashCode()
            {
                return Number * (Malted ? 2 : 1);
            }
        }

        public void Solve(StreamWriter writer, StreamReader reader)
        {
            int C = int.Parse(reader.ReadLine());
            for (int c = 0; c < C; c++)
            {
                var impossible = false;
                int N = int.Parse(reader.ReadLine());
                var flavors = new List<Flavor>();
                for (int n = 0; n < N; n++)
                    flavors.Add(new Flavor() { Number = n + 1, Parent = flavors });

                int M = int.Parse(reader.ReadLine());
                var customers = new List<Customer>();
                for (int m = 0; m < M; m++)
                {
                    var customer = new Customer();
                    customers.Add(customer);
                    var temp = reader.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();

                    var i = 0;
                    for (int t = 0; t < temp[0]; t++)
                    {
                        var flavor = new Flavor() { Number = temp[++i], Malted = (temp[++i] == 1) };
                        flavors.Single(f => f.Number == flavor.Number).Changed += customer.FlavorChanged;
                        customer.Flavors.Add(flavor);
                    }
                }

                try
                {
                    foreach (var customer in customers)
                    {
                        if (!customer.IsSatisfiedBy(flavors))
                        {
                            if (customer.HasMaltedFlavor())
                            {
                                var malted = customer.GetMaltedFlavor();
                                var flavor = flavors.Single(f => f.Number == malted.Number);
                                flavor.Malted = true;
                            }
                            else
                            {
                                impossible = true;
                                break;
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    impossible = true;
                }

                if (impossible)
                    writer.WriteLine("Case #{0}: IMPOSSIBLE", c + 1);
                else
                    writer.WriteLine("Case #{0}: {1}", c + 1, string.Join(" ", flavors.Select(f => f.Malted ? "1" : "0")));
            }
        }
    }
}

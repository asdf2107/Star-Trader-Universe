using System;
using System.Collections.Generic;
using System.Text;

namespace Star_Trader_Universe
{
    public class Resource : IPhysical
    {
        public enum Material
        {
            Wood,
            Rocks,
            Glass,
            Steel,
            Gold,
            Uranium,
        }

        public int Mass { get; set; }
        public Material Type { get; set; }

        public Resource(int mass, Material t)
        {
            Mass = mass;
            Type = t;
        }

        public Resource Split(int splitMass)
        {
            if (splitMass < Mass)
            {
                Mass -= splitMass;
                return new Resource(splitMass, Type);
            }
            else
            {
                throw new FormatException("splitMass was " + splitMass + ", the whole mass was " + Mass);
            }
        }

        public static Resource operator +(Resource r1, Resource r2)
        {
            if (r1.Type == r2.Type)
            {
                return new Resource(r1.Mass + r2.Mass, r1.Type);
            }
            else
            {
                throw new Exception("Types were " + r1.Type + "  and " + r2.Type);
            }
        }
    }
}

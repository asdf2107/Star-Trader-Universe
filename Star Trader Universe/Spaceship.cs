using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Star_Trader_Universe
{
    public class Spaceship : INameable
    {
        public string Name { get; set; }
        public Point Location { get; set; }
        public List<IPhysical> Parts { get; set; } = new List<IPhysical>();
        public List<IPhysical> Cargo { get; set; } = new List<IPhysical>();
        public List<Person> People { get; set; } = new List<Person>();
        public int CargoCap { get; protected set; } = 10000;
        public int PeopleCap { get; protected set; } = 20;
        public int Thrust { get; protected set; } = 110000;

        public Spaceship(string name, Point loc)
        {
            Name = name;
            Location = loc;
        }

        public List<Person> LeaveAll()
        {
            List<Person> p = People;
            People = new List<Person>();
            return p;
        }

        public bool Enter(List<Person> people)
        {
            if (People.Count + people.Count <= PeopleCap)
            {
                People.Concat(people);
                return true;
            }
            else throw new Exception("No enough space for people!");
        }

        public bool CanLiftUp(int g)
        {
            if (Thrust / g >= GetMass())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetMass()
        {
            int mass = 0;
            List<IPhysical> AllObj = (List<IPhysical>)Cargo.Concat(Cargo).Concat(People);
            foreach (var item in AllObj)
            {
                mass += item.Mass;
            }
            return mass;
        }
    }
}

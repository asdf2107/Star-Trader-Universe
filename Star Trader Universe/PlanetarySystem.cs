using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Star_Trader_Universe
{
    public class PlanetarySystem : ILocatable, INameable
    {
        public string Name { get; set; }
        public List<Planet> Planets { get; set; }
        public Point Location { get; set; }

        public PlanetarySystem(string name, List<Planet> planets)
        {
            Name = name;
            Planets = planets;
        }

        public void AddPlanet(Planet p)
        {
            Planets.Add(p);
        }

        public Planet this[int index]
        {
            get => Planets[index];
            set => Planets[index] = value;
        }
    }
}

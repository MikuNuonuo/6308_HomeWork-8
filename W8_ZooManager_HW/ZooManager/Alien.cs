using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZooManager
{
    public class Alien: BaseItem, IPredator
    {

        List<string> AlienHunt = new List<string>() { "cat", "mouse","chick", "raptor"};

        public Alien(string name)
        {
            emoji = "👾";
            species = "alien";
            this.name = name; // "this" to clarify instance vs. method parameter

        }

        public override void Activate(List<List<Zone>> animalZones)
        {
            base.Activate(animalZones);
            Console.WriteLine("I am an Alien. Hooo!");
            Hunt(animalZones);
        }

        //implement Ipradtor
        public void Hunt(List<List<Zone>> animalZones)
        {
            BaseHunt(animalZones, AlienHunt);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZooManager
{
    public class Chick:Bird,IPrey
    {
        //(feature c)make a subclass of Bird called Chick
        public Chick(string name)
        {
            emoji = "🐥";
            species = "chick";
            this.name = name; // "this" to clarify instance vs. method parameter
                reactionTime = new Random().Next(6, 11); // reaction time 6  to 10
            }
        List<string> chickFlee = new List<string>() { "cat", "alien" };

        public override void Activate(List<List<Zone>> animalZones)
        {
            base.Activate(animalZones);
            Console.WriteLine("I am a chick.");
            Flee(animalZones);//flee from cat
        }
        //implement Iprey
        public bool Flee(List<List<Zone>> animalZones)
        {
            return BaseFlee(animalZones, chickFlee);

        }
    }
}

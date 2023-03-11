using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZooManager
{
    public class Raptor : Bird, IPredator
    {  //(feature a)new subclass Raptor.
        public Raptor(string name)
        {
            emoji = "🦅";
            species = "raptor";
            this.name = name; // "this" to clarify instance vs. method parameter
            reactionTime = 1; // reaction time of 1 
        }

        List<string> raptorHunt = new List<string>() {"cat", "mouse" }; // hunt cat and mouse
        List<string> raptorFlee = new List<string>() { "alien" }; // can be hunt by alien

        public override void Activate(List<List<Zone>> animalZones)
        {
            base.Activate(animalZones);
            Console.WriteLine("I am a raptor.woo~");
            Hunt(animalZones);
        }

        //implement Iprey
        public bool Flee(List<List<Zone>> animalZones)
        {
            return BaseFlee(animalZones, raptorFlee);
        }

        //implement Ipradtor

        public void Hunt(List<List<Zone>> animalZones)
        {
            if (Flee(animalZones)) return;
            BaseHunt(animalZones, raptorHunt);
        }
    }
}

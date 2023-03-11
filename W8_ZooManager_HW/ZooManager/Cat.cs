using System;
using System.Collections.Generic;

namespace ZooManager
{
    public class Cat : Animal, IPredator, IPrey
    {
        
        public Cat(string name)
        {
            emoji = "🐱";
            species = "cat";
            this.name = name;
            reactionTime = new Random().Next(1, 6); // reaction time 1 (fast) to 5 (medium)
        }
        List<string> catFlee = new List<string>() { "raptor", "alien" };
        List<string> catHunt = new List<string>() { "mouse", "chick" }; //(feature c, cat hunt chicks)

        public override void Activate(List<List<Zone>> animalZones)
        {
            base.Activate(animalZones);
            Console.WriteLine("I am a cat. Meow.");
            Hunt(animalZones); 
        }

        //implement Iprey
        public bool Flee(List<List<Zone>> animalZones)
        {
            return BaseFlee(animalZones, catFlee);
        }

        //implement Ipradtor
        //(feature e, avoid raptor entities and overhunting 
        public void Hunt(List<List<Zone>> animalZones) {
            if (Flee(animalZones)) return;
            BaseHunt(animalZones, catHunt);
        }


      


    }
}


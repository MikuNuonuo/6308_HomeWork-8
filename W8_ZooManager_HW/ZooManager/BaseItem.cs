using System;
using System.Collections.Generic;

namespace ZooManager
{
    public class BaseItem
    {
        public string emoji;
        public string species;
        public string name;
        public int reactionTime = 5; // default reaction time for animals (1 - 10)
        public bool isCurrentMoved = false;//(feature o) control not move two or more
        public int turn = 0;// (feature m)(feature p)(feature q)on board turn

        public Point location;

        virtual public void Reproduce(int x, int y, List<List<Zone>> animalZones)
        {
            Console.WriteLine($"Animal {name} at try to reproduce");
        }

        public void ReportLocation()
        {
            Console.WriteLine($"I am at {location.x},{location.y}");
        }

        virtual public void Activate(List<List<Zone>> animalZones)
        {
            Console.WriteLine($"Animal {name} at {location.x},{location.y} activated");
        }

        protected bool Seek(int x, int y, List<List<Zone>> animalZones, Direction d, List<string> target)
        {
            // prevent null reference exception
            if (animalZones == null || animalZones.Count == 0) {
                return false;
            }
            int numCellsY = animalZones.Count;
            int numCellsX = animalZones[0].Count;
            switch (d)
            {
                case Direction.up:
                    y--;
                    break;
                case Direction.down:
                    y++;
                    break;
                case Direction.left:
                    x--;
                    break;
                case Direction.right:
                    x++;
                    break;
            }
            if (y < 0 || x < 0 || y > numCellsY - 1 || x > numCellsX - 1) return false;
            if (animalZones[y][x].occupant == null) return false;
            if (target.Contains(animalZones[y][x].occupant.species))//checek if target contains the species we need
            {
                return true;
            }
            return false;
        }


        /* This method currently assumes that the attacker has determined there is prey
         * in the target direction. In addition to bug-proofing our program, can you think
         * of creative ways that NOT just assuming the attack is on the correct target (or
         * successful for that matter) could be used?
         */
         public void Attack(BaseItem attacker, Direction d, List<List<Zone>> animalZones)
        {
            Console.WriteLine($"{attacker.name} is attacking {d.ToString()}");
            int x = attacker.location.x;
            int y = attacker.location.y;
            //(feature p)
            attacker.turn = 0;
            switch (d)
            {
                case Direction.up:
                    animalZones[y - 1][x].occupant = attacker;
                    break;
                case Direction.down:
                    animalZones[y + 1][x].occupant = attacker;
                    break;
                case Direction.left:
                    animalZones[y][x - 1].occupant = attacker;
                    break;
                case Direction.right:
                    animalZones[y][x + 1].occupant = attacker;
                    break;
            }
            animalZones[y][x].occupant = null;
        }

        public void BaseHunt(List<List<Zone>> animalZones, List<string> preyAnimal)
        {
            if (Seek(location.x, location.y, animalZones, Direction.up, preyAnimal))
            {
                Attack(this, Direction.up, animalZones);
            }
            else if (Seek(location.x, location.y, animalZones, Direction.down, preyAnimal))
            {
                Attack(this, Direction.down, animalZones);
            }
            else if (Seek(location.x, location.y, animalZones, Direction.left, preyAnimal))
            {
                Attack(this, Direction.left, animalZones);
            }
            else if (Seek(location.x, location.y, animalZones, Direction.right, preyAnimal))
            {
                Attack(this, Direction.right, animalZones);
            }
        }

    }
}

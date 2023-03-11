using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZooManager
{
    public class Animal:BaseItem
    {
        /* We can't make the same assumptions with this method that we do with Attack, since
      * the animal here runs AWAY from where they spotted their target (using the Seek method
      * to find a predator in this case). So, we need to figure out if the direction that the
      * retreating animal wants to move is valid. Is movement in that direction still on the board?
      * Is it just going to send them into another animal? With our cat & mouse setup, one is the
      * predator and the other is prey, but what happens when we have an animal who is both? The animal
      * would want to run away from their predators but towards their prey, right? Perhaps we can generalize
      * this code (and the Attack and Seek code) to help our animals strategize more...
      */
        public bool Retreat(Animal runner, Direction d, List<List<Zone>> animalZones)
        {
            Console.WriteLine($"{runner.name} is retreating {d.ToString()}");
            int x = runner.location.x;
            int y = runner.location.y;
            //prevent null reference exception
            if (animalZones == null || animalZones.Count == 0)
            {
                return false;
            }
            int numCellsY = animalZones.Count;
            int numCellsX = animalZones[0].Count;
            switch (d)
            {
                case Direction.up:
                    /* The logic below uses the "short circuit" property of Boolean &&.
                     * If we were to check our list using an out-of-range index, we would
                     * get an error, but since we first check if the direction that we're modifying is
                     * within the ranges of our lists, if that check is false, then the second half of
                     * the && is not evaluated, thus saving us from any exceptions being thrown.
                     */
                    if (y > 0 && animalZones[y - 1][x].occupant == null)
                    {
                        animalZones[y - 1][x].occupant = runner;
                        animalZones[y][x].occupant = null;
                        return true; // retreat was successful
                    }
                    return false; // retreat was not successful
                /* Note that in these four cases, in our conditional logic we check
                 * for the animal having one square between itself and the edge that it is
                 * trying to run to. For example,in the above case, we check that y is greater
                 * than 0, even though 0 is a valid spot on the list. This is because when moving
                 * up, the animal would need to go from row 1 to row 0. Attempting to go from row 0
                 * to row -1 would cause a runtime error. This is a slightly different way of testing
                 * if 
                 */
                case Direction.down:
                    if (y < numCellsY - 1 && animalZones[y + 1][x].occupant == null)
                    {
                        animalZones[y + 1][x].occupant = runner;
                        animalZones[y][x].occupant = null;
                        return true;
                    }
                    return false;
                case Direction.left:
                    if (x > 0 && animalZones[y][x - 1].occupant == null)
                    {
                        animalZones[y][x - 1].occupant = runner;
                        animalZones[y][x].occupant = null;
                        return true;
                    }
                    return false;
                case Direction.right:
                    if (x < numCellsX - 1 && animalZones[y][x + 1].occupant == null)
                    {
                        animalZones[y][x + 1].occupant = runner;
                        animalZones[y][x].occupant = null;
                        return true;
                    }
                    return false;
            }
            return false; // fallback
        }

        

        /* Flee method
         * need input list of animalZones and List of HuntAnimal 
         * call by Predator 
         * return bool
         */
        public bool BaseFlee(List<List<Zone>> animalZones, List<string> animalName)
        {
            if (Seek(location.x, location.y, animalZones, Direction.up, animalName))
            {
                if (Retreat(this, Direction.down, animalZones)) return true;
            }
            if (Seek(location.x, location.y, animalZones, Direction.down, animalName))
            {
                if (Retreat(this, Direction.up, animalZones)) return true;
            }
            if (Seek(location.x, location.y, animalZones, Direction.left, animalName))
            {
                if (Retreat(this, Direction.right, animalZones)) return true;
            }
            if (Seek(location.x, location.y, animalZones, Direction.right, animalName))
            {
                if (Retreat(this, Direction.left, animalZones)) return true;
            }
            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZooManager
{
    interface IPredator
    {
        void Hunt(List<List<Zone>> animalZones);
       
    }

}

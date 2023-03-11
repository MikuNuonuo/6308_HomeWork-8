using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZooManager
{
    interface IPrey
    {
        bool Flee(List<List<Zone>> animalZones);
     
    }
}

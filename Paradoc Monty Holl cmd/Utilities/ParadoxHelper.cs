using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradoc_Monty_Holl_cmd.Utilities
{
    public static class ParadoxHelper
    {
        public static int RadnomSelectDoor
        {
            get
            {
                System.Threading.Thread.Sleep(3);
                var divider = new Random().Next(2, 3);
                if ((new Random().Next(0, 1000) % divider) > 0)
                {
                    return 0;
                }
                return divider;
            }
            
        }

        public static int RadnomSelectDoorStardard
        {
            get
            {
                System.Threading.Thread.Sleep(3);
                return new Random().Next(0, 2);
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradoc_Monty_Holl_cmd.Entities
{
    public class Door
    {
        public bool Prize { get; private set; } = false;
        public int Name { get; set; } = -1;

        public bool IsSelected { get; set; } = false;
        public Door(bool isPrize, int name)
        {
            Prize = isPrize;
            Name = name;
        }

    }
}

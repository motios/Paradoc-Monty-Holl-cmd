using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradoc_Monty_Holl_cmd.Entities
{
    public class Result
    {
        public bool GameWithChangeDoor { get; set; } = false;
        public bool IsWin { get; set; } = false;
        public int GameNumber { get; set; } = 0;

        public Result() { }

        public string PrintResult
        {
            get
            {
                return $"{GameNumber},game win: {IsWin},game with change door: {GameWithChangeDoor}\r\n";
            }
        }


    }
}

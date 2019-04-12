using Paradoc_Monty_Holl_cmd.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Paradoc_Monty_Holl_cmd.Entities
{
    public class GameSpace
    {
        Room room;
        private bool gamerIsNeedToChangeRoom { get; set; } = false;
        public GameSpace(bool isNeedToChangeRoom)
        {
            Console.WriteLine("start game---------");
            room = new Room(isNeedToChangeRoom);
            gamerIsNeedToChangeRoom = isNeedToChangeRoom;
        }

        public bool Start()
        {
            //set door
            //var doorIndx = ParadoxHelper.RadnomSelectDoor;
            //while (!room.DoorSelected(doorIndx))
            //{
            //    doorIndx = ParadoxHelper.RadnomSelectDoor;
            //}
            var doorIndx = ParadoxHelper.RadnomSelectDoorStardard;
            room.DoorSelected(doorIndx);
            var selectedDoor = room.IsDoorWithPrize(doorIndx);
            //remove one door without prize and not selected
            room.ContinueGame();
            var result = room.Result(doorIndx, gamerIsNeedToChangeRoom);
            if (result)
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
            }
            Console.WriteLine($"win game: {result}\r\nend game---------\r\n");
            Console.ResetColor();
            return result;
        }

    }
}

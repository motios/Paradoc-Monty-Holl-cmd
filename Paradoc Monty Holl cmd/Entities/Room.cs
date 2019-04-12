using Paradoc_Monty_Holl_cmd.Utilities;
using System;

//using System.Threading;


namespace Paradoc_Monty_Holl_cmd.Entities
{
    public class Room
    {
        private bool gamerIsNeedChangeRoom;
        private Door[] doors;
        private Game gameModel;


        public Room(bool isNeedChangeRoom)
        {
            gameModel = new Game();
            gamerIsNeedChangeRoom = isNeedChangeRoom;
            gameModel.is_need_to_change_room = gamerIsNeedChangeRoom;
            gameModel.game_start_time= DateTime.Now;
            doors = new Door[3];
            setDoors();
        }
        

        //randomize 1 door for prize
        //set 2 continue doors(1 with prize, 1 without)
        private void setDoors()
        {

            var random = ParadoxHelper.RadnomSelectDoor;
            gameModel.door_with_prize= random;
            Console.WriteLine($"set doors,  door with prize {random}");
            for (var i = 0; i < doors.Length; i++)
            {
                doors[i] = random == i ? new Door(true, i) : new Door(false, i);
            }

            int[] continueDoorsIndx = new int[2];
            var val = 0;
            for (var i = 0; i < doors.Length; i++)
            {
                if (random != i)
                {
                    continueDoorsIndx[val] = i;
                    val++;
                }
            }
        }

        public bool DoorSelected(int indx)
        {
            if (doors[indx] != null)
            {
                gameModel.door_selected_by_gamer_start = indx;
                doors[indx].IsSelected = true;
                Console.WriteLine($"gamer select door: {indx}");
                return true;
            }
            return false;
            
        }
        public bool IsDoorWithPrize(int indx)
        {
            return doors[indx].Prize;
        }

        // remove(set null) door without prize - not door selected
        public void ContinueGame()
        {
            int removeIdx = getDoorToRemove();
            if(removeIdx < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error!!! Error!!! Error!!!");
                Console.ResetColor();
            }
            doors[removeIdx] = null;
            Console.WriteLine($"remove door {removeIdx}");
            changeSelect();
        }

        private int getDoorToRemove()
        {
            for(var i=0; i < doors.Length; i++)
            {
                if(!doors[i].IsSelected && !doors[i].Prize)
                {
                    return i;
                }
            }
            return -1;
        }

        private void changeSelect()
        {
            
            if (gamerIsNeedChangeRoom)
            {
                
                Console.WriteLine("change gamer select");
                try
                {
                    for (int i = 0; i < doors.Length; i++)
                    {
                        if (doors[i] != null)
                        {
                            doors[i].IsSelected = !doors[i].IsSelected;
                            if (doors[i].IsSelected)
                            {
                                gameModel.door_selected_by_gamer_final = i;
                            }
                        }
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
            }
        }
        public bool Result(int val, bool anotherDoor)
        {
            if (!anotherDoor)
            {
                gameModel.game_winner = doors[val].Prize;
                saveResultInDB();
                return doors[val].Prize;
            }
            else
            {
                for (int i = 0; i < doors.Length; i++)
                {
                    if (i != val && doors[i] != null)
                    {
                        gameModel.game_winner = doors[i].Prize;
                        saveResultInDB();
                        return doors[i].Prize;
                    }
                }
            }
            saveResultInDB();
            return false;
        }

        private void saveResultInDB()
        {
            gameModel.game_end_time = DateTime.Now;

            using (Model1 model = new Model1())
            {
                model.Games.Add(gameModel);
                model.SaveChanges();
            }
        }
    }
}

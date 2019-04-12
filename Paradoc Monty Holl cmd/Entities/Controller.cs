using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradoc_Monty_Holl_cmd.Entities
{
    public class Controller
    {
        private List<Result> results; 
        public Controller(int countOfGames, bool automat,bool isNeedToChangeRoom)
        {
            
            results = new List<Result>();
            startGame(countOfGames, automat, isNeedToChangeRoom);
            var winGame = 0;
            var winGameChangeRoom = 0;
            var winGameNotChangeRoom = 0;
            foreach (var result in results)
            {
                if (result.IsWin)
                {

                    winGame++;
                    winGameNotChangeRoom = result.GameWithChangeDoor == false ? winGameNotChangeRoom + 1 : winGameNotChangeRoom;
                    winGameChangeRoom = result.GameWithChangeDoor == true ? winGameChangeRoom + 1 : winGameChangeRoom;
                }
                
                
                Console.WriteLine(result.PrintResult);
            }
            var totalGames = automat == true ? countOfGames * 2 : countOfGames;
            Console.WriteLine($"total/win games {totalGames}/{winGame }, {(double)winGame/ totalGames * 100}%");
            Console.WriteLine($"win games with room change {winGameChangeRoom }, {(double)winGameChangeRoom / totalGames * 100}%");
            Console.WriteLine($"win games with room not change {winGameNotChangeRoom }, {(double)winGameNotChangeRoom / totalGames * 100}%");
            Console.ReadKey();
        }

        private void startGame(int countOfGames, bool automat, bool isNeedToChangeRoom)
        {

            if (automat)
            {
                playGame(countOfGames, isNeedToChangeRoom);
                playGame(countOfGames, !isNeedToChangeRoom);
            }

            else
            {
                playGame(countOfGames, isNeedToChangeRoom);
            }
        }


        private void playGame(int count, bool isNeedToChangeRoom)
        {

            for (int i = 0; i < count; i++)
            {
                results.Add( new Result { GameNumber = i, GameWithChangeDoor = isNeedToChangeRoom, IsWin = new GameSpace(isNeedToChangeRoom).Start() });
            }
        }

       
    }
}

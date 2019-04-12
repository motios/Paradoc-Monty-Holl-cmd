using Paradoc_Monty_Holl_cmd.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradoc_Monty_Holl_cmd
{
    class Program
    {
        static void Main(string[] args)
        {
            //count of games: if automat is true-> count for gamer not changes door games and count for gamer changes door games
            //count of games: if automat is false->  count for selected status for gamer door games
            //automat is true - > controller game some  count of games for changes door and for not changes door
            //automat is false - > controller game only  seleted status of game 
            //isNeedToChangeRoom is false- > gamer not changed door in game
            //isNeedToChangeRoom is true- > gamer changed door in game

            //Console.BackgroundColor = ConsoleColor.Blue;
            //Console.ForegroundColor = ConsoleColor.Yellow;
            //Console.Write("Yello. ");
            //Console.ResetColor();
            //Console.BackgroundColor = ConsoleColor.Gray;
            //Console.ForegroundColor = ConsoleColor.Red;
            //Console.Write("Red. ");
            //Console.ResetColor();
          //  Model1 model1 = new Model1();
          //  model1.Games.Add(new Game() { game_winner = false, door_selected_by_gamer_final = 3, door_selected_by_gamer_start = 1, door_with_prize = 2, is_need_to_change_room = true, notes = "test",game_start_time=DateTime.Now });
           //  model1.SaveChanges();
            //var result = model1.Games.ToList<Game>();
            //result[0].notes = "is changed";
            //model1.SaveChanges();
          //  var connectionStr = ConfigurationManager.ConnectionStrings["game"].ConnectionString;
           
            var countOfGames = 100;
            var automat = false;
            var isNeedToChangeRoom = true;
            var controller = new Controller(countOfGames, automat,isNeedToChangeRoom);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
  class Program
  {
    static void Main(string[] args)
    {
      // ask user how many human players
      Console.WriteLine("Select your game mode (Type in 'single player' or 'multiplayer'):");
      // will send the answer through to the Game constructor
      Game rpsls = new Game(Console.ReadLine());
      rpsls.SetupGame();
      rpsls.StartGame();
    }
  }
}

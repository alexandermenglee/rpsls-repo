using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
  public class HumanPlayer : Player
  {
    public HumanPlayer(string name)
    {
      this.name = name;
    }

    // grabs user input and saves it as their gesture
    public override void GetGesture(List<string> gestures)
    {
      // displays options from list bc user story said so
      Console.WriteLine("\nChoose your weapon!");
      for(int i = 0; i < gestures.Count; i++)
      {
        Console.WriteLine($"{i} {gestures[i]}");
      }

      this.gesture = Console.ReadLine();
      this.gesture = this.gesture.ToLower().Trim();
    }
  }
}

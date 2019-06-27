using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
  public abstract class Player
  {
    public string gesture;
    public int wins;

    public Player()
    {
      wins = 0;
    }

    public abstract void GetGesture(List<string> gestures);
 
    public void ShowGesture()
    {
      Console.WriteLine($"{this} chose {this.gesture}");
    }

    public bool CheckWins()
    {
      if(this.wins == 2)
      {
        Console.WriteLine($"{this} wins!");
        return true;
      }
      return false;
    }

     

  }
}

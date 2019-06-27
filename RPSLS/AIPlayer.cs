using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
  public class AIPlayer : Player
  {
    
    public AIPlayer()
    {

    }
    public override void GetGesture(List<string> gestures)
    {
      int randomGesture;
      Random randomNumber = new Random();

      randomGesture = randomNumber.Next(0, gestures.Count);
      gesture = gestures[randomGesture];
    }
  }
}

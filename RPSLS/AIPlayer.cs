using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
  public class AIPlayer : Player
  {
    int randomGesture;
    public AIPlayer()
    {

    }
    public override void GetGesture(List<string> gestures)
    {
      // use random method to generate a random gesture and set it equal to this.gesture
      // random number created to grab gesture by index
      Random randomNumber = new Random();
      this.randomGesture = randomNumber.Next(0, gestures.Count);
      this.gesture = gestures[this.randomGesture];
    }
  }
}

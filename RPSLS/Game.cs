using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
  class Game
  {
    // initialize gestures array
    List<string> gestures = new List<string>() {"rock", "paper", "scissors", "spock", "lizard"};
    string players;
    Player player1;
    Player player2;

    public Game(string players)
    {
      this.players = players;
    }

    public void SetupGame()
    {
      if (players == "single player")
      {
        // create one human player and one ai player
        this.player1 = new HumanPlayer();
        this.player2 = new AIPlayer();
      }
      else if (players == "multiplayer")
      {
        // create two human players
        this.player1 = new HumanPlayer();
        this.player2 = new HumanPlayer();
      }
    }
    public void StartGame()
    {
      /*Console.WriteLine("Welcome to Rock Paper Scissors Lizard Spock! \n The rules are simple: \n Rock crushes Scissors \n Scissors cuts Paper \n Paper covers Rock \n Rock crushes Lizard \n Lizard poisons Spock \n Spock smashes Scissors \n Scissors decapitates Lizard \n Lizard eats Paper \n Paper disproves Spock \n Spock vaporizes Rock ");
      */

      while (this.player1.wins < 2 && this.player2.wins < 2)
      {
        player1.GetGesture(gestures);
        player2.GetGesture(gestures);
        ShowDown();
        Console.WriteLine($"Player 1 wins: {player1.wins}");
        Console.WriteLine($"Player 2 wins: {player2.wins}");
        Console.WriteLine("END OF ROUND");
      }
      Console.WriteLine("GAME OVER");
      Console.ReadLine();

/*      for (int i = 0; i < 4; i++)
      {
        player1.GetGesture(gestures);
        player2.GetGesture(gestures);
        ShowDown();
        if (player1.CheckWins() || player2.CheckWins())
        {
          Console.ReadLine();
          break;
        }
        Console.WriteLine($"Player 1 wins: {player1.wins}");
        Console.WriteLine($"Player 2 wins: {player2.wins}");
        Console.WriteLine("END OF ROUND");
      }*/
    }

    public void ShowDown()
    {
      /* 
       * Rock crushes Scissors x
       * Scissors cuts Paper x
       * Paper covers Rock x
       * Rock crushes Lizard x
       * Lizard poisons Spock x
       * Spock smashes Scissors x
       * Scissors decapitates Lizard x
       * Lizard eats Paper x
       * Paper disproves Spock x
       * Spock vaporizes Rock x 
       */ 

       // rock > scissors, lizard
       // scissors > paper, lizard
       // paper > rock, spock
       // lizard > spock, paper
       // spock > scissors, rock

      // if i choose rock, i can only beat scissors and lizard else i lose

      player1.ShowGesture();
      player2.ShowGesture();

      if (player1.gesture == player2.gesture)
      {
        Console.WriteLine("Tie");
        Console.ReadLine();
      }
      else if(player1.gesture == "rock" && player2.gesture == "scissors" || player1.gesture == "rock" && player2.gesture == "lizard")
      {
        Console.WriteLine("Player 1 wins!");
        player1.wins++;
      } 
      else if(player1.gesture == "scissors" && player2.gesture == "paper" || player1.gesture == "scissors" && player2.gesture == "lizard")
      {
        Console.WriteLine("Player 1 wins!");
        player1.wins++;
      }
      else if(player1.gesture == "paper" && player2.gesture == "rock" || player1.gesture == "paper" && player2.gesture == "spock")
      {
        Console.WriteLine("Player 1 Wins!");
        player1.wins++;
      }
      else if (player1.gesture == "lizard" && player2.gesture == "spock" || player1.gesture == "lizard" && player2.gesture == "paper")
      {
        Console.WriteLine("Player 1 Wins!");
        player1.wins++;
      }
      else if (player1.gesture == "spock" && player2.gesture == "scissors" || player1.gesture == "spock" && player2.gesture == "rock")
      {
        Console.WriteLine("Player 1 wins!");
        player1.wins++;
      }
      else
      {
        Console.WriteLine("Player 2 wins!");
        player2.wins++;
      }
    }
  }
}

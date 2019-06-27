using System;
using System.Collections.Generic;

namespace RPSLS
{
  class Game
  {
    List<string> gestures;
    string players;
    Player player1;
    Player player2;

    public Game()
    {
      this.gestures = new List<string>() { "rock", "paper", "scissors", "spock", "lizard" };
    }    
    public string DisplayRules()
    {
      return "Rock crushes Scissors\n" +
             "Scissors cuts Paper\n" +
             "Paper covers Rock\n" +
             "Rock crushes Lizard\n" +
             "Lizard poisons Spock\n" +
             "Spock smashes Scissors\n" +
             "Scissors decapitates Lizard\n" +
             "Lizard eats Paper\n" +
             "Paper disproves Spock\n" +
             "Spock vaporizes Rock\n\n";
    }

    public void SetupGame()
    {
      Console.WriteLine(DisplayRules());

      Console.WriteLine("Select your game mode (Type in 'single player' or 'multiplayer'):");
      this.players = Console.ReadLine();
      Console.WriteLine("\n");

      if (this.players.ToLower().Trim() == "single player")
      {
        // create one human player and one ai player
        this.player1 = new HumanPlayer();
        this.player2 = new AIPlayer();
      }
      else if (this.players.ToLower().Trim() == "multiplayer")
      {
        // create two human players
        this.player1 = new HumanPlayer();
        this.player2 = new HumanPlayer();
      }
      else
      {
        Console.WriteLine("Please enter in either 'single player' or 'multiplayer'.");
        SetupGame();
      }
    }

    public void CheckGesture(Player player)
    {
      if (!this.gestures.Contains(player.gesture))
      {
        Console.WriteLine("\n Please enter your gesture correctly. \n");
        player1.GetGesture(this.gestures);
      }
    }
    public void StartGame()
    {
      while (this.player1.wins < 2 && this.player2.wins < 2)
      {
        Console.WriteLine("START OF ROUND");
        player1.GetGesture(gestures);
        CheckGesture(player1);
        player2.GetGesture(gestures);
        CheckGesture(player2);
        ShowDown();
        Console.WriteLine($"Player 1 wins: {player1.wins}");
        Console.WriteLine($"Player 2 wins: {player2.wins}\n");
        Console.WriteLine("END OF ROUND\n\n");
      }
      Console.WriteLine("GAME OVER");
      Console.ReadLine();
    }

    public void ShowDown()
    {
      Console.WriteLine("\n");
      player1.ShowGesture();
      player2.ShowGesture();

      if (player1.gesture == player2.gesture)
      {
        Console.WriteLine("It's a tie!\n");
      }
      else if (player1.gesture == "rock" && player2.gesture == "scissors" || player1.gesture == "rock" && player2.gesture == "lizard")
      {
        Console.WriteLine("\nPlayer 1 is the winner!\n");
        player1.wins++;
      }
      else if (player1.gesture == "scissors" && player2.gesture == "paper" || player1.gesture == "scissors" && player2.gesture == "lizard")
      {
        Console.WriteLine("\nPlayer 1 is the winner!\n");
        player1.wins++;
      }
      else if (player1.gesture == "paper" && player2.gesture == "rock" || player1.gesture == "paper" && player2.gesture == "spock")
      {
        Console.WriteLine("\nPlayer 1 is the winner!\n");
        player1.wins++;
      }
      else if (player1.gesture == "lizard" && player2.gesture == "spock" || player1.gesture == "lizard" && player2.gesture == "paper")
      {
        Console.WriteLine("\nPlayer 1 is the winner!\n");
        player1.wins++;
      }
      else if (player1.gesture == "spock" && player2.gesture == "scissors" || player1.gesture == "spock" && player2.gesture == "rock")
      {
        Console.WriteLine("\nPlayer 1 is the winner!\n");
        player1.wins++;
      }
      else
      {
        Console.WriteLine("\nPlayer 2 is the winner!\n");
        player2.wins++;
      }
    }
  }
}

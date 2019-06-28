using System;
using System.Collections.Generic;

namespace RPSLS
{
  class Game
  {
    List<string> gestures;

    Player player1;
    Player player2;

    public Game()
    {
      gestures = new List<string>() { "rock", "paper", "scissors", "spock", "lizard" };
    }    
    public string DisplayRules()
    {
      return "RULES:\n" + 
             "1. Rock crushes Scissors\n" +
             "2. Scissors cuts Paper\n" +
             "3. Paper covers Rock\n" +
             "4. Rock crushes Lizard\n" +
             "6. Lizard poisons Spock\n" +
             "7. Spock smashes Scissors\n" +
             "8. Scissors decapitates Lizard\n" +
             "9. Lizard eats Paper\n" +
             "10. Paper disproves Spock\n" +
             "11. Spock vaporizes Rock\n\n";
    }

    public void SetupGame()
    {
      string gameMode;
      Console.WriteLine(DisplayRules());

      Console.WriteLine("Select your game mode (Type in 'single player' or 'multiplayer'):");
      gameMode = Console.ReadLine();
      Console.WriteLine("\n");

      if (gameMode.ToLower().Trim() == "single player")
      {
        // create one human player and one ai player
        string name;
        Console.WriteLine("Enter in a name: ");
        name = Console.ReadLine();
        Console.WriteLine("\n");
        this.player1 = new HumanPlayer(name);
        this.player2 = new AIPlayer();
      }
      else if (gameMode.ToLower().Trim() == "multiplayer")
      {
        string name1;
        string name2;
        Console.WriteLine("Enter in player 1's name: ");
        name1 = Console.ReadLine();
        Console.WriteLine("\n");
        Console.WriteLine("Enter in player 2's name: ");
        name2 = Console.ReadLine();
        Console.WriteLine("\n");
        // create two human players
        this.player1 = new HumanPlayer(name1);
        this.player2 = new HumanPlayer(name2);
      }
      else
      {
        Console.WriteLine("Please enter in either 'single player' or 'multiplayer'.");
        SetupGame();
      }
    }

    private void CheckGesture(Player player)
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
        Console.WriteLine("\nSTART OF ROUND\n");
        Console.WriteLine($"{player1.name}'s turn!");
        player1.GetGesture(gestures);
        CheckGesture(player1);
        Console.WriteLine($"{player2.name}'s turn!");
        player2.GetGesture(gestures);
        CheckGesture(player2);
        ShowDown();
        Console.WriteLine($"{player1.name}'s total wins: {player1.wins}");
        Console.WriteLine($"{player2.name}'s total wins: {player2.wins}\n");
        Console.WriteLine("END OF ROUND\n\n");
      }
      Console.WriteLine("GAME OVER\n");
      PlayAgain();
    }

    private void PlayAgain()
    {
      string input;

      Console.WriteLine("Would you like to play again? (Enter 'yes' or 'no')");
      input = Console.ReadLine();
      input = input.ToLower().Trim();

      if (input == "yes") {
        // reset player wins to 0
        // call start game
        player1.wins = 0;
        player2.wins = 0;
        StartGame();
      }
      else if(input == "no")
      {
        Console.WriteLine("\nkbai.");
        Console.ReadLine();
        return;
      }
      else
      {
        Console.WriteLine("Please enter 'yes' or 'no'");
        PlayAgain();
      }
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
        Console.WriteLine($"\n {player1.name} is the winner!\n");
        player1.wins++;
      }
      else if (player1.gesture == "scissors" && player2.gesture == "paper" || player1.gesture == "scissors" && player2.gesture == "lizard")
      {
        Console.WriteLine($"\n{player1.name} is the winner!\n");
        player1.wins++;
      }
      else if (player1.gesture == "paper" && player2.gesture == "rock" || player1.gesture == "paper" && player2.gesture == "spock")
      {
        Console.WriteLine($"\n{player1.name} is the winner!\n");
        player1.wins++;
      }
      else if (player1.gesture == "lizard" && player2.gesture == "spock" || player1.gesture == "lizard" && player2.gesture == "paper")
      {
        Console.WriteLine($"\n{player1.name} is the winner!\n");
        player1.wins++;
      }
      else if (player1.gesture == "spock" && player2.gesture == "scissors" || player1.gesture == "spock" && player2.gesture == "rock")
      {
        Console.WriteLine($"\n{player1.name} is the winner!\n");
        player1.wins++;
      }
      else
      {
        Console.WriteLine($"\n{player2.name} is the winner!\n");
        player2.wins++;
      }
    }
  }
}

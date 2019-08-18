using System;
using System.Threading;
using CastleGrimtol.Project.Interfaces;
using CastleGrimtol.Project.Models;

namespace CastleGrimtol.Project
{
  public class GameService : IGameService
  {
    public IRoom CurrentRoom { get; set; }
    public Player CurrentPlayer { get; set; }

    private bool Playing { get; set; } = true;


    public void Reset()
    {

    }

    public void Setup()
    {
      Console.Clear();

      Room Start = new Room("Starting Room", "This is where the game should start");
      Room SecondRoom = new Room("Second Room", "This should be the SECOND room");
      Room ThirdRoom = new Room("Third Room", "This This should be the THIRD room");
      Room End = new Room("Ending Room", "This is where the game should end");

      Item BigKey = new Item("Big Key", "This should unlock something");

      Start.Exits.Add("east", SecondRoom);
      SecondRoom.Exits.Add("west", Start);
      SecondRoom.Exits.Add("north", ThirdRoom);
      ThirdRoom.Exits.Add("south", SecondRoom);
      ThirdRoom.Exits.Add("west", End);
      End.Exits.Add("east", ThirdRoom);

      SecondRoom.Items.Add(BigKey);


      #region 
      //   Room Kitchen = new Room("Kitchen", "This is where the game should start");
      //   Room Microwave = new Room("Microwave", "The player should shrink here");
      //   Room KitchenSupplyDrawer = new Room("Kitchen Supply Drawer", "this is where you find the tin foil");
      //   Room Pantry = new Room("Pantry", "this is where you get food");
      //   Room Sink = new Room("Sink", "this is how you get back to the counter");
      //   Room Microwave2 = new Room("Microwave", "this is where you restore the power");
      //   Room Kitchen2 = new Room("Microwave", "this is where you win");

      // Kitchen(Start) >>> Microwave >>> TinFoil >>> Pantry >>> Sink >>> Microwave2 >>> Kitchen2
      //   Kitchen.Exits.Add("forward", Microwave);
      //   Microwave.Exits.Add("forward", KitchenSupplyDrawer);
      //   KitchenSupplyDrawer.Exits.Add("")
      #endregion

      CurrentRoom = Start;

    }

    public void StartGame()
    {
      Setup();
      string greet = $"Welcome to the Adventure Game";
      foreach (char letter in greet)
      {
        Console.Write(letter);
        Thread.Sleep(100);

      }
      Thread.Sleep(500);
      Console.WriteLine("");
      Console.WriteLine("");


      while (Playing)
      {

        Console.WriteLine("What do you want to do?");
        Console.WriteLine("Type \"Help\" for a list of commands");
        Console.WriteLine("");

        string[] input = Console.ReadLine().ToLower().Split(' ');
        Console.Clear();
        string command = input[0];
        string option = "";
        if (input.Length > 1)
        {
          option = input[1];
        }

        switch (command)
        {
          case "go":
            Go(option);
            break;
          case "look":
            Look();
            break;
          case "help":
            Help();
            break;
          case "quit":
            Playing = false;
            break;
          default:
            Console.WriteLine("UNKNOWN COMMAND");
            break;
        }
      }
    }

    public void GetUserInput()
    {

    }

    public void Quit()
    {

    }

    public void Help()
    {
      Console.WriteLine("Enter \"Go\" and a directions such as: \"North\" \"South\" \"East\" or \"West\"");
      Console.WriteLine("Enter \"Look\" to see what is in the room.");
      Console.WriteLine("Enter \"Quit\" to exit the game.");
      Console.WriteLine("");
    }

    public void Go(string direction)
    {
      CurrentRoom = CurrentRoom.Go(direction);
    }

    public void TakeItem(string itemName)
    {

    }

    public void UseItem(string itemName)
    {

    }

    public void Inventory()
    {

    }

    public void Look()
    {

      string lookName = $"You are in {CurrentRoom.Name}";
      foreach (char letter in lookName)
      {
        Console.Write(letter);
        Thread.Sleep(50);
      }
      Console.WriteLine("");
      Console.WriteLine("");

      string lookDescription = ($"{CurrentRoom.Description}");
      foreach (char letter in lookDescription)
      {
        Console.Write(letter);
        Thread.Sleep(50);
      }
      Console.WriteLine("");
      Console.WriteLine("");
    }

  }
}
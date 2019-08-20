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
      StartGame();
    }

    public void Setup()
    {
      Console.Clear();


      // Rooms
      Room Microwave = new Room("Microwave", "inside the microwave.", @"Confused and miniature, you're at a loss for words. 
Your hands are shaking as you stand there in disbelief as 
you've just been shrunk to the size of a salt shaker.", false, "");

      Room Drawer = new Room("Kitchen Drawers", "at the kitchen storage drawer.", @"After heading across the desolate plains of the kitchen floor, 
you stumble upon four drawers stacked upon each other containing 
various kitchen items in each one. 

Your memory is hazy in regard to the contents within each one.

As you climb up one by one, you see that the top drawer is 
slightly cracked open. 

Just wide enough for you to squeeze through. With sandwich bags and 
saran wrap obstructing your view, it's difficult to tell what's in here.", false, "");

      Room Pantry = new Room("Pantry", "at the pantry.", @"After a few hours of fighting off flies and spiders with 
the reinforced foil you picked up, you squeeze underneath the doorway. 

It's pitch black and your stomach is grumbling.", true, "You have a full belly and can continue on!");

      Room KitchenFloor = new Room("Desolate Kitchen Plains", "at the desolate kitchen floor plains.", @"There's not much for you to do here and you need to keep moving. 

The weight of the tin foil underneath your arm is 
getting heavier and heavier. 

The after taste of kibbles are causing you to become 
nauseous and sweat is collecting around your eyes 
limiting your vision. 

As the shadows grow across the kitchen floor plains, 
the sunlight begins to fade from the windows.", false, "");

      Room Microwave2 = new Room("Microwave", "at the microwave again.", @"After a grueling trip across the plains you climb to 
the top of the kitchen counter. 

You make your way to the back side of the microwave and 
observe that it's charred with clear evidence of a short circuit. 

One of the wires has split, but appears to be repairable.", true, "With the foil in place and the microwave set to 5 seconds, you think to yourself, \"Hmmmm... I should probably hit the start button and \"go forward\" (hint hint) right as the timer hits zero.\"");

      Room Kitchen = new Room("Kitchen", "at the end of the game!", @"ZZZzzzzAAAaaaAAAAPPPPPpppPPPPP!!! The microwave hits zero and 
your body is restored to its original size! You have survived 
this journey successfully! 

Congratulations on your expedition throughout the kitchen. 

You might want to think about getting your microwave replaced though. 

Anyways, CONGRATS!", false, "");

      Item Foil = new Item("foil", "There's something shiny sitting in the back corner of the drawer.");
      Item Food = new Item("food", @"
The horid smell of dog food kibbles fill your nostrils as 
you venture deeper into the pantry. Desperate times call 
for desperate measures...");

      // Exits
      Microwave.Exits.Add("east", Drawer);
      Drawer.Exits.Add("west", Microwave);
      Drawer.Exits.Add("north", Pantry);
      Pantry.Exits.Add("south", Drawer);
      Pantry.Exits.Add("west", KitchenFloor);
      KitchenFloor.Exits.Add("east", Pantry);
      KitchenFloor.Exits.Add("south", Microwave2);
      Microwave2.Exits.Add("north", KitchenFloor);
      Microwave2.Exits.Add("forward", Kitchen);

      // Items in room
      Drawer.Items.Add(Foil);
      Pantry.Items.Add(Food);


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

      CurrentRoom = Microwave;
      // CurrentPlayer.PlayerName = "Adventurer";

    }

    public void StartGame()
    {
      Console.Clear();

      string greet = $"Welcome to this... uhh... adventure? situation? problem? game?";
      foreach (char letter in greet)
      {
        Console.Write(letter);
        Thread.Sleep(65);
      }
      Thread.Sleep(500);
      Console.WriteLine("");
      Console.WriteLine("");

      Console.Write("Just enter a name already: ");
      string name = Console.ReadLine();
      CurrentPlayer = new Player(name);

      Setup();
      Console.Clear();
      // string name = CurrentPlayer.PlayerName;


      // if (CurrentPlayer.PlayerName == name)
      // {
      //   Console.Write("Please Enter a name for you character: ");
      //   CurrentPlayer.PlayerName = Console.ReadLine().ToUpper();
      //   CurrentPlayer.PlayerName = name;
      // }
      // else
      // {
      //   Setup();
      // }


      string introduction = ($@"It's a beautiful day in Boise, Idaho.

The temperature is around 80 degrees and you've been stuck inside 
cleaning all day in preparation for guests to come over for dinner tonight.

Since you'll be staying home for the rest of the day, you decide to take your 
dog out for a quick walk around the park to get him and yourself some exercise 
before the festivities tonight.

After getting back, you realize it's only noon. You decide it would be wise 
to have a quick meal before you start cooking and setting up. 
The leftover Mongolian BBQ sitting in your fridge appears to be the best and 
quickest option.

Looking into the fridge you grab the leftover Mongolian BBQ and a bowl from the cupboard. 
The chunk of noodles are plopped into a bowl maintaining the shape of the to-go box.

Rather than eating this cold brick of starch like a savage, 
you decide to go up to the microwave and reheat the noodles.
");
      foreach (char letter in introduction)
      {
        Console.Write(letter);
        Thread.Sleep(30);

      }
      Thread.Sleep(5000);
      Console.WriteLine("");
      Console.WriteLine("");


      string introduction2 = ($@"
ZZZrrrRRRRmmmMMMMMMM!!! CRACK! PEW! PEW! PEW!!!
");
      foreach (char letter in introduction2)
      {
        Console.Write(letter);
        Thread.Sleep(100);
      }
      Thread.Sleep(500);
      Console.WriteLine("");
      Console.WriteLine("");

      string introduction3 = ($@"
The smell of smoke and mongolian noodles surrounds you as 
you struggle to comprehend what just happened.
");
      foreach (char letter in introduction3)
      {
        Console.Write(letter);
        Thread.Sleep(40);
      }
      Thread.Sleep(500);
      Console.WriteLine("");
      Console.WriteLine("");


      while (Playing)
      {
        if (CurrentRoom.Location == "Kitchen")
        {
          Look();
        }

        Console.WriteLine($"Current Location: {CurrentRoom.Location}");
        Console.WriteLine("");
        Console.WriteLine($"What do you want to do {name}?");
        Console.WriteLine("Type \"Help\" for a list of commands or \"Look\" to observe your surroundings.");
        Console.WriteLine("");
        GetUserInput();
      }
    }

    public void GetUserInput()
    {
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
        case "stash":
          Inventory();
          break;
        case "take":
          TakeItem(option);
          break;
        case "use":
          UseItem(option);
          break;
        case "help":
          Help();
          break;
        case "quit":
          Quit();
          break;
        case "reset":
          Reset();
          break;
        default:
          Console.WriteLine("UNKNOWN COMMAND");
          break;
      }
    }

    public void Quit()
    {
      Playing = false;
      string farewell = "QUITTING...";
      foreach (char letter in farewell)
      {
        Console.Write(letter);
        Thread.Sleep(25);
      }
      Thread.Sleep(1000);

      //NOTE Make sure that you implement a way to lose the game

    }

    public void Help()
    {
      Console.WriteLine("Enter the command \"Go\" + a directions such as: \"North\" \"South\" \"East\" or \"West\". (e.g. \"go north\"");
      Console.WriteLine("");
      Console.WriteLine("Enter \"Look\" to see what is in the room.");
      Console.WriteLine("");
      Console.WriteLine("Enter \"Take\" and the name of the item.");
      Console.WriteLine("");
      Console.WriteLine("Enter \"Use\" and the name of the item");
      Console.WriteLine("");
      Console.WriteLine("Enter \"Stash\" to see a list of your inventory.");
      Console.WriteLine("");
      Console.WriteLine("Enter \"Quit\" to exit the game.");
      Console.WriteLine("");
      Console.WriteLine("Enter \"Reset\" to start from the beginning.");
      Console.WriteLine("");
      Console.WriteLine("");
      Console.WriteLine("");
      Console.WriteLine("");
      Console.WriteLine("");
    }


    //TODO FIXED!!! This is where you left off
    public void Go(string direction)
    {
      if (CurrentRoom.Location == "Kitchen Drawers" && direction == "north" && CurrentPlayer.Inventory.Count == 0)
      {
        Console.Write("Ooof. You didn't have the proper tools to fight your way to the pantry...");
        string defeat = @" You have died.";
        foreach (char letter in defeat)
        {
          Console.Write(letter);
          Thread.Sleep(150);
        }
        Thread.Sleep(5000);
        Console.WriteLine("");
        Quit();
      }
      else if (CurrentRoom.IsLocked == true)
      {
        Console.WriteLine("You need to use an item before you can continue on.");
      }
      else
      {
        CurrentRoom = CurrentRoom.Go(direction);
      }


      // Item item = CurrentRoom.Items.Find(i => i.Name.ToLower() == itemName.ToLower());
      // if (CurrentRoom.Name == "Desolate Kitchen Plains" && CurrentPlayer.Inventory.Contains(Food))
      // {
      //   Console.WriteLine("You have died of starvation... Better luck next time!");
      //   Thread.Sleep(6000);
      //   Reset();
      // }
      // else if (CurrentRoom.Name == "Microwave" && CurrentPlayer.Inventory.!Contains(Food))
      // {
      //   Console.WriteLine("You do not have the qualified equipment to move on. It would be too dangerous to go back. You are stranded... Better luck next time!");
      //   Thread.Sleep(6000);
      //   Reset();
      // }
      // else
      // {
      // }
    }

    public void TakeItem(string itemName)
    {
      //FIXME FIXED!!! check if user can take an item from their current room, if so, put it into their inventory, if not, alert them there is nothing to take etc.

      Item item = CurrentRoom.Items.Find(i => i.Name.ToLower() == itemName.ToLower());

      if (item != null)
      {
        CurrentPlayer.Inventory.Add(item);
        CurrentRoom.Items.Remove(item);
        Console.WriteLine($"The {item.Name} has been added to your inventory");
        Inventory();

      }
      else
      {
        Console.WriteLine("There isn't an item to take.");
      }



      //When taking an item be sure the item is in the current room 
      //before adding it to the player inventory, Also don't forget to 
      //remove the item from the room it was picked up in

      //NOTE This method needs to "checkout" an item from the room that contains that specific item. This should then place the item within the player's inventory
    }

    public void UseItem(string itemName)
    {

      Item item = CurrentPlayer.Inventory.Find(i => i.Name.ToLower() == itemName.ToLower());
      if (CurrentRoom.IsLocked == true)
      {
        CurrentPlayer.Inventory.Remove(item);
        Console.Clear();
        Console.WriteLine($"You've used the {item.Name}.");
        CurrentRoom.Description = CurrentRoom.UnlockedDescription;
        Console.WriteLine($"{CurrentRoom.Description}");
        CurrentRoom.IsLocked = false;
      }
      else
      {
        Console.WriteLine("You can't use that here.");
      }

      //FIXME FIXED!!! check if user can use item in this room, if so activate it to change the room state, then remove it from inventory (if you want to)

      //No need to Pass a room since Items can only be used in the CurrentRoom
      //Make sure you validate the item is in the room or player inventory before
      //being able to use the item

      //NOTE This method needs to be used in a room that is locked. Using the item should flip the "isLocked" bool allowing you to exit the room. This also needs to remove the item from your inventory.
    }

    public void Inventory()
    {
      //Print the list of items in the players inventory to the console
      //NOTE probably a Console.WriteLine() and a foreach
      if (CurrentPlayer.Inventory.Count == 0)
      {
        Console.WriteLine($@"{CurrentPlayer.PlayerName}'s Inventory:
There is nothing in your inventory
");
      }
      else
      {
        Console.WriteLine($@"{CurrentPlayer.PlayerName}'s Inventory:
");
        foreach (var playerItem in CurrentPlayer.Inventory)
        {
          Console.WriteLine($@"{playerItem.Name}
");
        }
      }
    }

    public void Look()
    {
      //FIXME FIXED!!! check room state&/ items available
      Console.WriteLine($"You've arrived {CurrentRoom.Name}");
      Console.WriteLine("");
      string lookDescription = ($"{CurrentRoom.Description}");

      foreach (char letter in lookDescription)
      {
        Console.Write(letter);
        Thread.Sleep(25);
      }
      Console.WriteLine("");
      Console.WriteLine("");


      foreach (var item in CurrentRoom.Items)
      {
        Console.WriteLine($"You've spotted something! {item.Description}. It's {item.Name}.");
        Console.WriteLine("");
      }
    }
  }
}
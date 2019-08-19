using System;
using System.Collections.Generic;
using System.Threading;
using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Project.Models
{
  public class Room : IRoom
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Item> Items { get; set; }
    public Dictionary<string, IRoom> Exits { get; set; }
    public string Location { get; set; }


    public Room(string location, string name, string description)
    {
      Location = location;
      Name = name;
      Description = description;
      Exits = new Dictionary<string, IRoom>();
      Items = new List<Item>();
    }

    public IRoom Go(string direction)
    {
      if (Exits.ContainsKey(direction))
      {
        string traveling = "Traveling...";
        foreach (char travelLetter in traveling)
        {
          Console.Write(travelLetter);
          // Thread.Sleep(100);
          Thread.Sleep(25);
        }
        // Thread.Sleep(500);
        Console.Clear();
        return Exits[direction];
      }
      Console.WriteLine("Can't go that way");
      Console.WriteLine("");
      return this;
    }

    //When taking an item be sure the item is in the current room 
    //before adding it to the player inventory, Also don't forget to 
    //remove the item from the room it was picked up in

    // public IRoom TakeItem(string itemName)
    // {

    // }


  }
}
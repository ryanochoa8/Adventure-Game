using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Project.Models
{
  public class Player : IPlayer
  {
    public string PlayerName { get; set; }
    public List<Item> Inventory { get; set; }

    public Player(string playerName)
    {
      PlayerName = playerName;
    }

    //NOTE Items, TakeItem, UseItem, and / or Inventory will go in here
    // Maybe in the interface too
  }
}
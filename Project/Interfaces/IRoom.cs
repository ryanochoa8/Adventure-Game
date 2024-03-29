using System;
using System.Collections.Generic;
using CastleGrimtol.Project.Models;

namespace CastleGrimtol.Project.Interfaces
{
  public interface IRoom
  {
    string Name { get; set; }
    string Description { get; set; }
    string UnlockedDescription { get; set; }
    List<Item> Items { get; set; }
    Dictionary<string, IRoom> Exits { get; set; }

    IRoom Go(string direction);

    string Location { get; set; }
    bool IsLocked { get; set; }
  }
}

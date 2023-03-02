using System;
using System.Collections.Generic;

namespace WebApplication8.Models;

public partial class Room
{
    public int Id { get; set; }

    public int RoomNumber { get; set; }

    public int Sleeps { get; set; }

    public int Price { get; set; }

    public virtual Registration? Registration { get; set; }
}

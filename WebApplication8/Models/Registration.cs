using System;
using System.Collections.Generic;

namespace WebApplication8.Models;

public partial class Registration
{
    public int Id { get; set; }

    public DateTime? CheckIn { get; set; }

    public DateTime? CheckOut { get; set; }

    public int RoomNumber { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public virtual Room IdNavigation { get; set; } = null!;
}

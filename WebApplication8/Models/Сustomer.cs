using System;
using System.Collections.Generic;

namespace WebApplication8.Models;

public partial class Сustomer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public int? RoomNumber { get; set; }
}

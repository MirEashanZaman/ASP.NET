using System;
using System.Collections.Generic;

namespace FirstMVC.Data.Entities;

public partial class Department
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;
}

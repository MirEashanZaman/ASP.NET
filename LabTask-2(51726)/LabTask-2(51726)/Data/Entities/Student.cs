using System;
using System.Collections.Generic;

namespace LabTask_2_51726_.Data.Entities;

public partial class Student
{
    public int StudentId { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;
}

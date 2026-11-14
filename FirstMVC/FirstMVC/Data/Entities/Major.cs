using System;
using System.Collections.Generic;

namespace FirstMVC.Data.Entities;

public partial class Major
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public decimal TotalCredit { get; set; }

    public decimal? TotalTuitionFee { get; set; }
}

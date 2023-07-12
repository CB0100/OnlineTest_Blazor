using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTest.Data;

public partial class Country
{
    public int CountryId { get; set; }

    public string CountryName { get; set; } = null!;

    [NotMapped]
    public bool IsSelected { get; set; } = false;
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MikesKitchen.Common.EntityModels.SqlServer;

public partial class Unit
{
    [Key]
    [Column("UnitID")]
    public int UnitId { get; set; }

    [StringLength(10)]
    public string UnitDescriptor { get; set; } = null!;
}

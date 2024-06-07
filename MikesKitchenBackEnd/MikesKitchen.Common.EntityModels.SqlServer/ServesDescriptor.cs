using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MikesKitchen.Common;

public partial class ServesDescriptor
{
    [Key]
    public int ServesDescriptorId { get; set; }

    [Column("ServesDescriptor")]
    [StringLength(50)]
    public string ServesDescriptor1 { get; set; } = null!;

    [InverseProperty("ServesDescriptor")]
    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
}

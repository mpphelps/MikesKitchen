using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MikesKitchen.Common.EntityModels.SqlServer;

[PrimaryKey("RecipeId", "StepId")]
public partial class RecipeStep
{
    [Key]
    public int RecipeId { get; set; }

    [Key]
    public int StepId { get; set; }

    [StringLength(500)]
    public string Step { get; set; } = null!;

    [Column(TypeName = "image")]
    public byte[]? Photo { get; set; }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MikesKitchen.Common.EntityModels.SqlServer;

[PrimaryKey("RecipeId", "IngredientId")]
public partial class RecipeIngredient
{
    [Key]
    public int RecipeId { get; set; }

    [Key]
    public int IngredientId { get; set; }

    [StringLength(50)]
    public string Ingredient { get; set; } = null!;

    public double Quantity { get; set; }

    [Column("UnitID")]
    public int UnitId { get; set; }

    [ForeignKey("RecipeId")]
    [InverseProperty("RecipeIngredients")]
    public virtual Recipe Recipe { get; set; } = null!;

    [ForeignKey("UnitId")]
    [InverseProperty("RecipeIngredients")]
    public virtual Unit Unit { get; set; } = null!;
}

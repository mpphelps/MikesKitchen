using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MikesKitchen.Common.EntityModels.SqlServer;

public partial class Recipe
{
    [Key]
    public int RecipeId { get; set; }

    public int UserId { get; set; }

    [StringLength(50)]
    public string Title { get; set; } = null!;

    public int ServesDescriptorId { get; set; }

    public int ServesQuantity { get; set; }

    public int PrepTime { get; set; }

    public int CookTime { get; set; }

    [Column(TypeName = "image")]
    public byte[]? Photo { get; set; }

    public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();

    public virtual ICollection<RecipeStep> RecipeSteps { get; set; } = new List<RecipeStep>();

    [ForeignKey("ServesDescriptorId")]
    public virtual ServesDescriptor ServesDescriptor { get; set; } = null!;

    [ForeignKey("UserId")]
	public virtual User User { get; set; } = null!;
}

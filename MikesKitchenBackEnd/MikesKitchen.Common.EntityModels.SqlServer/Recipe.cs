using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MikesKitchen.Common;

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

    [InverseProperty("Recipe")]
    public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();

    [InverseProperty("Recipe")]
    public virtual ICollection<RecipeStep> RecipeSteps { get; set; } = new List<RecipeStep>();

    [ForeignKey("ServesDescriptorId")]
    [InverseProperty("Recipes")]
    public virtual ServesDescriptor ServesDescriptor { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("RecipesNavigation")]
    public virtual User User { get; set; } = null!;

    [ForeignKey("RecipeId")]
    [InverseProperty("Recipes")]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}

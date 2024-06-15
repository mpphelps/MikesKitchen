using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MikesKitchen.Common.EntityModels.SqlServer;

public partial class User
{
    [Key]
    public int UserId { get; set; }

    [StringLength(50)]
	[RegularExpression(@"^[A-Z][a-z]*(?:[-' ][A-Z][a-z]*)*$", ErrorMessage = "First name must start with a capital letter and contain only letters, hyphens, apostrophes, or spaces.")]
	public string FirstName { get; set; } = null!;

    [StringLength(50)]
	[RegularExpression(@"^[A-Z][a-z]*(?:[-' ][A-Z][a-z]*)*$", ErrorMessage = "Last name must start with a capital letter and contain only letters, hyphens, apostrophes, or spaces.")]
	public string LastName { get; set; } = null!;

    [StringLength(50)]
	[RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email format")]
	public string Email { get; set; } = null!;

    [StringLength(50)]
    public string Password { get; set; } = null!;

    [StringLength(50)]
    public string UserName { get; set; } = null!;

    [InverseProperty("User")]
    public virtual ICollection<Recipe> RecipesNavigation { get; set; } = new List<Recipe>();

    [ForeignKey("UserId")]
    [InverseProperty("Users")]
    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
}

namespace RecipeManagement.Databases;

using Domain.Recipes;
using Domain.Recipes.Dtos;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContextInitializer
{
    private readonly ILogger<ApplicationDbContextInitializer> _logger;
    private readonly RecipesDbContext _context;

    public ApplicationDbContextInitializer(ILogger<ApplicationDbContextInitializer> logger, RecipesDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task InitializeAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initializing the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        // Default roles
        // var administratorRole = new IdentityRole("Administrator");
        //
        // if (_roleManager.Roles.All(r => r.Name != administratorRole.Name))
        // {
        //     await _roleManager.CreateAsync(administratorRole);
        // }
        //
        // // Default users
        // var administrator = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };
        //
        // if (_userManager.Users.All(u => u.UserName != administrator.UserName))
        // {
        //     await _userManager.CreateAsync(administrator, "Administrator1!");
        //     await _userManager.AddToRolesAsync(administrator, new [] { administratorRole.Name });
        // }
    
        // Default data
        // Seed, if necessary
        if (!_context.Recipes.Any())
        {
            var baseRecipeToCreate = new RecipeForCreationDto()
            {
                Title = "Chicken and Waffles",
                Description = "A southern classic",
                Directions = "Cook the chicken and waffles",
                Visibility = VisibilityEnum.Public.Name
            };
            var baseRecipe = Recipe.Create(baseRecipeToCreate);
            _context.Recipes.Add(baseRecipe);
    
            await _context.SaveChangesAsync();
        }
    }
}
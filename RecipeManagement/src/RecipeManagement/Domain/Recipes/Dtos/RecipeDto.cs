namespace RecipeManagement.Domain.Recipes.Dtos;

public sealed class RecipeDto 
{
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Directions { get; set; }
        public string RecipeSourceLink { get; set; }
        public string Description { get; set; }
        public string ImageLink { get; set; }
        public string Visibility { get; set; }
        public DateOnly? DateOfOrigin { get; set; }
}

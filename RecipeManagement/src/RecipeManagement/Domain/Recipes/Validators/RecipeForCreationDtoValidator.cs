namespace RecipeManagement.Domain.Recipes.Validators;

using RecipeManagement.Domain.Recipes.Dtos;
using FluentValidation;

public sealed class RecipeForCreationDtoValidator: RecipeForManipulationDtoValidator<RecipeForCreationDto>
{
    public RecipeForCreationDtoValidator()
    {
        // add fluent validation rules that should only be run on creation operations here
        //https://fluentvalidation.net/
    }
}
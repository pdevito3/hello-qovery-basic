namespace RecipeManagement.Domain.Recipes.Validators;

using RecipeManagement.Domain.Recipes.Dtos;
using FluentValidation;

public sealed class RecipeForUpdateDtoValidator: RecipeForManipulationDtoValidator<RecipeForUpdateDto>
{
    public RecipeForUpdateDtoValidator()
    {
        // add fluent validation rules that should only be run on update operations here
        //https://fluentvalidation.net/
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CatShelterManager.Models
{
    public static class ValidationHelper
    {
        public static bool TryValidate(object model, out string errorMessage)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(model);

            bool isValid = Validator.TryValidateObject(
                model, context, results, validateAllProperties: true);

            errorMessage = isValid
                ? string.Empty
                : string.Join("\n", results.ConvertAll(r => r.ErrorMessage));

            return isValid;
        }
    }
}
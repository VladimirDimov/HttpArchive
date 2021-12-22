using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Filters
{
    public class FluentValidationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var fieldWithErrors = context.ModelState
                    .Where(x => x.Value.Errors.Count > 0);

                List<Exception> validationExceptions = new List<Exception>();

                foreach (var field in fieldWithErrors)
                {
                    foreach (var error in field.Value.Errors)
                    {
                        validationExceptions.Add(error.Exception);
                    }
                }

                if (validationExceptions.Any())
                    throw new AggregateException(validationExceptions);
            }
        }
    }
}

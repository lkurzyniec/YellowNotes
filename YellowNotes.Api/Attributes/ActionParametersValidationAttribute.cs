using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Http.Controllers;

namespace YellowNotes.Api.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    internal class ActionParametersValidationAttribute : ValidateModelStateAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var parameters = actionContext.ActionDescriptor.GetParameters();
            var parametersToValidate =
                parameters
                    .Where(p => !p.IsOptional && p.DefaultValue == null)
                    .Select(p => new { Parameter = p, Attributes = p.GetCustomAttributes<ValidationAttribute>() })
                    .Where(p => p.Attributes.Count > 0)
                    .ToList();

            parametersToValidate.ForEach(item => ValidateParameter(actionContext, item.Parameter, item.Attributes));

            base.OnActionExecuting(actionContext);
        }

        private static void ValidateParameter(HttpActionContext actionContext, HttpParameterDescriptor parameter, 
            Collection<ValidationAttribute> attributes)
        {
            foreach (var attribute in attributes)
            {
                if (!attribute.IsValid(actionContext.ActionArguments[parameter.ParameterName]))
                {
                    actionContext.ModelState.AddModelError(parameter.ParameterName,
                        attribute.FormatErrorMessage(parameter.ParameterName));
                }
            }
        }
    }
}
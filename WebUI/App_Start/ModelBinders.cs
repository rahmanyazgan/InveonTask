using System;
using System.Globalization;
using System.Web.Mvc;

public class DecimalModelBinder : IModelBinder
{
    public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
    {
        var valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

        if (valueResult == null)
        {
            return null;
        }

        var value = valueResult.AttemptedValue;

        if (string.IsNullOrEmpty(value))
        {
            return null;
        }

        decimal decimalValue;
        var result = decimal.TryParse(value.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out decimalValue);

        if (result)
        {
            bindingContext.ModelState.SetModelValue(bindingContext.ModelName, valueResult);
            return decimalValue;
        }

        var modelState = new ModelState { Value = valueResult };
        bindingContext.ModelState.Add(bindingContext.ModelName, modelState);
        bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Geçersiz decimal değer");
        return null;
    }
}
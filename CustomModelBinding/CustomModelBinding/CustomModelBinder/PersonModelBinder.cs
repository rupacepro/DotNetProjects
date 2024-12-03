using CustomModelBinding.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CustomModelBinding.CustomModelBinder
{
    public class PersonModelBinder : IModelBinder
    {
        Person person = new Person();
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            //FirstName
            if(bindingContext.ValueProvider.GetValue("FirstName").Length > 0)
            {
                person.FullName = bindingContext.ValueProvider.GetValue("FirstName").FirstValue;
                if (bindingContext.ValueProvider.GetValue("LastName").Length > 0)
                {
                    person.FullName += " " + bindingContext.ValueProvider.GetValue("LastName").FirstValue;
                }
            }

            if(bindingContext.ValueProvider.GetValue("Phone").Length > 0)
            {
                person.Phone = bindingContext.ValueProvider.GetValue("Phone").FirstValue;
            }
            bindingContext.Result = ModelBindingResult.Success(person);
            return Task.CompletedTask;
        }
    }
}

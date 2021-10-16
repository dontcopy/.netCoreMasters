using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Services.ItemService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreMastersTodoList.Api.Filters
{
    public class ItemExistingFilterAttribute : TypeFilterAttribute
    {
        public ItemExistingFilterAttribute() : base(typeof(ItemExistingFilter)) { }
        public class ItemExistingFilter : IActionFilter
        {
            private readonly IItemService _itemService;

            public ItemExistingFilter(IItemService itemService)
            {
                _itemService = itemService;
            }
            public void OnActionExecuted(ActionExecutedContext context)
            {
               
            }

            public void OnActionExecuting(ActionExecutingContext context)
            {
                object obj;
                if(context.ActionArguments.TryGetValue("itemId", out obj))
                {
                    if (_itemService.Get((int)obj) == null)
                        context.Result = new NotFoundResult();
                }
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreMastersTodoList.Api.Filters
{
    public class LogTimeFilter : IActionFilter
    {
        private readonly IDiagnosticContext _diagnosticContext;
        private readonly ILogger _logger;
        public LogTimeFilter(IDiagnosticContext diagnosticContext,ILogger logger)
        {
            _diagnosticContext = diagnosticContext;
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _diagnosticContext.Set("RouteData", context.ActionDescriptor.RouteValues);
            _diagnosticContext.Set("ActionName", context.ActionDescriptor.DisplayName);
            _diagnosticContext.Set("ActionId", context.ActionDescriptor.Id);
            _diagnosticContext.Set("ValidationState", context.ModelState.IsValid);
            _logger.Information(context.ActionDescriptor.DisplayName); //add start custom logging
        }

        public void OnActionExecuted(ActionExecutedContext context) {
            _logger.Information(context.ActionDescriptor.DisplayName);  //end start custom logging
        }
    }
}
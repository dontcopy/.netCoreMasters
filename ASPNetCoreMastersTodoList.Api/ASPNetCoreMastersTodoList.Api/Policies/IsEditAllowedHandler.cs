using ASPNetCoreMastersTodoList.Api.ApiModels;
using ASPNetCoreMastersTodoList.Api.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreMastersTodoList.Api.Policies
{
    public class IsEditAllowedHandler : AuthorizationHandler<IsEditAllowedRequirement,ItemDTO>
    {
        private readonly UserManager<AppUser> _userManager;
        public IsEditAllowedHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                       IsEditAllowedRequirement requirement,ItemDTO item)
        {
            //var user = await _userManager.GetUserAsync(context.User);
            //if (user == null)
            //    return;
            if (item.CreatedBy == context.User.Identity.Name)
                context.Succeed(requirement);
        }
    }
}

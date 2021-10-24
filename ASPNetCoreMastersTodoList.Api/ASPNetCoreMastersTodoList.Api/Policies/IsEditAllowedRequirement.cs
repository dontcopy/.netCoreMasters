using Microsoft.AspNetCore.Authorization;

namespace ASPNetCoreMastersTodoList.Api.Policies
{
    public class IsEditAllowedRequirement : IAuthorizationRequirement
    {
    }
}

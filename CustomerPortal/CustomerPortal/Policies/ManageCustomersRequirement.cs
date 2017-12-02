using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using DAL.Core;


namespace CustomerPortal.Policies
{
    public class ManageCustomersRequirement : IAuthorizationRequirement
    {

    }
    public class ManageCustomersHandler : AuthorizationHandler<ManageCustomersRequirement, Tuple<string[], string[]>>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ManageCustomersRequirement requirement, Tuple<string[], string[]> Name)
        {
            if (context.User.HasClaim(CustomClaimTypes.Permission, ApplicationPermissions.ManageCustomers))
                context.Succeed(requirement);

            return Task.CompletedTask;
        }

    }
}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Authorization;
//using DAL.Core;

//namespace CustomerPortal.Policies
//{
//    public class ManageJobsRequirement : IAuthorizationRequirement
//    { }
//    public class ManageJobsHandler : AuthorizationHandler<ManageJobsRequirement, Tuple<string[], string[]>>
//    {
        
//        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context ,ManageJobsRequirement requirement, Tuple<string[], string[]> Name)
//        {
//            if (context.User.HasClaim(CustomClaimTypes.Permission, ApplicationPermissions.ManageJobs))

//            return Task.CompletedTask;
//        }
//    }
//}

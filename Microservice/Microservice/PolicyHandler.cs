using Microsoft.AspNetCore.Authorization;
using System;

namespace Microservice
{
    public static class PolicyHandler
    {
        public static void AuthorizeRequest(AuthorizationPolicyBuilder policy)
        {
            policy.RequireClaim("client_id", "secret_client_id");
        }
        
    }
}

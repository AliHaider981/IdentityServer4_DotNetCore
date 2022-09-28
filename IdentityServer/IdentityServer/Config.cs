using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiRescources()
        {
            return new List<ApiResource>{
                new ApiResource("myresourceapi", "My Resource API")
                {
                    Scopes = {new Scope("apiscope")}
                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                new Client
                {
                    ClientId= "secret_client_id",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "apiscope" }
                }

            };
                
                
        }

       // public static List<ApiScope> GetApiScope()
       // {
       //     return new List<ApiScope>
       //{
       //    new ApiScope
       //    {
       //        Name = "apiscope",
       //        Emphasize=true,
       //    },
       //    new ApiScope
       //    {
       //        Name = "ApiTwo",
       //        Emphasize=true,
       //    },
       //};
       // }


    }
}

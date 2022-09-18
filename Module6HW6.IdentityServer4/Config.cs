using IdentityModel;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;

namespace Module6HW6.IdentityServer4
{
    public static class Config
    {
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>{
                new Client
                {
                    ClientId = "client_id",
                    ClientSecrets = { new Secret("client_secret".ToSha256()) },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes =
                    {
                        "WebApi"
                    }
                }
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("WebApi")
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId()
            };
        }
    }
}

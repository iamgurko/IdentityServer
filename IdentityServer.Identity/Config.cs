using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Identity
{
    public class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }
        //Test kullanıcısı ekleme
        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId="1",
                    Username="Gurkan",
                    Password="pass"
                },
                new TestUser
                {
                    SubjectId="2",
                    Username="User",
                    Password="pass"
                },
            };
        }
        //Api resource tanımı
        public static IEnumerable<ApiResource> GetAllApiResources()
        {
            return new List<ApiResource> { new ApiResource("IdentityServerAPI", "Identity Server API") };
        }
        //Client-Credentials izin tipi
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client> { 
                //Client-Credentials izin tipi
                new Client
            {
                ClientId = "client",
                AllowedGrantTypes= GrantTypes.ClientCredentials,
                ClientSecrets={new Secret("secret".Sha256())},
                AllowedScopes ={"IdentityServerAPI"}
            },
                //Resource Owner Password izin tipi
                new Client
            {
                ClientId="resource.client",
                AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                ClientSecrets={new Secret("secret".Sha256())},
                AllowedScopes={"IdentityServer"}
            },
                //Impilicit Flow izin tipi
                new Client
            {
                ClientId="mvc",
                ClientName="Web Client",
                AllowedGrantTypes=GrantTypes.Implicit,
                RedirectUris={"http://localhost:5003/signin-oidc"},
                PostLogoutRedirectUris={"http://localhost:5003/signout-callback-oidc" },
                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,

                }
            }
            };
        }
    }
}

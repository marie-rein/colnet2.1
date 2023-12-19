using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;


namespace ColNet2._0.CustomModels
{
    public class GetLoggedUser
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public GetLoggedUser(AuthenticationStateProvider authenticationStateProvider)
        {
            _authenticationStateProvider = authenticationStateProvider;
        }


        public async Task<string> GetUserEmail()
        {

            try
            {
                var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
                var user = authState.User;
                string email = string.Empty;

                if (user.Identity.IsAuthenticated)
                {
                    var emailClaim = user.FindFirst(ClaimTypes.Email);

                    if (emailClaim != null)
                    {
                        email = emailClaim.Value;
                    }
                    else
                    {
                        return null;  
                    }
                }
                else
                {
                    return null;     
                }

                return email;
            }
            catch (Exception ex)
            {
              
                return null;
            }
        }
    }
}

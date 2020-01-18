using FriendlyChallenge.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using MongoDB.Driver;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FriendlyChallenge.Service.Authentication
{
    public class AuthenticationService
    {
        private readonly IMongoCollection<AccountAuth> _accounts;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthenticationService(IAccountDatabaseSettings settings, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _accounts = database.GetCollection<AccountAuth>(settings.AccountsCollectionName);
        }
        public async Task<bool> Login(string username, string password)
        {
            var accountData = _accounts.Find(x => x.Username == username).FirstOrDefault();
            if (accountData == null) return false;

            if (BCrypt.Net.BCrypt.Verify(password, accountData.Hash))
            {
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim(ClaimTypes.Name, accountData.Username));
                var principal = new ClaimsPrincipal(identity);
                await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal).ConfigureAwait(false);
                
                return true;
            }

            return false;
            
        }
    }
}

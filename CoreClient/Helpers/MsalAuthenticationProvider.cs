using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreClient.Helpers
{
    public class MsalAuthenticationProvider
    {
        private IConfidentialClientApplication _clientApplication;
        private string[] _scopes;

        public MsalAuthenticationProvider(IConfidentialClientApplication clientApplication, string[] scopes)
        {
            _clientApplication = clientApplication;
            _scopes = scopes;
        }

        public async Task<string> GetTokenAsync()
        {
            AuthenticationResult authResult = await _clientApplication.AcquireTokenForClient(_scopes).ExecuteAsync();
            Thread.Sleep(10000);
            AuthenticationResult authResult2 = await _clientApplication.AcquireTokenForClient(_scopes).ExecuteAsync();
            Thread.Sleep(10000);
            AuthenticationResult authResult3 = await _clientApplication.AcquireTokenForClient(_scopes).ExecuteAsync();
            //var res = await _clientApplication.GetAccountsAsync();
            //AuthenticationResult authResultSilent = await _clientApplication.AcquireTokenSilent(_scopes, authResult.Account).ExecuteAsync();
            if (authResult.AccessToken == authResult2.AccessToken)
            {

            }
            return authResult.AccessToken;
        }
    }
}

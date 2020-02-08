using System.Security.Claims;
using System.Security.Principal;

namespace Ōhara.Doppler.Framework.Helpers
{
    public static class ClaimsHelper
    {
        /// <summary>
        /// Get Claim Value By Provided Key
        /// </summary>
        /// <param name="claimsIdentity"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetClaimValueByKey(this IIdentity claimsIdentity, string key)
        {
            if (claimsIdentity is ClaimsIdentity identity) return identity.FindFirst(key).Value;

            return string.Empty;
        }
    }
}
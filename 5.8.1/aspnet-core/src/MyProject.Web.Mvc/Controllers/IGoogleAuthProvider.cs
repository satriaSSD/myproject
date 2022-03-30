using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MyProject.Web.Controllers
{
    /// <summary>
    /// Provides access to Google auth credentials and scopes.
    /// </summary>
    public interface IGoogleAuthProvider
    {
        /// <summary>
        /// Get a <see cref="GoogleCredential"/> for the current user.
        /// This is a short-term non-refreshable credential; do not store it for later use.
        /// </summary>
        /// <param name="accessTokenRefreshWindow">
        /// Optional. The duration that must be remaining on the oauth access token.
        /// If not specified then will use the default of 5 minutes.
        /// </param>
        /// <param name="cancellationToken">Optional. Token to allow cancellation.</param>
        /// <returns></returns>
        Task<GoogleCredential> GetCredentialAsync(
            TimeSpan? accessTokenRefreshWindow = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Get the currently authorized Google scopes.
        /// </summary>
        /// <returns>A list of all currently authorized Google scopes.</returns>
        Task<IReadOnlyList<string>> GetCurrentScopesAsync();

        /// <summary>
        /// Get a suitable auth challenge if any of the requested scopes are not yet authorized.
        /// </summary>
        /// <param name="scopes">The required scopes.</param>
        /// <returns>
        /// An auth challenge if any of the requested scopes are not yet authorized;
        /// a Task with a result of null otherwise.
        /// </returns>
        Task<IActionResult> RequireScopesAsync(params string[] scopes);
    }
}
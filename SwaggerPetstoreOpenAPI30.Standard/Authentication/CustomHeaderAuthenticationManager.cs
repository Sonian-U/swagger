// <copyright file="CustomHeaderAuthenticationManager.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace SwaggerPetstoreOpenAPI30.Standard.Authentication
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using SwaggerPetstoreOpenAPI30.Standard.Http.Request;

    /// <summary>
    /// CustomHeaderAuthenticationManager Class.
    /// </summary>
    internal class CustomHeaderAuthenticationManager : ICustomHeaderAuthenticationCredentials, IAuthManager
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomHeaderAuthenticationManager"/> class.
        /// </summary>
        /// <param name="apiKey">api_key.</param>
        public CustomHeaderAuthenticationManager(string apiKey)
        {
            this.ApiKey = apiKey;
        }

        /// <summary>
        /// Gets apiKey.
        /// </summary>
        public string ApiKey { get; }

        /// <summary>
        /// Check if credentials match.
        /// </summary>
        /// <param name="apiKey"> api_key.</param>
        /// <returns> The boolean value.</returns>
        public bool Equals(string apiKey)
        {
            return apiKey.Equals(this.ApiKey);
        }

        /// <summary>
        /// Adds authentication to the given HttpRequest.
        /// </summary>
        /// <param name="httpRequest">Http Request.</param>
        /// <returns>Returns the httpRequest after adding authentication.</returns>
        public HttpRequest Apply(HttpRequest httpRequest)
        {
            httpRequest.AddHeaders(new Dictionary<string, string>
            {
                { "api_key", this.ApiKey },
            });
            return httpRequest;
        }

        /// <summary>
        /// Adds authentication to the given HttpRequest.
        /// </summary>
        /// <param name="httpRequest">Http Request.</param>
        /// <returns>Returns the httpRequest after adding authentication.</returns>
        public Task<HttpRequest> ApplyAsync(HttpRequest httpRequest)
        {
            return Task.FromResult(this.Apply(httpRequest));
        }
    }
}
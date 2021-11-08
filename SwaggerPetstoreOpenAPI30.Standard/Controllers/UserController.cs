// <copyright file="UserController.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace SwaggerPetstoreOpenAPI30.Standard.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Converters;
    using SwaggerPetstoreOpenAPI30.Standard;
    using SwaggerPetstoreOpenAPI30.Standard.Authentication;
    using SwaggerPetstoreOpenAPI30.Standard.Exceptions;
    using SwaggerPetstoreOpenAPI30.Standard.Http.Client;
    using SwaggerPetstoreOpenAPI30.Standard.Http.Request;
    using SwaggerPetstoreOpenAPI30.Standard.Http.Response;
    using SwaggerPetstoreOpenAPI30.Standard.Utilities;

    /// <summary>
    /// UserController.
    /// </summary>
    public class UserController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal UserController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// This can only be done by the logged in user.
        /// </summary>
        /// <param name="id">Optional parameter: Example: .</param>
        /// <param name="username">Optional parameter: Example: .</param>
        /// <param name="firstName">Optional parameter: Example: .</param>
        /// <param name="lastName">Optional parameter: Example: .</param>
        /// <param name="email">Optional parameter: Example: .</param>
        /// <param name="password">Optional parameter: Example: .</param>
        /// <param name="phone">Optional parameter: Example: .</param>
        /// <param name="userStatus">Optional parameter: User Status.</param>
        /// <returns>Returns the Models.User response from the API call.</returns>
        public Models.User CreateUser(
                long? id = null,
                string username = null,
                string firstName = null,
                string lastName = null,
                string email = null,
                string password = null,
                string phone = null,
                int? userStatus = null)
        {
            Task<Models.User> t = this.CreateUserAsync(id, username, firstName, lastName, email, password, phone, userStatus);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// This can only be done by the logged in user.
        /// </summary>
        /// <param name="id">Optional parameter: Example: .</param>
        /// <param name="username">Optional parameter: Example: .</param>
        /// <param name="firstName">Optional parameter: Example: .</param>
        /// <param name="lastName">Optional parameter: Example: .</param>
        /// <param name="email">Optional parameter: Example: .</param>
        /// <param name="password">Optional parameter: Example: .</param>
        /// <param name="phone">Optional parameter: Example: .</param>
        /// <param name="userStatus">Optional parameter: User Status.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.User response from the API call.</returns>
        public async Task<Models.User> CreateUserAsync(
                long? id = null,
                string username = null,
                string firstName = null,
                string lastName = null,
                string email = null,
                string password = null,
                string phone = null,
                int? userStatus = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/user");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
            };

            // append form/field parameters.
            var fields = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("id", id),
                new KeyValuePair<string, object>("username", username),
                new KeyValuePair<string, object>("firstName", firstName),
                new KeyValuePair<string, object>("lastName", lastName),
                new KeyValuePair<string, object>("email", email),
                new KeyValuePair<string, object>("password", password),
                new KeyValuePair<string, object>("phone", phone),
                new KeyValuePair<string, object>("userStatus", userStatus),
            };

            // remove null parameters.
            fields = fields.Where(kvp => kvp.Value != null).ToList();

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Post(queryBuilder.ToString(), headers, fields);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.User>(response.Body);
        }

        /// <summary>
        /// Creates list of users with given input array.
        /// </summary>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <returns>Returns the Models.User response from the API call.</returns>
        public Models.User CreateUsersWithListInput(
                List<Models.User> body = null)
        {
            Task<Models.User> t = this.CreateUsersWithListInputAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Creates list of users with given input array.
        /// </summary>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.User response from the API call.</returns>
        public async Task<Models.User> CreateUsersWithListInputAsync(
                List<Models.User> body = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/user/createWithList");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/xml" },
                { "content-type", "application/json; charset=utf-8" },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // [200,208] = HTTP OK
            if ((response.StatusCode < 200) || (response.StatusCode > 208))
            {
                throw new ApiException("successful operation", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return XmlUtility.FromXml<Models.User>(response.Body, "user");
        }

        /// <summary>
        /// Logs user into the system.
        /// </summary>
        /// <param name="username">Optional parameter: The user name for login.</param>
        /// <param name="password">Optional parameter: The password for login in clear text.</param>
        /// <returns>Returns the string response from the API call.</returns>
        public string LoginUser(
                string username = null,
                string password = null)
        {
            Task<string> t = this.LoginUserAsync(username, password);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Logs user into the system.
        /// </summary>
        /// <param name="username">Optional parameter: The user name for login.</param>
        /// <param name="password">Optional parameter: The password for login in clear text.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the string response from the API call.</returns>
        public async Task<string> LoginUserAsync(
                string username = null,
                string password = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/user/login");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "username", username },
                { "password", password },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/xml" },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers, queryParameters: queryParams);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            if (response.StatusCode == 400)
            {
                throw new ApiException("Invalid username/password supplied", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return XmlUtility.FromXml<string>(response.Body, "response");
        }

        /// <summary>
        /// Logs out current logged in user session.
        /// </summary>
        public void LogoutUser()
        {
            Task t = this.LogoutUserAsync();
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// Logs out current logged in user session.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task LogoutUserAsync(CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/user/logout");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);
        }

        /// <summary>
        /// Get user by user name.
        /// </summary>
        /// <param name="username">Required parameter: The name that needs to be fetched. Use user1 for testing..</param>
        /// <returns>Returns the Models.User response from the API call.</returns>
        public Models.User GetUserByName(
                string username)
        {
            Task<Models.User> t = this.GetUserByNameAsync(username);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Get user by user name.
        /// </summary>
        /// <param name="username">Required parameter: The name that needs to be fetched. Use user1 for testing..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.User response from the API call.</returns>
        public async Task<Models.User> GetUserByNameAsync(
                string username,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/user/{username}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "username", username },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/xml" },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            if (response.StatusCode == 400)
            {
                throw new ApiException("Invalid username supplied", context);
            }

            if (response.StatusCode == 404)
            {
                throw new ApiException("User not found", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return XmlUtility.FromXml<Models.User>(response.Body, "user");
        }

        /// <summary>
        /// This can only be done by the logged in user.
        /// </summary>
        /// <param name="username1">Required parameter: name that need to be deleted.</param>
        /// <param name="id">Optional parameter: Example: .</param>
        /// <param name="username">Optional parameter: Example: .</param>
        /// <param name="firstName">Optional parameter: Example: .</param>
        /// <param name="lastName">Optional parameter: Example: .</param>
        /// <param name="email">Optional parameter: Example: .</param>
        /// <param name="password">Optional parameter: Example: .</param>
        /// <param name="phone">Optional parameter: Example: .</param>
        /// <param name="userStatus">Optional parameter: User Status.</param>
        public void UpdateUser(
                string username1,
                long? id = null,
                string username = null,
                string firstName = null,
                string lastName = null,
                string email = null,
                string password = null,
                string phone = null,
                int? userStatus = null)
        {
            Task t = this.UpdateUserAsync(username1, id, username, firstName, lastName, email, password, phone, userStatus);
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// This can only be done by the logged in user.
        /// </summary>
        /// <param name="username1">Required parameter: name that need to be deleted.</param>
        /// <param name="id">Optional parameter: Example: .</param>
        /// <param name="username">Optional parameter: Example: .</param>
        /// <param name="firstName">Optional parameter: Example: .</param>
        /// <param name="lastName">Optional parameter: Example: .</param>
        /// <param name="email">Optional parameter: Example: .</param>
        /// <param name="password">Optional parameter: Example: .</param>
        /// <param name="phone">Optional parameter: Example: .</param>
        /// <param name="userStatus">Optional parameter: User Status.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task UpdateUserAsync(
                string username1,
                long? id = null,
                string username = null,
                string firstName = null,
                string lastName = null,
                string email = null,
                string password = null,
                string phone = null,
                int? userStatus = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/user/{username}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "username1", username1 },
                { "username", username },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
            };

            // append form/field parameters.
            var fields = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("id", id),
                new KeyValuePair<string, object>("firstName", firstName),
                new KeyValuePair<string, object>("lastName", lastName),
                new KeyValuePair<string, object>("email", email),
                new KeyValuePair<string, object>("password", password),
                new KeyValuePair<string, object>("phone", phone),
                new KeyValuePair<string, object>("userStatus", userStatus),
            };

            // remove null parameters.
            fields = fields.Where(kvp => kvp.Value != null).ToList();

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Put(queryBuilder.ToString(), headers, fields);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);
        }

        /// <summary>
        /// This can only be done by the logged in user.
        /// </summary>
        /// <param name="username">Required parameter: The name that needs to be deleted.</param>
        public void DeleteUser(
                string username)
        {
            Task t = this.DeleteUserAsync(username);
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// This can only be done by the logged in user.
        /// </summary>
        /// <param name="username">Required parameter: The name that needs to be deleted.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task DeleteUserAsync(
                string username,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/user/{username}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "username", username },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Delete(queryBuilder.ToString(), headers, null);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            if (response.StatusCode == 400)
            {
                throw new ApiException("Invalid username supplied", context);
            }

            if (response.StatusCode == 404)
            {
                throw new ApiException("User not found", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);
        }
    }
}
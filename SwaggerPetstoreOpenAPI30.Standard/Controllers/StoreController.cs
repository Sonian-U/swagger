// <copyright file="StoreController.cs" company="APIMatic">
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
    /// StoreController.
    /// </summary>
    public class StoreController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StoreController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal StoreController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// Returns a map of status codes to quantities.
        /// </summary>
        /// <returns>Returns the Dictionary of string, int response from the API call.</returns>
        public Dictionary<string, int> GetInventory()
        {
            Task<Dictionary<string, int>> t = this.GetInventoryAsync();
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns a map of status codes to quantities.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Dictionary of string, int response from the API call.</returns>
        public async Task<Dictionary<string, int>> GetInventoryAsync(CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/store/inventory");

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

            return ApiHelper.JsonDeserialize<Dictionary<string, int>>(response.Body);
        }

        /// <summary>
        /// Place a new order in the store.
        /// </summary>
        /// <param name="id">Optional parameter: Example: .</param>
        /// <param name="petId">Optional parameter: Example: .</param>
        /// <param name="quantity">Optional parameter: Example: .</param>
        /// <param name="shipDate">Optional parameter: Example: .</param>
        /// <param name="status">Optional parameter: Order Status.</param>
        /// <param name="complete">Optional parameter: Example: .</param>
        /// <returns>Returns the Models.Order response from the API call.</returns>
        public Models.Order PlaceOrder(
                long? id = null,
                long? petId = null,
                int? quantity = null,
                DateTime? shipDate = null,
                Models.StatusEnum? status = null,
                bool? complete = null)
        {
            Task<Models.Order> t = this.PlaceOrderAsync(id, petId, quantity, shipDate, status, complete);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Place a new order in the store.
        /// </summary>
        /// <param name="id">Optional parameter: Example: .</param>
        /// <param name="petId">Optional parameter: Example: .</param>
        /// <param name="quantity">Optional parameter: Example: .</param>
        /// <param name="shipDate">Optional parameter: Example: .</param>
        /// <param name="status">Optional parameter: Order Status.</param>
        /// <param name="complete">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.Order response from the API call.</returns>
        public async Task<Models.Order> PlaceOrderAsync(
                long? id = null,
                long? petId = null,
                int? quantity = null,
                DateTime? shipDate = null,
                Models.StatusEnum? status = null,
                bool? complete = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/store/order");

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
                new KeyValuePair<string, object>("petId", petId),
                new KeyValuePair<string, object>("quantity", quantity),
                new KeyValuePair<string, object>("shipDate", shipDate.HasValue ? shipDate.Value.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK") : null),
                new KeyValuePair<string, object>("status", (status.HasValue) ? ApiHelper.JsonSerialize(status.Value) : null),
                new KeyValuePair<string, object>("complete", complete),
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

            if (response.StatusCode == 405)
            {
                throw new ApiException("Invalid input", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.Order>(response.Body);
        }

        /// <summary>
        /// For valid response try integer IDs with value <= 5 or > 10. Other values will generated exceptions.
        /// </summary>
        /// <param name="orderId">Required parameter: ID of order that needs to be fetched.</param>
        /// <returns>Returns the Models.Order response from the API call.</returns>
        public Models.Order GetOrderById(
                long orderId)
        {
            Task<Models.Order> t = this.GetOrderByIdAsync(orderId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// For valid response try integer IDs with value <= 5 or > 10. Other values will generated exceptions.
        /// </summary>
        /// <param name="orderId">Required parameter: ID of order that needs to be fetched.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.Order response from the API call.</returns>
        public async Task<Models.Order> GetOrderByIdAsync(
                long orderId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/store/order/{orderId}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "orderId", orderId },
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
                throw new ApiException("Invalid ID supplied", context);
            }

            if (response.StatusCode == 404)
            {
                throw new ApiException("Order not found", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return XmlUtility.FromXml<Models.Order>(response.Body, "order");
        }

        /// <summary>
        /// For valid response try integer IDs with value < 1000. Anything above 1000 or nonintegers will generate API errors.
        /// </summary>
        /// <param name="orderId">Required parameter: ID of the order that needs to be deleted.</param>
        public void DeleteOrder(
                long orderId)
        {
            Task t = this.DeleteOrderAsync(orderId);
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// For valid response try integer IDs with value < 1000. Anything above 1000 or nonintegers will generate API errors.
        /// </summary>
        /// <param name="orderId">Required parameter: ID of the order that needs to be deleted.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task DeleteOrderAsync(
                long orderId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/store/order/{orderId}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "orderId", orderId },
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
                throw new ApiException("Invalid ID supplied", context);
            }

            if (response.StatusCode == 404)
            {
                throw new ApiException("Order not found", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);
        }
    }
}
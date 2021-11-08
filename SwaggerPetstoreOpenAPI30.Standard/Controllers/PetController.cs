// <copyright file="PetController.cs" company="APIMatic">
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
    /// PetController.
    /// </summary>
    public class PetController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PetController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal PetController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// Update an existing pet by Id.
        /// </summary>
        /// <param name="name">Required parameter: Example: .</param>
        /// <param name="photoUrls">Required parameter: Example: .</param>
        /// <param name="id">Optional parameter: Example: .</param>
        /// <param name="category">Optional parameter: Example: .</param>
        /// <param name="tags">Optional parameter: Example: .</param>
        /// <param name="status">Optional parameter: pet status in the store.</param>
        /// <returns>Returns the Models.Pet response from the API call.</returns>
        public Models.Pet UpdatePet(
                string name,
                List<string> photoUrls,
                long? id = null,
                Models.Category category = null,
                List<Models.Tag> tags = null,
                Models.Status1Enum? status = null)
        {
            Task<Models.Pet> t = this.UpdatePetAsync(name, photoUrls, id, category, tags, status);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Update an existing pet by Id.
        /// </summary>
        /// <param name="name">Required parameter: Example: .</param>
        /// <param name="photoUrls">Required parameter: Example: .</param>
        /// <param name="id">Optional parameter: Example: .</param>
        /// <param name="category">Optional parameter: Example: .</param>
        /// <param name="tags">Optional parameter: Example: .</param>
        /// <param name="status">Optional parameter: pet status in the store.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.Pet response from the API call.</returns>
        public async Task<Models.Pet> UpdatePetAsync(
                string name,
                List<string> photoUrls,
                long? id = null,
                Models.Category category = null,
                List<Models.Tag> tags = null,
                Models.Status1Enum? status = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/pet");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/xml" },
            };

            // append form/field parameters.
            var fields = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("name", name),
                new KeyValuePair<string, object>("id", id),
                new KeyValuePair<string, object>("status", (status.HasValue) ? ApiHelper.JsonSerialize(status.Value) : null),
            };
            fields.AddRange(ApiHelper.PrepareFormFieldsFromObject("photoUrls", photoUrls, arrayDeserializationFormat: this.ArrayDeserializationFormat));
            fields.AddRange(ApiHelper.PrepareFormFieldsFromObject("category", category, arrayDeserializationFormat: this.ArrayDeserializationFormat));
            fields.AddRange(ApiHelper.PrepareFormFieldsFromObject("tags", tags, arrayDeserializationFormat: this.ArrayDeserializationFormat));

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

            if (response.StatusCode == 400)
            {
                throw new ApiException("Invalid ID supplied", context);
            }

            if (response.StatusCode == 404)
            {
                throw new ApiException("Pet not found", context);
            }

            if (response.StatusCode == 405)
            {
                throw new ApiException("Validation exception", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return XmlUtility.FromXml<Models.Pet>(response.Body, "pet");
        }

        /// <summary>
        /// Add a new pet to the store.
        /// </summary>
        /// <param name="name">Required parameter: Example: .</param>
        /// <param name="photoUrls">Required parameter: Example: .</param>
        /// <param name="id">Optional parameter: Example: .</param>
        /// <param name="category">Optional parameter: Example: .</param>
        /// <param name="tags">Optional parameter: Example: .</param>
        /// <param name="status">Optional parameter: pet status in the store.</param>
        /// <returns>Returns the Models.Pet response from the API call.</returns>
        public Models.Pet AddPet(
                string name,
                List<string> photoUrls,
                long? id = null,
                Models.Category category = null,
                List<Models.Tag> tags = null,
                Models.Status1Enum? status = null)
        {
            Task<Models.Pet> t = this.AddPetAsync(name, photoUrls, id, category, tags, status);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Add a new pet to the store.
        /// </summary>
        /// <param name="name">Required parameter: Example: .</param>
        /// <param name="photoUrls">Required parameter: Example: .</param>
        /// <param name="id">Optional parameter: Example: .</param>
        /// <param name="category">Optional parameter: Example: .</param>
        /// <param name="tags">Optional parameter: Example: .</param>
        /// <param name="status">Optional parameter: pet status in the store.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.Pet response from the API call.</returns>
        public async Task<Models.Pet> AddPetAsync(
                string name,
                List<string> photoUrls,
                long? id = null,
                Models.Category category = null,
                List<Models.Tag> tags = null,
                Models.Status1Enum? status = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/pet");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/xml" },
            };

            // append form/field parameters.
            var fields = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("name", name),
                new KeyValuePair<string, object>("id", id),
                new KeyValuePair<string, object>("status", (status.HasValue) ? ApiHelper.JsonSerialize(status.Value) : null),
            };
            fields.AddRange(ApiHelper.PrepareFormFieldsFromObject("photoUrls", photoUrls, arrayDeserializationFormat: this.ArrayDeserializationFormat));
            fields.AddRange(ApiHelper.PrepareFormFieldsFromObject("category", category, arrayDeserializationFormat: this.ArrayDeserializationFormat));
            fields.AddRange(ApiHelper.PrepareFormFieldsFromObject("tags", tags, arrayDeserializationFormat: this.ArrayDeserializationFormat));

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

            return XmlUtility.FromXml<Models.Pet>(response.Body, "pet");
        }

        /// <summary>
        /// Multiple status values can be provided with comma separated strings.
        /// </summary>
        /// <param name="status">Optional parameter: Status values that need to be considered for filter.</param>
        /// <returns>Returns the List of Models.Pet response from the API call.</returns>
        public List<Models.Pet> FindPetsByStatus(
                Models.Status2Enum? status = Models.Status2Enum.Available)
        {
            Task<List<Models.Pet>> t = this.FindPetsByStatusAsync(status);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Multiple status values can be provided with comma separated strings.
        /// </summary>
        /// <param name="status">Optional parameter: Status values that need to be considered for filter.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the List of Models.Pet response from the API call.</returns>
        public async Task<List<Models.Pet>> FindPetsByStatusAsync(
                Models.Status2Enum? status = Models.Status2Enum.Available,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/pet/findByStatus");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "status", (status.HasValue) ? ApiHelper.JsonSerialize(status.Value) : "available" },
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
                throw new ApiException("Invalid status value", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return XmlUtility.FromXml<List<Models.Pet>>(response.Body, "pet");
        }

        /// <summary>
        /// Multiple tags can be provided with comma separated strings. Use tag1, tag2, tag3 for testing.
        /// </summary>
        /// <param name="tags">Optional parameter: Tags to filter by.</param>
        /// <returns>Returns the List of Models.Pet response from the API call.</returns>
        public List<Models.Pet> FindPetsByTags(
                List<string> tags = null)
        {
            Task<List<Models.Pet>> t = this.FindPetsByTagsAsync(tags);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Multiple tags can be provided with comma separated strings. Use tag1, tag2, tag3 for testing.
        /// </summary>
        /// <param name="tags">Optional parameter: Tags to filter by.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the List of Models.Pet response from the API call.</returns>
        public async Task<List<Models.Pet>> FindPetsByTagsAsync(
                List<string> tags = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/pet/findByTags");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "tags", tags },
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
                throw new ApiException("Invalid tag value", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return XmlUtility.FromXml<List<Models.Pet>>(response.Body, "pet");
        }

        /// <summary>
        /// Returns a single pet.
        /// </summary>
        /// <param name="petId">Required parameter: ID of pet to return.</param>
        /// <returns>Returns the Models.Pet response from the API call.</returns>
        public Models.Pet GetPetById(
                long petId)
        {
            Task<Models.Pet> t = this.GetPetByIdAsync(petId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns a single pet.
        /// </summary>
        /// <param name="petId">Required parameter: ID of pet to return.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.Pet response from the API call.</returns>
        public async Task<Models.Pet> GetPetByIdAsync(
                long petId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/pet/{petId}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "petId", petId },
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
                throw new ApiException("Pet not found", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return XmlUtility.FromXml<Models.Pet>(response.Body, "pet");
        }

        /// <summary>
        /// Updates a pet in the store with form data.
        /// </summary>
        /// <param name="petId">Required parameter: ID of pet that needs to be updated.</param>
        /// <param name="name">Optional parameter: Name of pet that needs to be updated.</param>
        /// <param name="status">Optional parameter: Status of pet that needs to be updated.</param>
        public void UpdatePetWithForm(
                long petId,
                string name = null,
                string status = null)
        {
            Task t = this.UpdatePetWithFormAsync(petId, name, status);
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// Updates a pet in the store with form data.
        /// </summary>
        /// <param name="petId">Required parameter: ID of pet that needs to be updated.</param>
        /// <param name="name">Optional parameter: Name of pet that needs to be updated.</param>
        /// <param name="status">Optional parameter: Status of pet that needs to be updated.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task UpdatePetWithFormAsync(
                long petId,
                string name = null,
                string status = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/pet/{petId}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "petId", petId },
            });

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "name", name },
                { "status", status },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Post(queryBuilder.ToString(), headers, null, queryParameters: queryParams);

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
        }

        /// <summary>
        /// Deletes a pet.
        /// </summary>
        /// <param name="petId">Required parameter: Pet id to delete.</param>
        /// <param name="apiKey">Optional parameter: Example: .</param>
        public void DeletePet(
                long petId,
                string apiKey = null)
        {
            Task t = this.DeletePetAsync(petId, apiKey);
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// Deletes a pet.
        /// </summary>
        /// <param name="petId">Required parameter: Pet id to delete.</param>
        /// <param name="apiKey">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task DeletePetAsync(
                long petId,
                string apiKey = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/pet/{petId}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "petId", petId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "api_key", apiKey },
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
                throw new ApiException("Invalid pet value", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);
        }

        /// <summary>
        /// uploads an image.
        /// </summary>
        /// <param name="petId">Required parameter: ID of pet to update.</param>
        /// <param name="additionalMetadata">Optional parameter: Additional Metadata.</param>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <returns>Returns the Models.ApiResponse response from the API call.</returns>
        public Models.ApiResponse UploadFile(
                long petId,
                string additionalMetadata = null,
                FileStreamInfo body = null)
        {
            Task<Models.ApiResponse> t = this.UploadFileAsync(petId, additionalMetadata, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// uploads an image.
        /// </summary>
        /// <param name="petId">Required parameter: ID of pet to update.</param>
        /// <param name="additionalMetadata">Optional parameter: Additional Metadata.</param>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ApiResponse response from the API call.</returns>
        public async Task<Models.ApiResponse> UploadFileAsync(
                long petId,
                string additionalMetadata = null,
                FileStreamInfo body = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/pet/{petId}/uploadImage");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "petId", petId },
            });

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "additionalMetadata", additionalMetadata },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
            };

            var bodyHeaders = new Dictionary<string, IReadOnlyCollection<string>>(StringComparer.OrdinalIgnoreCase)
            {
                { "content-type", new[] { string.IsNullOrEmpty(body.ContentType) ? "application/octect-stream" : body.ContentType } },
            };

            // append form/field parameters.
            var fields = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("body", CreateFileMultipartContent(body, bodyHeaders)),
            };

            // remove null parameters.
            fields = fields.Where(kvp => kvp.Value != null).ToList();

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Post(queryBuilder.ToString(), headers, fields, queryParameters: queryParams);

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

            return ApiHelper.JsonDeserialize<Models.ApiResponse>(response.Body);
        }
    }
}
// <copyright file="StoreControllerTest.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace SwaggerPetstoreOpenAPI30.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Converters;
    using NUnit.Framework;
    using SwaggerPetstoreOpenAPI30.Standard;
    using SwaggerPetstoreOpenAPI30.Standard.Controllers;
    using SwaggerPetstoreOpenAPI30.Standard.Exceptions;
    using SwaggerPetstoreOpenAPI30.Standard.Http.Client;
    using SwaggerPetstoreOpenAPI30.Standard.Http.Response;
    using SwaggerPetstoreOpenAPI30.Standard.Utilities;
    using SwaggerPetstoreOpenAPI30.Tests.Helpers;

    /// <summary>
    /// StoreControllerTest.
    /// </summary>
    [TestFixture]
    public class StoreControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private StoreController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.StoreController;
        }

        /// <summary>
        /// Returns a map of status codes to quantities.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetInventory()
        {
            // Perform API call
            Dictionary<string, int> result = null;
            try
            {
                result = await this.controller.GetInventoryAsync();
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, this.HttpCallBackHandler.Response.StatusCode, "Status should be 200");

            // Test headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");

            Assert.IsTrue(
                    TestHelper.AreHeadersProperSubsetOf (
                    headers,
                    this.HttpCallBackHandler.Response.Headers),
                    "Headers should match");
        }

        /// <summary>
        /// Place a new order in the store.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestPlaceOrder()
        {
            // Parameters for the API call
            long? id = 10;
            long? petId = 198772;
            int? quantity = 7;
            DateTime? shipDate = null;
            Standard.Models.StatusEnum? status = null;
            bool? complete = null;

            // Perform API call
            Standard.Models.Order result = null;
            try
            {
                result = await this.controller.PlaceOrderAsync(id, petId, quantity, shipDate, status, complete);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, this.HttpCallBackHandler.Response.StatusCode, "Status should be 200");

            // Test headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");

            Assert.IsTrue(
                    TestHelper.AreHeadersProperSubsetOf (
                    headers,
                    this.HttpCallBackHandler.Response.Headers),
                    "Headers should match");
        }
    }
}
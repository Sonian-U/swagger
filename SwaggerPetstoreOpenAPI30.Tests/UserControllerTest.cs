// <copyright file="UserControllerTest.cs" company="APIMatic">
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
    /// UserControllerTest.
    /// </summary>
    [TestFixture]
    public class UserControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private UserController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.UserController;
        }

        /// <summary>
        /// Creates list of users with given input array.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestCreateUsersWithListInput()
        {
            // Parameters for the API call
            List<Standard.Models.User> body = null;

            // Perform API call
            Standard.Models.User result = null;
            try
            {
                result = await this.controller.CreateUsersWithListInputAsync(body);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, this.HttpCallBackHandler.Response.StatusCode, "Status should be 200");

            // Test headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/xml");

            Assert.IsTrue(
                    TestHelper.AreHeadersProperSubsetOf (
                    headers,
                    this.HttpCallBackHandler.Response.Headers),
                    "Headers should match");
        }

        /// <summary>
        /// Creates list of users with given input array.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestCreateUsersWithListInput1()
        {
            // Parameters for the API call
            List<Standard.Models.User> body = null;

            // Perform API call
            Standard.Models.User result = null;
            try
            {
                result = await this.controller.CreateUsersWithListInputAsync(body);
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
        /// Logs user into the system.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestLoginUser()
        {
            // Parameters for the API call
            string username = null;
            string password = null;

            // Perform API call
            string result = null;
            try
            {
                result = await this.controller.LoginUserAsync(username, password);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, this.HttpCallBackHandler.Response.StatusCode, "Status should be 200");

            // Test headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("X-Rate-Limit", null);
            headers.Add("X-Expires-After", null);
            headers.Add("Content-Type", "application/xml");

            Assert.IsTrue(
                    TestHelper.AreHeadersProperSubsetOf (
                    headers,
                    this.HttpCallBackHandler.Response.Headers),
                    "Headers should match");
        }

        /// <summary>
        /// Logs user into the system.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestLoginUser1()
        {
            // Parameters for the API call
            string username = null;
            string password = null;

            // Perform API call
            string result = null;
            try
            {
                result = await this.controller.LoginUserAsync(username, password);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, this.HttpCallBackHandler.Response.StatusCode, "Status should be 200");

            // Test headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("X-Rate-Limit", null);
            headers.Add("X-Expires-After", null);
            headers.Add("Content-Type", "application/json");

            Assert.IsTrue(
                    TestHelper.AreHeadersProperSubsetOf (
                    headers,
                    this.HttpCallBackHandler.Response.Headers),
                    "Headers should match");
        }
    }
}
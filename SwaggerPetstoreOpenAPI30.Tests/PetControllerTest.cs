// <copyright file="PetControllerTest.cs" company="APIMatic">
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
    /// PetControllerTest.
    /// </summary>
    [TestFixture]
    public class PetControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private PetController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.PetController;
        }

        /// <summary>
        /// Multiple status values can be provided with comma separated strings.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestFindPetsByStatus()
        {
            // Parameters for the API call
            Standard.Models.Status2Enum status = (Standard.Models.Status2Enum)Enum.Parse(typeof(Standard.Models.Status2Enum), "available");

            // Perform API call
            List<Standard.Models.Pet> result = null;
            try
            {
                result = await this.controller.FindPetsByStatusAsync(status);
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
        /// Multiple status values can be provided with comma separated strings.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestFindPetsByStatus1()
        {
            // Parameters for the API call
            Standard.Models.Status2Enum status = (Standard.Models.Status2Enum)Enum.Parse(typeof(Standard.Models.Status2Enum), "available");

            // Perform API call
            List<Standard.Models.Pet> result = null;
            try
            {
                result = await this.controller.FindPetsByStatusAsync(status);
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
        /// Multiple tags can be provided with comma separated strings. Use tag1, tag2, tag3 for testing..
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestFindPetsByTags()
        {
            // Parameters for the API call
            List<string> tags = null;

            // Perform API call
            List<Standard.Models.Pet> result = null;
            try
            {
                result = await this.controller.FindPetsByTagsAsync(tags);
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
        /// Multiple tags can be provided with comma separated strings. Use tag1, tag2, tag3 for testing..
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestFindPetsByTags1()
        {
            // Parameters for the API call
            List<string> tags = null;

            // Perform API call
            List<Standard.Models.Pet> result = null;
            try
            {
                result = await this.controller.FindPetsByTagsAsync(tags);
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
// <copyright file="Pet.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace SwaggerPetstoreOpenAPI30.Standard.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using SwaggerPetstoreOpenAPI30.Standard;
    using SwaggerPetstoreOpenAPI30.Standard.Utilities;

    /// <summary>
    /// Pet.
    /// </summary>
    [XmlRootAttribute("pet")]
    public class Pet
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Pet"/> class.
        /// </summary>
        public Pet()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Pet"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="photoUrls">photoUrls.</param>
        /// <param name="id">id.</param>
        /// <param name="category">category.</param>
        /// <param name="tags">tags.</param>
        /// <param name="status">status.</param>
        public Pet(
            string name,
            List<string> photoUrls,
            long? id = null,
            Models.Category category = null,
            List<Models.Tag> tags = null,
            Models.Status1Enum? status = null)
        {
            this.Id = id;
            this.Name = name;
            this.Category = category;
            this.PhotoUrls = photoUrls;
            this.Tags = tags;
            this.Status = status;
        }

        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        [XmlElement("id")]
        public long? Id { get; set; }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        [JsonProperty("name")]
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Category.
        /// </summary>
        [JsonProperty("category", NullValueHandling = NullValueHandling.Ignore)]
        [XmlElement("category")]
        public Models.Category Category { get; set; }

        /// <summary>
        /// Gets or sets PhotoUrls.
        /// </summary>
        [JsonProperty("photoUrls")]
        [XmlArray("photoUrls")]
        [XmlArrayItem("photoUrl")]
        public List<string> PhotoUrls { get; set; }

        /// <summary>
        /// Gets or sets Tags.
        /// </summary>
        [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
        [XmlArray("tags")]
        [XmlArrayItem("tag")]
        public List<Models.Tag> Tags { get; set; }

        /// <summary>
        /// pet status in the store
        /// </summary>
        [JsonProperty("status", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        [XmlElement("status")]
        public Models.Status1Enum? Status { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Pet : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }

            return obj is Pet other &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.Category == null && other.Category == null) || (this.Category?.Equals(other.Category) == true)) &&
                ((this.PhotoUrls == null && other.PhotoUrls == null) || (this.PhotoUrls?.Equals(other.PhotoUrls) == true)) &&
                ((this.Tags == null && other.Tags == null) || (this.Tags?.Equals(other.Tags) == true)) &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id.ToString())}");
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name == string.Empty ? "" : this.Name)}");
            toStringOutput.Add($"this.Category = {(this.Category == null ? "null" : this.Category.ToString())}");
            toStringOutput.Add($"this.PhotoUrls = {(this.PhotoUrls == null ? "null" : $"[{string.Join(", ", this.PhotoUrls)} ]")}");
            toStringOutput.Add($"this.Tags = {(this.Tags == null ? "null" : $"[{string.Join(", ", this.Tags)} ]")}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status.ToString())}");
        }
    }
}
// <copyright file="Order.cs" company="APIMatic">
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
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Schema;
    using System.Xml.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using SwaggerPetstoreOpenAPI30.Standard;
    using SwaggerPetstoreOpenAPI30.Standard.Utilities;

    /// <summary>
    /// Order.
    /// </summary>
    [XmlRootAttribute("order")]
    public class Order : IXmlSerializable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class.
        /// </summary>
        public Order()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="petId">petId.</param>
        /// <param name="quantity">quantity.</param>
        /// <param name="shipDate">shipDate.</param>
        /// <param name="status">status.</param>
        /// <param name="complete">complete.</param>
        public Order(
            long? id = null,
            long? petId = null,
            int? quantity = null,
            DateTime? shipDate = null,
            Models.StatusEnum? status = null,
            bool? complete = null)
        {
            this.Id = id;
            this.PetId = petId;
            this.Quantity = quantity;
            this.ShipDate = shipDate;
            this.Status = status;
            this.Complete = complete;
        }

        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        [XmlElement("id")]
        public long? Id { get; set; }

        /// <summary>
        /// Gets or sets PetId.
        /// </summary>
        [JsonProperty("petId", NullValueHandling = NullValueHandling.Ignore)]
        [XmlElement("petId")]
        public long? PetId { get; set; }

        /// <summary>
        /// Gets or sets Quantity.
        /// </summary>
        [JsonProperty("quantity", NullValueHandling = NullValueHandling.Ignore)]
        [XmlElement("quantity")]
        public int? Quantity { get; set; }

        /// <summary>
        /// Gets or sets ShipDate.
        /// </summary>
        [JsonConverter(typeof(IsoDateTimeConverter))]
        [JsonProperty("shipDate", NullValueHandling = NullValueHandling.Ignore)]
        [XmlElement("shipDate")]
        public DateTime? ShipDate { get; set; }

        /// <summary>
        /// Order Status
        /// </summary>
        [JsonProperty("status", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        [XmlElement("status")]
        public Models.StatusEnum? Status { get; set; }

        /// <summary>
        /// Gets or sets Complete.
        /// </summary>
        [JsonProperty("complete", NullValueHandling = NullValueHandling.Ignore)]
        [XmlElement("complete")]
        public bool? Complete { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Order : ({string.Join(", ", toStringOutput)})";
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

            return obj is Order other &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.PetId == null && other.PetId == null) || (this.PetId?.Equals(other.PetId) == true)) &&
                ((this.Quantity == null && other.Quantity == null) || (this.Quantity?.Equals(other.Quantity) == true)) &&
                ((this.ShipDate == null && other.ShipDate == null) || (this.ShipDate?.Equals(other.ShipDate) == true)) &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true)) &&
                ((this.Complete == null && other.Complete == null) || (this.Complete?.Equals(other.Complete) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id.ToString())}");
            toStringOutput.Add($"this.PetId = {(this.PetId == null ? "null" : this.PetId.ToString())}");
            toStringOutput.Add($"this.Quantity = {(this.Quantity == null ? "null" : this.Quantity.ToString())}");
            toStringOutput.Add($"this.ShipDate = {(this.ShipDate == null ? "null" : this.ShipDate.ToString())}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status.ToString())}");
            toStringOutput.Add($"this.Complete = {(this.Complete == null ? "null" : this.Complete.ToString())}");
        }

        /// <summary>
        /// Creates a new class instance from the given XDocument.
        /// </summary>
        /// <param name="xDoc">The xDocument.</param>
        /// <returns>A new class instance.</returns>
        public static Order FromXml(XDocument xDoc)
        {
            var id = (long?)xDoc.Root.Element("id");
            var petId = (long?)xDoc.Root.Element("petId");
            var quantity = (int?)xDoc.Root.Element("quantity");
            var shipDate = Rfc3339DateTimeXmlUtility.StringToRfc3339Date(xDoc.Root.Element("shipDate").Value).GetValueOrDefault();
            Models.StatusEnum status = default(Models.StatusEnum);

            if (xDoc.Root.Element("status") != null)
            {
                status = (Models.StatusEnum)Enum.Parse(typeof(Models.StatusEnum), xDoc.Root.Element("status").Value.TrimEnd().TrimStart());
            }

            var complete = (bool?)xDoc.Root.Element("complete");
            return new Order(
                id,
                petId,
                quantity,
                shipDate,
                status,
                complete);
        }

        /// <summary>
        /// Returns xml schema.
        /// </summary>
        /// <returns>Xml schema object.</returns>
        public XmlSchema GetSchema()
        {
            return null;
        }

        /// <summary>
        /// Writes data to the XmlWriter.
        /// </summary>
        /// <param name="writer">XmlWriter object.</param>
        public void WriteXml(XmlWriter writer)
        {
            if (this.Id != null)
            {
                writer.WriteElementString("id", this.Id.ToString());
            }

            if (this.PetId != null)
            {
                writer.WriteElementString("petId", this.PetId.ToString());
            }

            if (this.Quantity != null)
            {
                writer.WriteElementString("quantity", this.Quantity.ToString());
            }

            if (this.ShipDate != null)
            {
                writer.WriteElementString("shipDate", Rfc3339DateTimeXmlUtility.Rfc3339DateToString(this.ShipDate));
            }

            if (this.Status != null)
            {
                writer.WriteElementString("status", this.Status.ToString());
            }

            if (this.Complete != null)
            {
                writer.WriteElementString("complete", this.Complete.ToString());
            }
        }

        /// <summary>
        /// Loads values from the given XmlReader object.
        /// </summary>
        /// <param name="reader">XmlReader object.</param>
        public void ReadXml(XmlReader reader)
        {
            var xmlStr = reader.ReadOuterXml();
            XDocument xDoc = XDocument.Parse(xmlStr);
            var obj = FromXml(xDoc);

            this.Id = obj.Id;
            this.PetId = obj.PetId;
            this.Quantity = obj.Quantity;
            this.ShipDate = obj.ShipDate;
            this.Status = obj.Status;
            this.Complete = obj.Complete;
        }
    }
}
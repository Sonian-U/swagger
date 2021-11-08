// <copyright file="Status2Enum.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace SwaggerPetstoreOpenAPI30.Standard.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using SwaggerPetstoreOpenAPI30.Standard;
    using SwaggerPetstoreOpenAPI30.Standard.Utilities;

    /// <summary>
    /// Status2Enum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    [XmlRoot("status2")]
    public enum Status2Enum
    {
        /// <summary>
        /// Available.
        /// </summary>
        [XmlEnum("available")]
        [EnumMember(Value = "available")]
        Available,

        /// <summary>
        /// Pending.
        /// </summary>
        [XmlEnum("pending")]
        [EnumMember(Value = "pending")]
        Pending,

        /// <summary>
        /// Sold.
        /// </summary>
        [XmlEnum("sold")]
        [EnumMember(Value = "sold")]
        Sold,
    }
}
// <copyright file="StatusEnum.cs" company="APIMatic">
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
    /// StatusEnum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    [XmlRoot("Status")]
    public enum StatusEnum
    {
        /// <summary>
        /// Placed.
        /// </summary>
        [XmlEnum("placed")]
        [EnumMember(Value = "placed")]
        Placed,

        /// <summary>
        /// Approved.
        /// </summary>
        [XmlEnum("approved")]
        [EnumMember(Value = "approved")]
        Approved,

        /// <summary>
        /// Delivered.
        /// </summary>
        [XmlEnum("delivered")]
        [EnumMember(Value = "delivered")]
        Delivered,
    }
}
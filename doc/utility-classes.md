
# Utility Classes Documentation

## ApiHelper Class

HttpRequest stores necessary information about the http request.

### Properties

| Name | Description | Type |
|  --- | --- | --- |
| HttpMethod | The HTTP verb to use for this request. | `HttpMethod` |
| QueryUrl | The query url for the http request. | `string` |
| QueryParameters | Query parameters collection for the current http request. | `Dictionary<string, object>` |
| Headers | Headers collection for the current http request. | `Dictionary<string, string>` |
| FormParameters | Form parameters for the current http request. | `List<KeyValuePair<string, object>>` |
| Body | Optional raw string to send as request body. | `object` |
| Username | Optional username for Basic Auth. | `string` |
| Password | Optional password for Basic Auth. | `string` |

### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `DeepCloneObject<T>(T obj)` | Creates a deep clone of an object by serializing it into a json string and then deserializing back into an object. | `T` |
| `JsonSerialize(object obj, JsonConverter converter = null)` | JSON Serialization of a given object. | `string` |
| `JsonDeserialize<T>(string json, JsonConverter converter = null)` | JSON Deserialization of the given json string. | `T` |

## CustomDateTimeConverter Class

Extends from IsoDateTimeConverter to allow a custom DateTime format.

### Constructors

| Name | Description |
|  --- | --- |
| `CustomDateTimeConverter(string format)` | Initializes a new instance of the <see cref="CustomDateTimeConverter"/> class. |

## ListDateTimeConverter Class

Extends from JsonConverter, allows the use of a custom converter.

### Properties

| Name | Description | Type |
|  --- | --- | --- |
| `Converter` | Gets or sets the JsonConverter. | `JsonConverter` |

### Constructors

| Name | Description |
|  --- | --- |
| `ListDateTimeConverter()` | Initializes a new instance of the <see cref="ListDateTimeConverter"/> class. |
| `ListDateTimeConverter(Type converter)` | Initializes a new instance of the <see cref="ListDateTimeConverter"/> class. |
| `ListDateTimeConverter(Type converter, string format)` | Initializes a new instance of the <see cref="ListDateTimeConverter"/> class. |

## UnixDateTimeConverter Class

Extends from DateTimeConverterBase, uses unix DateTime format.

### Properties

| Name | Description | Type |
|  --- | --- | --- |
| DateTimeStyles | Gets or sets DateTimeStyles. | `DateTimeStyles` |

## Rfc1123DateTimeXmlUtility Class

Rfc1123DateTimeXmlUtility contains a bunch of utility methods.

### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `StringToRfc1123Date(string date)` | Converts given date string to DateTime as per RFC 1123 time format. | `DateTime` |
| `Rfc1123DateToString(DateTime date)` | Converts given DateTime to string as per RFC 1123 time format. | `string` |
| `FromRfc1123DateTimeXml(string date)` | Converts given XML string to DateTime as per RFC 1123 time format. | `DateTime` |
| `ToRfc1123DateTimeXml(DateTime date, string rootName = null)` | Converts given DateTime to XML string as per RFC 1123 time format. | `string` |
| `FromRfc1123DateTimeListXml(string dates)` | Extracts DateTime list from the given XML string as per RFC 1123 time format. | `List<DateTime>` |
| `ToRfc1123DateTimeListXml(IEnumerable<DateTime> dates, string rootName = null, string arrayNodeName = null, string arrayItemName = null)` | Converts given DateTime data to XML string as per RFC 1123 time format. | `string` |

## Rfc3339DateTimeXmlUtility Class

Rfc3339DateTimeXmlUtility contains a bunch of utility methods.

### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `StringToRfc3339Date(string date)` | Converts given date string to DateTime as per RFC 3339 time format. | `DateTime` |
| `Rfc3339DateToString(DateTime? date)` | Converts given DateTime to string as per RFC 3339 time format. | `string` |
| `FromRfc3339DateTimeXml(string date)` | Converts given XML string to DateTime as per RFC 3339 time format. | `DateTime` |
| `ToRfc3339DateTimeXml(DateTime? date, string rootName = null)` | Converts given DateTime to XML string as per RFC 3339 time format. | `string` |
| `FromRfc3339DateTimeListXml(string dates)` | Extracts DateTime list from the given XML string as per RFC 3339 time format. | `List<DateTime>` |
| `ToRfc3339DateTimeListXml(IEnumerable<DateTime?> dates, string rootName = null, string arrayNodeName = null, string arrayItemName = null)` | Converts given DateTime data to XML string as per RFC 3339 time format. | `string` |

## UnixDateTimeXmlUtility Class

UnixDateTimeXmlUtility contains a bunch of utility methods.

### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `StringToUnixDate(string date)` | Converts given date string to unix datetime. | `DateTime` |
| `UnixDateToString(DateTime date)` | Converts given DateTime to unix datetime string. | `string` |
| `FromUnixDateTimeXml(string date)` | Converts given XML string to unix datetime. | `DateTime` |
| `ToUnixDateTimeXml(DateTime date, string rootName = null)` | Converts given DateTime to unix datetime and returns it as XML string. | `string` |
| `FromUnixDateTimeListXml(string dates)` | Extracts DateTime list in unix datetime from the given XML string. | `List<DateTime>` |
| `ToUnixDateTimeListXml(IEnumerable<DateTime> dates, string rootName = null, string arrayNodeName = null, string arrayItemName = null)` | Converts given DateTime data to unix datetime XML string. | `string` |

## XmlUtility Class

XmlUtility contains a bunch of utility methods.

### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `ToXml<T>(T obj, string rootName = null)` | XML serialization of the given object. | `string` |
| `ModelsArrayToXml<T>(List<T> obj, string arrayName = null, string arrayItemName = null)` | XML serialization of a model type object to a XML array. | `string` |
| `NativeTypesArrayToXml<T>(List<T> obj, string arrayName = null, string arrayItemName = null)` | XML serialization of native type object to a XML array. | `string` |
| `FromXml<T>(string text, string rootName = null)` | XML deserialization of the given string into the given type. | `T` |
| `NativeTypesArrayFromXml<T>(string text)` | XML deserialization of a native type string. | `List<T>` |
| `DictionaryToXml<T>(Dictionary<string, T> dict, string rootName)` | XML serialization of a simple dictionary. | `string` |
| `Dictionary<string, T> XmlToDictionary<T>(string xml)` | XML deserialization of a simple dictionary. | `Dictionary<string, T>` |


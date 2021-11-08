
# Client Class Documentation

The following parameters are configurable for the API Client:

| Parameter | Type | Description |
|  --- | --- | --- |
| `Timeout` | `TimeSpan` | Http client timeout.<br>*Default*: `TimeSpan.FromSeconds(100)` |
| `ApiKey` | `string` |  |

The API client can be initialized as follows:

```csharp
SwaggerPetstoreOpenAPI30.Standard.SwaggerPetstoreOpenAPI30Client client = new SwaggerPetstoreOpenAPI30.Standard.SwaggerPetstoreOpenAPI30Client.Builder().Build();
```

## Swagger Petstore - OpenAPI 3.0Client Class

The gateway for the SDK. This class acts as a factory for the Controllers and also holds the configuration of the SDK.

### Controllers

| Name | Description |
|  --- | --- |
| PetController | Gets PetController controller. |
| StoreController | Gets StoreController controller. |
| UserController | Gets UserController controller. |

### Properties

| Name | Description | Type |
|  --- | --- | --- |
| HttpClientConfiguration | Gets the configuration of the Http Client associated with this client. | `IHttpClientConfiguration` |
| Timeout | Http client timeout. | `TimeSpan` |
| Environment | Current API environment. | `Environment` |

### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `GetBaseUri(Server alias = Server.Default)` | Gets the URL for a particular alias in the current environment and appends it with template parameters. | `string` |
| `ToBuilder()` | Creates an object of the Swagger Petstore - OpenAPI 3.0Client using the values provided for the builder. | `Builder` |

## Swagger Petstore - OpenAPI 3.0Client Builder Class

Class to build instances of Swagger Petstore - OpenAPI 3.0Client.

### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `HttpClientConfiguration(Action<HttpClientConfiguration.Builder> action)` | Gets the configuration of the Http Client associated with this client. | `Builder` |
| `Timeout(TimeSpan timeout)` | Http client timeout. | `Builder` |
| `Environment(Environment environment)` | Current API environment. | `Builder` |


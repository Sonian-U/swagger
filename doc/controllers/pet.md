# Pet

Everything about your Pets

Find out more: [http://swagger.io](http://swagger.io)

```csharp
PetController petController = client.PetController;
```

## Class Name

`PetController`

## Methods

* [Update Pet](/doc/controllers/pet.md#update-pet)
* [Add Pet](/doc/controllers/pet.md#add-pet)
* [Find Pets by Status](/doc/controllers/pet.md#find-pets-by-status)
* [Find Pets by Tags](/doc/controllers/pet.md#find-pets-by-tags)
* [Get Pet by Id](/doc/controllers/pet.md#get-pet-by-id)
* [Update Pet With Form](/doc/controllers/pet.md#update-pet-with-form)
* [Delete Pet](/doc/controllers/pet.md#delete-pet)
* [Upload File](/doc/controllers/pet.md#upload-file)


# Update Pet

Update an existing pet by Id

```csharp
UpdatePetAsync(
    string name,
    List<string> photoUrls,
    long? id = null,
    Models.Category category = null,
    List<Models.Tag> tags = null,
    Models.Status1Enum? status = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `name` | `string` | Form, Required | - |
| `photoUrls` | `List<string>` | Form, Required | - |
| `id` | `long?` | Form, Optional | - |
| `category` | [`Models.Category`](/doc/models/category.md) | Form, Optional | - |
| `tags` | [`List<Models.Tag>`](/doc/models/tag.md) | Form, Optional | - |
| `status` | [`Models.Status1Enum?`](/doc/models/status-1-enum.md) | Form, Optional | pet status in the store |

## Response Type

[`Task<Models.Pet>`](/doc/models/pet.md)

## Example Usage

```csharp
string name = "doggie";
var photoUrls = new List<string>();
photoUrls.Add("photoUrls5");
photoUrls.Add("photoUrls6");
photoUrls.Add("photoUrls7");
long? id = 10L;

try
{
    Pet result = await petController.UpdatePetAsync(name, photoUrls, id, null, null, null);
}
catch (ApiException e){};
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Invalid ID supplied | `ApiException` |
| 404 | Pet not found | `ApiException` |
| 405 | Validation exception | `ApiException` |


# Add Pet

Add a new pet to the store

```csharp
AddPetAsync(
    string name,
    List<string> photoUrls,
    long? id = null,
    Models.Category category = null,
    List<Models.Tag> tags = null,
    Models.Status1Enum? status = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `name` | `string` | Form, Required | - |
| `photoUrls` | `List<string>` | Form, Required | - |
| `id` | `long?` | Form, Optional | - |
| `category` | [`Models.Category`](/doc/models/category.md) | Form, Optional | - |
| `tags` | [`List<Models.Tag>`](/doc/models/tag.md) | Form, Optional | - |
| `status` | [`Models.Status1Enum?`](/doc/models/status-1-enum.md) | Form, Optional | pet status in the store |

## Response Type

[`Task<Models.Pet>`](/doc/models/pet.md)

## Example Usage

```csharp
string name = "doggie";
var photoUrls = new List<string>();
photoUrls.Add("photoUrls5");
photoUrls.Add("photoUrls6");
photoUrls.Add("photoUrls7");
long? id = 10L;

try
{
    Pet result = await petController.AddPetAsync(name, photoUrls, id, null, null, null);
}
catch (ApiException e){};
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 405 | Invalid input | `ApiException` |


# Find Pets by Status

Multiple status values can be provided with comma separated strings

```csharp
FindPetsByStatusAsync(
    Models.Status2Enum? status = Models.Status2Enum.Available)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `status` | [`Models.Status2Enum?`](/doc/models/status-2-enum.md) | Query, Optional | Status values that need to be considered for filter<br>**Default**: `Status2Enum.available` |

## Response Type

[`Task<List<Models.Pet>>`](/doc/models/pet.md)

## Example Usage

```csharp
Status2Enum? status = Status2Enum.Available;

try
{
    List<Pet> result = await petController.FindPetsByStatusAsync(status);
}
catch (ApiException e){};
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Invalid status value | `ApiException` |


# Find Pets by Tags

Multiple tags can be provided with comma separated strings. Use tag1, tag2, tag3 for testing.

```csharp
FindPetsByTagsAsync(
    List<string> tags = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `tags` | `List<string>` | Query, Optional | Tags to filter by |

## Response Type

[`Task<List<Models.Pet>>`](/doc/models/pet.md)

## Example Usage

```csharp
try
{
    List<Pet> result = await petController.FindPetsByTagsAsync(null);
}
catch (ApiException e){};
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Invalid tag value | `ApiException` |


# Get Pet by Id

Returns a single pet

```csharp
GetPetByIdAsync(
    long petId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `petId` | `long` | Template, Required | ID of pet to return |

## Response Type

[`Task<Models.Pet>`](/doc/models/pet.md)

## Example Usage

```csharp
long petId = 152L;

try
{
    Pet result = await petController.GetPetByIdAsync(petId);
}
catch (ApiException e){};
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Invalid ID supplied | `ApiException` |
| 404 | Pet not found | `ApiException` |


# Update Pet With Form

Updates a pet in the store with form data

```csharp
UpdatePetWithFormAsync(
    long petId,
    string name = null,
    string status = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `petId` | `long` | Template, Required | ID of pet that needs to be updated |
| `name` | `string` | Query, Optional | Name of pet that needs to be updated |
| `status` | `string` | Query, Optional | Status of pet that needs to be updated |

## Response Type

`Task`

## Example Usage

```csharp
long petId = 152L;

try
{
    await petController.UpdatePetWithFormAsync(petId, null, null);
}
catch (ApiException e){};
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 405 | Invalid input | `ApiException` |


# Delete Pet

Deletes a pet

```csharp
DeletePetAsync(
    long petId,
    string apiKey = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `petId` | `long` | Template, Required | Pet id to delete |
| `apiKey` | `string` | Header, Optional | - |

## Response Type

`Task`

## Example Usage

```csharp
long petId = 152L;

try
{
    await petController.DeletePetAsync(petId, null);
}
catch (ApiException e){};
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Invalid pet value | `ApiException` |


# Upload File

uploads an image

```csharp
UploadFileAsync(
    long petId,
    string additionalMetadata = null,
    FileStreamInfo body = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `petId` | `long` | Template, Required | ID of pet to update |
| `additionalMetadata` | `string` | Query, Optional | Additional Metadata |
| `body` | `FileStreamInfo` | Form, Optional | - |

## Response Type

[`Task<Models.ApiResponse>`](/doc/models/api-response.md)

## Example Usage

```csharp
long petId = 152L;

try
{
    ApiResponse result = await petController.UploadFileAsync(petId, null, null);
}
catch (ApiException e){};
```


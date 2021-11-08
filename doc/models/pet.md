
# Pet

## Structure

`Pet`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `long?` | Optional | - |
| `Name` | `string` | Required | - |
| `Category` | [`Models.Category`](/doc/models/category.md) | Optional | - |
| `PhotoUrls` | `List<string>` | Required | - |
| `Tags` | [`List<Models.Tag>`](/doc/models/tag.md) | Optional | - |
| `Status` | [`Models.Status1Enum?`](/doc/models/status-1-enum.md) | Optional | pet status in the store |

## Example (as XML)

```xml
<pet>
  <name>name0</name>
  <category />
  <photoUrls>
    <photoUrl>photoUrls5</photoUrl>
    <photoUrl>photoUrls6</photoUrl>
    <photoUrl>photoUrls7</photoUrl>
  </photoUrls>
  <tags />
</pet>
```


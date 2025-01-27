# AZureBlobStorage.API

This repository contains code examples for performing various operations on Azure Blob Storage using the .NET SDK. The operations include uploading, deleting, retrieving, and listing files.

## Getting Started

### Prerequisites
- .NET SDK installed on your machine.
- Azure Storage Account with a Blob Container.
- Azure Storage connection string.

### Installation

1. Clone the repository:
   ```
   git clone https://github.com/nileshdeshmukh-code/AZureBlobStorage.API.git
   ```

2. Navigate to the project directory:
   ```
   cd AZureBlobStorage.API
   ```

3. Install the required NuGet packages:
   ```
   dotnet add package Azure.Storage.Blobs
   dotnet add package Azure.Identity
   ```

4. Update launchsettings.json to include environment variables:
  
4. Update `launchsettings.json` to include environment variables:
```json
{
  "profiles": {
    "IIS Express": {
      "commandName": "IISExpress",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development",
       "Key": "YourConnectionString",
        "Container": "YourContainerName",
        "AccountName": "YourAccountName"
      }
    },
    "YourProjectName": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development",
        "Key": "YourConnectionString",
        "Container": "YourContainerName",
        "AccountName": "YourAccountName"
      }
    }
  }
}
  ```
  

## Usage

### Upload a File
```csharp
var blobServiceClient = new BlobServiceClient("YourConnectionString");
var containerClient = blobServiceClient.GetBlobContainerClient("YourContainerName");
var blobClient = containerClient.GetBlobClient("YourFileName");
await blobClient.UploadAsync("YourFilePath");
```

### Delete a File
```csharp
var blobClient = containerClient.GetBlobClient("YourFileName");
await blobClient.DeleteIfExistsAsync();
```

### List Files
```csharp
var containerClient = blobServiceClient.GetBlobContainerClient("YourContainerName");
var blobs = containerClient.GetBlobs();
foreach (var blob in blobs)
{
    Console.WriteLine(blob.Name);
}
```

## Contributing

Contributions are welcome! Please fork the repository and use a feature branch. Pull requests are warmly welcome.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Acknowledgments

- [Azure Storage Blobs](https://docs.microsoft.com/en-us/azure/storage/blobs/)
- [Azure for .NET Developers](https://docs.microsoft.com/en-us/dotnet/azure/)
```

You can copy and paste this entire block directly into your `README.md` file. Let me know if this works better for you! 😊

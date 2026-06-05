using Azure.Storage.Blobs;
using FileHandler.Api.Abstractions;
using FileHandler.Api.Dtos;

namespace FileHandler.Api.Services;

public class FileService(IConfiguration configuration) : IFileService
{
    private readonly string _connectionString = configuration["BlobStorage:ConnectionString"]!;
    private readonly string _containerName = configuration["BlobStorage:ContainerName"]!;

    public async Task<UploadFileResponse> UploadFileAsync(IFormFile file, CancellationToken ct = default)
    {

        var blobServiceClient = new BlobServiceClient(_connectionString);

        var containerClient = blobServiceClient.GetBlobContainerClient(_containerName);

        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

        var blobClient = containerClient.GetBlobClient(fileName);

        await blobClient.UploadAsync(file.OpenReadStream(), true);

        return new UploadFileResponse(blobClient.Uri.ToString());
    }
    public async Task DeleteFileAsync(string fileName, CancellationToken ct = default)
    {
        var blobServiceClient = new BlobServiceClient(_connectionString);

        var containerClient = blobServiceClient.GetBlobContainerClient(_containerName);

        var blobClient = containerClient.GetBlobClient(fileName);

        await blobClient.DeleteIfExistsAsync();
    }
}

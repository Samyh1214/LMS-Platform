using FileHandler.Api.Dtos;

namespace FileHandler.Api.Abstractions;

public interface IFileService
{
    Task<UploadFileResponse> UploadFileAsync(IFormFile file, CancellationToken ct = default);
    Task DeleteFileAsync(string fileName, CancellationToken ct = default);
}

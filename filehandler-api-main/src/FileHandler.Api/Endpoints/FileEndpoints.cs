using FileHandler.Api.Abstractions;
using FileHandler.Api.Dtos;

namespace FileHandler.Api.Endpoints;

public static class FileEndpoints
{
    public static void MapFileEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/files")
            .WithTags("Files")
            .WithDescription("Handles file uploads")
            .RequireAuthorization();

        group.MapPost("/upload", UploadFile).DisableAntiforgery();
        group.MapDelete("/{fileName}", DeleteFile);
    }
    private static async Task<IResult> UploadFile(HttpContext httpContext, IFormFile file, IFileService service, CancellationToken ct = default)
    {

        var userId = httpContext.User.FindFirst("sub")?.Value
            ?? httpContext.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userId))
            return Results.Unauthorized();

        if (file == null || file.Length == 0)
            return Results.BadRequest("No file provided");

        var allowedTypes = new[] { "image/jpeg", "image/png" };
        if (!allowedTypes.Contains(file.ContentType))
            return Results.BadRequest("Invalid file type");

        if (file.Length > 5 * 1024 * 1024)
            return Results.BadRequest("File too large, max 5MB");

        var result = await service.UploadFileAsync(file, ct);
        return Results.Created("api/files", result);

    }
    private static async Task<IResult> DeleteFile(string fileName, IFileService service, CancellationToken ct = default)
    {
        await service.DeleteFileAsync(fileName, ct);
        return Results.NoContent();
    }
}

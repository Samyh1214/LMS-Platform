# FileHandler.Api
API for handling file uploads and deletions.

## Base URL
https://filehandler-api-sf-b5begsc5gyfuf9hx.swedencentral-01.azurewebsites.net

## Endpoints
### Files
- `POST /api/files/upload` - Upload a file (JWT required)
- `DELETE /api/files/{fileName}` - Delete a file (JWT required)

## Authentication
All endpoints require a valid JWT token passed as a cookie (`accessToken`).

## Security
- CORS configured for allowed origins
- Only authenticated users can upload and delete files
- Accepted file types: `image/jpeg`, `image/png`
- Maximum file size: 5MB

## File Storage
Files are stored in Azure Blob Storage and returned as a public URL.

## Request Body
### POST /api/files/upload
- Content-Type: `multipart/form-data`
- Body: file (image/jpeg or image/png, max 5MB)

### Response
```json
{
  "fileUrl": "https://shikostorage.blob.core.windows.net/profile-images/filename.jpg"
}
```

## Tech Stack
- ASP.NET Core Web API
- Azure Blob Storage
- Scalar (API documentation)

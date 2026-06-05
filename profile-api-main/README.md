# Profile.Api
API for managing user profile information.

## Base URL
https://profile-api-sf.azurewebsites.net

## Endpoints
### Profile
- `GET /api/profile` - Get profile for the authenticated user (JWT required)
- `PUT /api/profile` - Update profile for the authenticated user (JWT required)
- `POST /api/profile` - Create profile for the authenticated user (JWT required)
- `GET /api/profile/{userId}` - Get profile by userId (public)

## Authentication
All endpoints except `GET /api/profile/{userId}` require a valid JWT token passed as a cookie (`accessToken`).

## User Context
User ID is extracted from the JWT `sub` claim automatically. No need to pass userId manually.

## Security
- JWT authentication via cookie (`accessToken`)
- CORS configured for allowed origins
- User ID extracted from JWT `sub` claim — never passed manually
- `GET /api/profile/{userId}` is the only public endpoint

## Request Body
### POST /api/profile
```json
{
  "firstName": "string",
  "lastName": "string"
}
```

### PUT /api/profile
```json
{
  "firstName": "string",
  "lastName": "string",
  "phoneNumber": "string",
  "description": "string",
  "profileImageUrl": "string"
}
```

## Documentation
Sequence diagrams for key flows can be found in the [docs/](docs/) folder.

## Tech Stack
- ASP.NET Core Web API
- Entity Framework Core
- Azure SQL Server
- Scalar (API documentation)

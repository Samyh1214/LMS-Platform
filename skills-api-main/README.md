# Skills.Api
API for managing skills and user skills.

## Base URL
https://skills-api-sf-beakeza9evhea9cm.swedencentral-01.azurewebsites.net

## Endpoints
### Skills
- `GET /api/skills` - Get all available skills (public)
- `POST /api/skills` - Create a new skill (JWT required, UserManage permission)
- `DELETE /api/skills/{id}` - Delete a skill (JWT required, UserManage permission)

### User Skills
- `GET /api/userskills` - Get all skills for the authenticated user (JWT required)
- `POST /api/userskills` - Add a skill to the authenticated user (JWT required)
- `DELETE /api/userskills/{id}` - Remove a skill from the authenticated user (JWT required)

## Authentication
All endpoints except `GET /api/skills` require a valid JWT token passed as a cookie (`accessToken`).

## Authorization
`POST /api/skills` and `DELETE /api/skills/{id}` require the `user:manage` permission claim in the JWT token.

## Security
- CORS configured for allowed origins

## User Context
User ID is extracted from the JWT `sub` claim automatically. No need to pass userId manually.

## Request Body
### POST /api/skills
```json
{
  "skillName": "string"
}
```
### POST /api/userskills
```json
{
  "skillId": 0
}
```

## Tech Stack
- ASP.NET Core Web API
- Entity Framework Core
- Azure SQL Server
- Scalar (API documentation)

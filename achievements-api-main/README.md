# Achievements.Api
API for managing achievements and user achievements.

## Base URL
https://achievements-api-sf-gnhpcwa2d7byaab2.swedencentral-01.azurewebsites.net

## Endpoints
### Achievements
- `GET /api/achievements` - Get all available achievements (public)

### User Achievements
- `GET /api/userachievements` - Get all achievements for the authenticated user (JWT required)
- `POST /api/userachievements` - Add an achievement to the authenticated user (JWT required)

## Achievement Names
Available achievement names to use in POST request:
- `First Login`
- `Course Completed`
- `Top Student`
- `Fast Learner`
- `Profile Complete`
- `Profile Picture Set`

## Achievement Triggers
Achievements are triggered automatically by frontend based on user actions:
- `Profile Complete` — triggered when user completes their profile form
- `Profile Picture Set` — triggered when user uploads a profile picture

Other services can trigger achievements by calling `POST /api/userachievements` with the achievement name.

## Authentication
All user achievement endpoints require a valid JWT token passed as a cookie (`accessToken`).

## Security
- CORS configured for allowed origins

## User Context
User ID is extracted from the JWT `sub` claim automatically. No need to pass userId manually.

## Request Body
### POST /api/userachievements
```json
{
  "achievementName": "string"
}
```

## Tech Stack
- ASP.NET Core Web API
- Entity Framework Core
- Azure SQL Server
- Scalar (API documentation)

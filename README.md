# LMS Platform - Microservices

A Learning Management System (LMS) built as part of a group project during my studies. 
This repository contains the four microservices I was personally responsible for designing, 
building, and deploying.

## Note
This repository is a portfolio demonstration of my work from a group project. 
The original services were deployed on Azure, but cloud resources have since been taken down. 
The code represents my individual contributions to the project.

## My Responsibilities
- Designed and implemented four independent microservices
- Developed corresponding frontend components in Next.js
- Deployed all services to Azure (App Service + SQL + Blob Storage)
- Implemented JWT authentication and CORS across all services

## Services
| Service | Description |
|---|---|
| [Profile.Api](./profile-api-main) | User profile management |
| [Skills.Api](./skills-api-main) | Skills and user-skill relationships |
| [Achievements.Api](./achievements-api-main) | Achievement system |
| [FileHandler.Api](./filehandler-api-main) | File uploads to Azure Blob Storage |

## Frontend
I was also responsible for building the frontend components for my modules in Next.js 
(profile page, skills management, achievements display, file upload). 
The frontend is not included in this repository as it was part of a shared team repository. 
Key frontend work included:
- Profile page with form for updating user information
- Skills management (add/remove skills)
- Achievement badges with automatic triggers
- Profile picture upload integrated with FileHandler.Api
- Admin functionality for managing skills

## Tech Stack
- **Backend:** ASP.NET Core Web API (Minimal API)
- **Database:** Entity Framework Core + Azure SQL Server
- **File Storage:** Azure Blob Storage
- **Authentication:** JWT via cookies
- **Documentation:** Scalar (OpenAPI)
- **Deployment:** Azure App Service

## Architecture
- Microservices architecture with loose coupling
- Frontend aggregates data from multiple services independently
- Each service handles its own data and authentication
- REST API communication between frontend and services

## Key Design Decisions
- **Minimal API** over Controller-based for lightweight microservices
- **Frontend aggregation** over API Gateway for loose coupling and resilience
- **Cookie-based JWT** for seamless authentication across services
- **Azure Blob Storage** for scalable file storage separate from relational data

- ## Documentation
Sequence diagrams for key flows are available in the [Profile.Api/docs](./profile-api-main/docs) folder, including:
- Login and profile page load
- Update profile
- Upload profile picture
- Achievement triggered
- Skills management

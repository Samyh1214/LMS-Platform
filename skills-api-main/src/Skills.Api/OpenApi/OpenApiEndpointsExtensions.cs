using Scalar.AspNetCore;

namespace Skills.Api.OpenApi;

public static class OpenApiEndpointsExtensions
{
    public static WebApplication MapOpenApiEndpoints(this WebApplication app)
    {
        //if (!app.Environment.IsDevelopment())
        //    return app;

        app.MapOpenApi();

        app.MapScalarApiReference("/docs", options => options
            .WithTitle("Documentation for API"));

        return app;
    }
}

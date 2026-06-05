using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi;

namespace Profile.Api.OpenApi;

public sealed class OpenApiDocumentTransformer : IOpenApiDocumentTransformer
{
    public Task TransformAsync(OpenApiDocument document, OpenApiDocumentTransformerContext context, CancellationToken cancellationToken)
    {
        document.Components ??= new OpenApiComponents();

        document.Info.Description = """
        ## Introduction

        The Profile API provides endpoints for showing how a Minimal API works.

        """;

        return Task.CompletedTask;
    }
}

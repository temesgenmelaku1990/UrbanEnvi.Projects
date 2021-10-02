using HotChocolate;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Types;
using UrbanEnvi.Features.AssessmentTypes;
using UrbanEnvi.Features.ProjectCategories;
using UrbanEnvi.Features.Projects;

namespace UrbanEnvi.GraphQL;

[ExtendObjectType(OperationTypeNames.Mutation)]
public class Mutations
{
    [Authorize]
    public async Task<AssessmentType?> CreateAssessmentTypeAsync(
        CreateAssessmentType input,
        [Service] IMediator mediator,
        CancellationToken cancellationToken) =>
        await mediator.Send(input, cancellationToken).AsValue();

    [Authorize]
    public async Task<AssessmentType?> UpdateAssessmentTypeAsync(
        UpdateAssessmentType input,
        [Service] IMediator mediator,
        CancellationToken cancellationToken) =>
        await mediator.Send(input, cancellationToken).AsValue();

    [Authorize]
    public async Task<ProjectCategory?> CreateProjectCategoryAsync(
        CreateProjectCategory input,
        [Service] IMediator mediator,
        CancellationToken cancellationToken) =>
        await mediator.Send(input, cancellationToken).AsValue();

    [Authorize]
    public async Task<ProjectCategory?> UpdateProjectCategoryAsync(
        UpdateProjectCategory input,
        [Service] IMediator mediator,
        CancellationToken cancellationToken) =>
        await mediator.Send(input, cancellationToken).AsValue();

    [Authorize]
    public async Task<Project?> CreateProjectAsync(
        CreateProject input,
        [Service] IMediator mediator,
        CancellationToken cancellationToken) =>
        await mediator.Send(input, cancellationToken).AsValue();

    [Authorize]
    public async Task<Project?> UpdateProjectAsync(
        UpdateProject input,
        [Service] IMediator mediator,
        CancellationToken cancellationToken) =>
        await mediator.Send(input, cancellationToken).AsValue();

    [Authorize]
    public async Task<Project?> ChangeProjectOrganizationAsync(
        ChangeProjectOrganization input,
        [Service] IMediator mediator,
        CancellationToken cancellationToken) =>
        await mediator.Send(input, cancellationToken).AsValue();
}
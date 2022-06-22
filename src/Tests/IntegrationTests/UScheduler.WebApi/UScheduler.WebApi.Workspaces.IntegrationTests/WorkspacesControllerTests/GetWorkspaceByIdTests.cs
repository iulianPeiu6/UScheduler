using FluentAssertions;
using NUnit.Framework;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using UScheduler.WebApi.Workspaces.Models;

namespace UScheduler.WebApi.Workspaces.IntegrationTests.WorkspacesControllerTests
{
    public class GetWorkspaceByIdTests : IntegrationTestBase
    {
        [Test]
        public async Task Given_ValidWorkspaceId_When_GeWorkspacesByIdIsCalled_Then_ReturnWorkspaceAsync()
        {
            // Arange
            var id = Guid.Parse("c176b60a-62d1-423a-bbfd-82d588800e10");

            // Act
            var response = await testClient.GetAsync($"api/v1/Workspaces/{id}");
            var responseContent = await response.Content.ReadAsStringAsync();
            var workspace = JsonSerializer.Deserialize<WorkspaceDto>(
                responseContent,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            // Asert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            workspace.Should().NotBeNull();
            workspace?.Id.Should().NotBeEmpty();
            workspace?.Owner.Should().NotBeEmpty();
            workspace?.Title.Should().NotBeNullOrEmpty();
            workspace?.Description.Should().NotBeNullOrEmpty();
            workspace?.AccessLevel.Should().NotBeNullOrEmpty();
            workspace?.Colabs.Should().NotBeNullOrEmpty();
            workspace?.WorkspaceTemplate.Should().NotBeNullOrEmpty();
        }

        [Test]
        public async Task Given_InvalidWorkspaceId_When_GeWorkspacesByIdIsCalled_Then_ReturnNotFoundAsync()
        {
            // Arange
            var id = Guid.Parse("c176b60a-62d1-423a-bbfd-82d588800e21");

            // Act
            var response = await testClient.GetAsync($"api/v1/Workspaces/{id}");

            // Asert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}

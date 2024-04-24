using System;
using System.Threading.Tasks;
using CleanArchitecture.IntegrationTests.Infrastructure;
using Xunit;

namespace CleanArchitecture.IntegrationTests.Fixtures;

public sealed class DatabaseFixture : IAsyncLifetime
{
    public static string TestRunDbName { get; } = $"CleanArchitecture-Integration-{Guid.NewGuid()}";

    public async Task DisposeAsync()
    {
        var db = DatabaseAccessor.GetOrCreateAsync(TestRunDbName);
        await db.DisposeAsync();
    }

    public async Task InitializeAsync()
    {
        var db = DatabaseAccessor.GetOrCreateAsync(TestRunDbName);
        await db.InitializeAsync();
    }
}
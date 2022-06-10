using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace AppTest;

public class UnitTest1
{
    private SqliteConnection _connection;
    private DbContextOptions<TodoDb> _contextOptions;

    private TodoDb CreateDbContext() => new TodoDb(_contextOptions);

    public UnitTest1()
    {
        _connection = new SqliteConnection("Filename=:memory:");
        _connection.Open();
        _contextOptions = new DbContextOptionsBuilder<TodoDb>()
            .UseSqlite(_connection)
            .Options;

        using var context = CreateDbContext();
        context.Database.EnsureCreated();
    }

    [Fact]
    public async Task CreateCitySuccessfully()
    {
        var id = Guid.NewGuid();
        var name = "Paris";

        using var context = CreateDbContext();
        var city = new City(id, name);
        context.Cities.Add(city);
        await context.SaveChangesAsync();

        Assert.Single(context.Cities);
        Assert.Contains(city, context.Cities.ToList());
    }
}
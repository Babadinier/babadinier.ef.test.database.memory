namespace AppTest;

public class City
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }

    public City(Guid id, string name)
    {
        Id = id == Guid.Empty ? throw new ArgumentNullException(nameof(id)) : id;
        Name = string.IsNullOrWhiteSpace(name) ? throw new ArgumentNullException(nameof(name)) : name;
    }
}
abstract record Pet;

record Dog(string Name) : Pet;
record Cat(string Name) : Pet;
record Bird(string Name) : Pet;

public static partial class Program
{
    public static void Main()
    {
        Pet pet = new Bird("CoolName");
        var message = pet switch
        {
            Dog dog => $"It's a dog and their name is: {dog.Name}",
            Cat cat => $"It's a cat and their name is: {cat.Name}",
            Bird bird => $"It's a bird and their name is: {bird.Name}",
            _ => throw new Exception("!")
        };

        Console.WriteLine(message);
    }
}
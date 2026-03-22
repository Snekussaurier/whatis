namespace System.Runtime.CompilerServices
{
  public class UnionAttribute : Attribute;
  public interface IUnion { object? Value { get; } }
}

public record Cat(string Name);
public record Dog(string Name);
public record Bird(string Name);

public union Pet(Cat, Dog, Bird);

public static partial class Program
{
  public static void Main()
  {
    Pet pet = new Dog("Cool Name");

    var message = pet switch{
        Dog dog => $"It's a dog and their name is: {dog.Name}",
        Cat cat => $"It's a cat and their name is: {cat.Name}",
        Bird bird => $"It's a bird and their name is: {bird.Name}",
    };

    Console.WriteLine(message);
  }
}
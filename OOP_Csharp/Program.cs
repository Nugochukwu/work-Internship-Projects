public class Animal
{
    public virtual void MakeSound()
    {
        Console.WriteLine("Animal sound");
    }
}

public class Dog : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Bark");
    }
}

public class Cat : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Meow");
    }
}

public class Program
{
    public static void Main()
    {
        Animal[] animals = new Animal[] { new Dog(), new Cat() };

        foreach (Animal animal in animals)
        {
            animal.MakeSound();
        }
        // Output: 
        // Bark
        // Meow
    }
}


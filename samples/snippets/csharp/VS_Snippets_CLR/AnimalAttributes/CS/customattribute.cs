//<Snippet1>
using System;
using System.Reflection;

// An enumeration of animals. Start at 1 (0 = uninitialized).
public enum Animal {
    // Pets.
    Dog = 1,
    Cat,
    Bird,
}

// A custom attribute to allow a target to have a pet.
public class AnimalTypeAttribute : Attribute {
    // The constructor is called when the attribute is set.
    public AnimalTypeAttribute(Animal pet) {
        thePet = pet;
    }

    // Keep a variable internally ...
    protected Animal thePet;

    // .. and show a copy to the outside world.
    public Animal Pet {
        get { return thePet; }
        set { thePet = value; }
    }
}

// A test class where each method has its own pet.
class AnimalTypeTestClass {
    [AnimalType(Animal.Dog)]
    public void DogMethod() {}

    [AnimalType(Animal.Cat)]
    public void CatMethod() {}

    [AnimalType(Animal.Bird)]
    public void BirdMethod() {}
}

class DemoClass {
    static void Main(string[] args) {
        AnimalTypeTestClass testClass = new AnimalTypeTestClass();
        Type type = testClass.GetType();
        // Iterate through all the methods of the class.
        foreach(MethodInfo mInfo in type.GetMethods()) {
            // Iterate through all the Attributes for each method.
            foreach (Attribute attr in
                Attribute.GetCustomAttributes(mInfo)) {
                // Check for the AnimalType attribute.
                if (attr.GetType() == typeof(AnimalTypeAttribute))
                    Console.WriteLine(
                        "Method {0} has a pet {1} attribute.",
                        mInfo.Name, ((AnimalTypeAttribute)attr).Pet);
            }

        }
    }
}
/*
 * Output:
 * Method DogMethod has a pet Dog attribute.
 * Method CatMethod has a pet Cat attribute.
 * Method BirdMethod has a pet Bird attribute.
 */
//</Snippet1>

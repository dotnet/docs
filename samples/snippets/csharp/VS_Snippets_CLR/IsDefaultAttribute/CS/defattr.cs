// <Snippet1>
using System;
using System.Reflection;

namespace DefAttrCS 
{
    // An enumeration of animals. Start at 1 (0 = uninitialized).
    public enum Animal 
    {
        // Pets.
        Dog = 1,
        Cat,
        Bird,
    }

    // A custom attribute to allow a target to have a pet.
    public class AnimalTypeAttribute : Attribute 
    {
        // The constructor is called when the attribute is set.
        public AnimalTypeAttribute(Animal pet) 
        {
            thePet = pet;
        }

        // Provide a default constructor and make Dog the default.
        public AnimalTypeAttribute() 
        {
            thePet = Animal.Dog;
        }

        // Keep a variable internally ...
        protected Animal thePet;

        // .. and show a copy to the outside world.
        public Animal Pet 
        {
            get { return thePet; }
            set { thePet = Pet; }
        }

        // Override IsDefaultAttribute to return the correct response.
        public override bool IsDefaultAttribute() 
        {
            if (thePet == Animal.Dog)
                return true;

            return false;
        }
    }

    public class TestClass 
    {
        // Use the default constructor.
        [AnimalType]
        public void Method1()
        {}
    }

    class DemoClass 
    {
        static void Main(string[] args) 
        {
            // Get the class type to access its metadata.
            Type clsType = typeof(TestClass);
            // Get type information for the method.
            MethodInfo mInfo = clsType.GetMethod("Method1");
            // Get the AnimalType attribute for the method.
            AnimalTypeAttribute atAttr = 
                (AnimalTypeAttribute)Attribute.GetCustomAttribute(mInfo,
                typeof(AnimalTypeAttribute));
            // Check to see if the default attribute is applied.
            Console.WriteLine("The attribute {0} for method {1} in class {2}",
                atAttr.Pet, mInfo.Name, clsType.Name); 
            Console.WriteLine("{0} the default for the AnimalType attribute.", 
                atAttr.IsDefaultAttribute() ? "is" : "is not");
        }
    }
}
// </Snippet1>
using System;

namespace objectoriented
{
    namespace ExampleFromBCL
    {
        //<SnippetEquatable>
        interface IEquatable<T>
        {
            bool Equals(T obj);
        }
        //</SnippetEquatable>
    }

    //<SnippetImplementEquatable>
    public class Car : IEquatable<Car>
    {
        public string? Make { get; set; }
        public string? Model { get; set; }
        public string? Year { get; set; }

        // Implementation of IEquatable<T> interface
        public bool Equals(Car? car)
        {
            return (this.Make, this.Model, this.Year) ==
                (car?.Make, car?.Model, car?.Year);
        }
    }
    //</SnippetImplementEquatable>

    // <SnippetInternalInterfaceExample>
    // Internal type that cannot be exposed publicly
    internal class InternalConfiguration
    {
        public string Setting { get; set; } = "";
    }

    // Interface with internal accessibility using internal types
    internal interface IConfigurable
    {
        void Configure(InternalConfiguration config);
    }

    // This class shows explicit interface implementation
    // to work with internal interfaces
    public class ServiceImplementation : IConfigurable
    {
        // Explicit implementation - no access modifier allowed
        // This method is not publicly accessible on the class
        void IConfigurable.Configure(InternalConfiguration config)
        {
            // Implementation here
            Console.WriteLine($"Configured with: {config.Setting}");
        }
        
        // If we tried implicit implementation, this wouldn't compile:
        // public void Configure(InternalConfiguration config) // Error: cannot expose internal type
    }
    // </SnippetInternalInterfaceExample>


}

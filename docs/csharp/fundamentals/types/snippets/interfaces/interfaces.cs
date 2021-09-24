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
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }

        // Implementation of IEquatable<T> interface
        public bool Equals(Car car)
        {
            return (this.Make, this.Model, this.Year) ==
                (car.Make, car.Model, car.Year);
        }
    }
    //</SnippetImplementEquatable>


}

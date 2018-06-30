    public class Car : IEquatable<Car>
    {
        public string Make {get; set;}
        public string Model { get; set; }
        public string Year { get; set; }

        // Implementation of IEquatable<T> interface
        public bool Equals(Car car)
        {
            return this.Make == car.Make &&
                   this.Model == car.Model &&
                   this.Year == car.Year;
        }
    }

public class AnimalShelter
{
    private Dog _nextDogToBeAdopted = AnimalShelter.AdoptDog()
    public static Dog AdoptDog() => new Dog();
}

public class Pet
{
    public void ActCute(){};
}

public class Dog : Pet {}

public class Car
{
    public void Accelerate() {}
}

Dog dog = AnimalShelter.AdoptDog(); // Returns a Dog type.
Pet pet = (Pet)dog; // Dog derives from Pet.
pet.ActCute();
Car car = (Car)dog; // Will throw - no relationship between Car and Dog.
object temp = (object)dog; // Legal - a Dog is an object.
car = (Car)temp; // Will throw - the runtime isn't fooled.

Dog dog = AnimalShelter._nextDogToBeAdopted; // will throw - this is a private field

var dog = AnimalShelter.AdoptDog();
var pet = (Pet)dog;
pet.ActCute();
Car car = (Car)dog; // will throw - no relationship between Car and Dog
object temp = (object)dog; // legal - a Dog is an object
car = (Car)temp; // will throw - the runtime isn't fooled
car.Accelerate() // the dog won't like this, nor will the program get this far
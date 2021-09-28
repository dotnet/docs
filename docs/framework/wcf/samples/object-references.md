---
description: "Learn more about: Object References"
title: "Object References"
ms.date: "03/30/2017"
ms.assetid: 7a93d260-91c3-4448-8f7a-a66fb562fc23
---
# Object References

The [ObjectReferences sample](https://github.com/dotnet/samples/tree/main/framework/wcf) demonstrates how to pass objects by references between server and client. The sample uses simulated *social networks*. A social network consists of a `Person` class that contains a list of friends in which each friend is an instance of the `Person` class, with its own list of friends. This creates a graph of objects. The service exposes operations on these social networks.

In this sample, the service is hosted by Internet Information Services (IIS) and the client is a console application (.exe).

> [!NOTE]
> The setup procedure and build instructions for this sample are located at the end of this topic.

## Service

The `Person` class has the <xref:System.Runtime.Serialization.DataContractAttribute> attribute applied, with the <xref:System.Runtime.Serialization.DataContractAttribute.IsReference%2A> field set to `true` to declare it as a reference type. All properties have the <xref:System.Runtime.Serialization.DataMemberAttribute> attribute applied.

```csharp
[DataContract(IsReference=true)]
public class Person
{
    string name;
    string location;
    string gender;
    int age;
    List<Person> friends;
    [DataMember()]
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    [DataMember()]
    public string Location
    {
        get { return location; }
        set { location = value; }
    }
    [DataMember()]
    public string Gender
    {
        get { return gender; }
        set { gender = value; }
    }
…
}
```

The `GetPeopleInNetwork` operation takes a parameter of type `Person` and returns all the people in the network; that is, all the people in the `friends` list, the friend's friends, and so on, without duplicates.

```csharp
public List<Person> GetPeopleInNetwork(Person p)
{
    List<Person> people = new List<Person>();
    ListPeopleInNetwork(p, people);
    return people;

}
```

The `GetMutualFriends` operation takes a parameter of type `Person` and returns all the friends in the list who also have this person in their `friends` list.

```csharp
public List<Person> GetMutualFriends(Person p)
{
    List<Person> mutual = new List<Person>();
    foreach (Person friend in p.Friends)
    {
        if (friend.Friends.Contains(p))
            mutual.Add(friend);
    }
    return mutual;
}
```

The `GetCommonFriends` operation takes a list of type `Person`. The list is expected to have two `Person` objects in it. The operation returns a list of `Person` objects that are in the `friends` lists of both `Person` objects in the input list.

```csharp
public List<Person> GetCommonFriends(List<Person> people)
{
    List<Person> common = new List<Person>();
    foreach (Person friend in people[0].Friends)
        if (people[1].Friends.Contains(friend))
            common.Add(friend);
    return common;
}
```

## Client

The client proxy is created using the **Add Service Reference** feature of Visual Studio.

A social network that consists of five `Person` objects is created. The client calls each of the three methods in the service.

#### To set up, build, and run the sample

1. Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](one-time-setup-procedure-for-the-wcf-samples.md).

2. To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](building-the-samples.md).

3. To run the sample in a single- or cross-machine configuration, follow the instructions in [Running the Windows Communication Foundation Samples](running-the-samples.md).

## See also

- <xref:System.Runtime.Serialization.DataContractAttribute.IsReference%2A>
- [Interoperable Object References](../feature-details/interoperable-object-references.md)

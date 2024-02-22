// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


// <BasePrimaryConstructor>
public class NamedItem(string name)
{
    public string Name => name;
}
// </BasePrimaryConstructor>

// <DerivedPrimaryConstructor>
// name isn't captured in Widget.
// width, height, and depth are captured as private fields
public class Widget(string name, int width, int height, int depth) : NamedItem(name)
{
    public Widget() : this("N/A", 1,1,1) {} // unnamed unit cube

    public int WidthInCM => width;
    public int HeightInCM => height;
    public int DepthInCM => depth;

    public int Volume => width * height * depth;
}
// </DerivedPrimaryConstructor>

public class MyAttribute:  System.Attribute
{
}

// <PrimaryConstructorAttribute>
[method: MyAttribute]
public class TaggedWidget(string name)
{
   // details elided
}
// </PrimaryConstructorAttribute>


#pragma warning disable CS0414 // Field is assigned but never read (snippets demonstrate declaration patterns)

namespace FieldInit
{
    // <ContainerFieldInitializer>
    public class Container
    {
        private int _capacity = 10;
    }
    // </ContainerFieldInitializer>
}

namespace ConstructorInit
{
    // <ContainerConstructor>
    public class Container
    {
        private int _capacity;

        public Container(int capacity) => _capacity = capacity;
    }
    // </ContainerConstructor>
}

namespace PrimaryInit
{
    // <ContainerPrimaryConstructor>
    public class Container(int capacity)
    {
        private int _capacity = capacity;
    }
    // </ContainerPrimaryConstructor>
}

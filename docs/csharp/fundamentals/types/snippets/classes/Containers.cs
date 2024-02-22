namespace Version1
{
    // <ContainerFieldInitializer>
    public class Container
    {
        // Initialize capacity field to a default value of 10:
        private int _capacity = 10;
    }
    // </ContainerFieldInitializer>
}

namespace Version2
{
    // <ContainerConstructor>
    public class Container
    {
        private int _capacity;

        public Container(int capacity) => _capacity = capacity;
    }
    // </ContainerConstructor>
}

namespace Version3
{
    // <ContainerPrimaryConstructor>
    public class Container(int capacity)
    {
        private int _capacity = capacity;
    }
    // </ContainerPrimaryConstructor>
}

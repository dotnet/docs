using System;

namespace objectoriented
{
    namespace defaultaccess
    {
        //<SnippetDeclareNestedClass>
        public class Container
        {
            class Nested
            {
                Nested() { }
            }
        }
        //</SnippetDeclareNestedClass>
    }

    namespace publicaccess
    {
        //<SnippetPublicNestedClass>
        public class Container
        {
            public class Nested
            {
                Nested() { }
            }
        }
        //</SnippetPublicNestedClass>
    }

    //<SnippetDeclareNestedInstance>
    public class Container
    {
        public class Nested
        {
            private Container? parent;

            public Nested()
            {
            }
            public Nested(Container parent)
            {
                this.parent = parent;
            }
        }
    }
    //</SnippetDeclareNestedInstance>

    public static class NestedTypes
    {
        public static void Example()
        {
            //<SnippetUseNestedInstance>
            Container.Nested nest = new Container.Nested();
            //</SnippetUseNestedInstance>
        }
    }
}

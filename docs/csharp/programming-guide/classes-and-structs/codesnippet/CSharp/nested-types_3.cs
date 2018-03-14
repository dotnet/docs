        public class Container
        {
            public class Nested
            {
                private Container parent;

                public Nested()
                {
                }
                public Nested(Container parent)
                {
                    this.parent = parent;
                }
            }
        }
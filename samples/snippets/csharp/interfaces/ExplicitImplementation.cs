using System;

namespace interfaces
{
    public class InterfaceSnippets
    {
        public static void TestInterfaces()
        {
            InheritMultipleInterfaces.MultipleInterfaceMethods();
            MultipleExplicitImplementation.CallExplicitImplementation();
            DefaultInterfaceMethods.CallDefaultImplementation();
        }

        private static class InheritMultipleInterfaces
        {
            // <SnippetDefineTypes>
            public interface IControl
            {
                void Paint();
            }
            public interface ISurface
            {
                void Paint();
            }
            public class SampleClass : IControl, ISurface
            {
                // Both ISurface.Paint and IControl.Paint call this method.
                public void Paint()
                {
                    Console.WriteLine("Paint method in SampleClass");
                }
            }
            // </SnippetDefineTypes>

            public static void MultipleInterfaceMethods()
            {
                // <SnippetCallMethods>
                SampleClass sample = new SampleClass();
                IControl control = sample;
                ISurface surface = sample;

                // The following lines all call the same method.
                sample.Paint();
                control.Paint();
                surface.Paint();
                
                // Output:
                // Paint method in SampleClass
                // Paint method in SampleClass
                // Paint method in SampleClass
                // </SnippetCallMethods>
            }
        }

        private static class MultipleExplicitImplementation
        {
            public interface IControl
            {
                void Paint();
            }
            public interface ISurface
            {
                void Paint();
            }
            // <SnippetExplicitImplementation>
            public class SampleClass : IControl, ISurface
            {
                void IControl.Paint()
                {
                    System.Console.WriteLine("IControl.Paint");
                }
                void ISurface.Paint()
                {
                    System.Console.WriteLine("ISurface.Paint");
                }
            }
            // </SnippetExplicitImplementation>

            public static void CallExplicitImplementation()
            {
                //<SnippetCallExplicitImplementation>
                SampleClass sample = new SampleClass();
                IControl control = sample;
                ISurface surface = sample;

                // The following lines all call the same method.
                //sample.Paint(); // Compiler error.
                control.Paint();  // Calls IControl.Paint on SampleClass.
                surface.Paint();  // Calls ISurface.Paint on SampleClass.
                
                // Output:
                // IControl.Paint
                // ISurface.Paint
                //</SnippetCallExplicitImplementation>
           }
        }

        private static class NameCollisions
        {
            //<SnippetNameCollision>
            interface ILeft
            {
                int P { get;}
            }
            interface IRight
            {
                int P();
            }

            class Middle : ILeft, IRight
            {
                public int P() { return 0; }
                int ILeft.P { get { return 0; } }
            }
            //</SnippetNameCollision>
        }

        private static class DefaultInterfaceMethods
        {
            // <SnippetDefaultImplementation>
            public interface IControl
            {
                void Paint() => Console.WriteLine("Default Paint method");
            }
            public class SampleClass : IControl
            {
                // Paint() is inherited from IControl.
            }
            // </SnippetDefaultImplementation>
            public static void CallDefaultImplementation()
            {
                // <SnippetCallDefaultImplementation>
                var sample = new SampleClass();
                //sample.Paint();// "Paint" isn't accessible.
                var control = sample as IControl;
                control.Paint();
                // </SnippetCallDefaultImplementation>
            }
        }
    }
}


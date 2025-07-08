using System;

namespace ContravarianceExample
{
    // <snippet1>
    // Custom EventArgs classes to demonstrate the hierarchy
    public class KeyEventArgs(string keyCode) : EventArgs
    {
        public string KeyCode { get; set; } = keyCode;
    }

    public class MouseEventArgs(int x, int y) : EventArgs  
    {
        public int X { get; set; } = x;
        public int Y { get; set; } = y;
    }

    // Define delegate types that match the Windows Forms pattern
    public delegate void KeyEventHandler(object sender, KeyEventArgs e);
    public delegate void MouseEventHandler(object sender, MouseEventArgs e);

    // A simple class that demonstrates contravariance with events
    public class Button
    {
        // Events that expect specific EventArgs-derived types
        public event KeyEventHandler? KeyDown;
        public event MouseEventHandler? MouseClick;

        // Method to simulate key press
        public void SimulateKeyPress(string key)
        {
            Console.WriteLine($"Simulating key press: {key}");
            KeyDown?.Invoke(this, new KeyEventArgs(key));
        }

        // Method to simulate mouse click  
        public void SimulateMouseClick(int x, int y)
        {
            Console.WriteLine($"Simulating mouse click at ({x}, {y})");
            MouseClick?.Invoke(this, new MouseEventArgs(x, y));
        }
    }

    public class Form1
    {
        private Button button1;

        public Form1()
        {
            button1 = new Button();
            
            // Event handler that accepts a parameter of the base EventArgs type.
            // This method can handle events that expect more specific EventArgs-derived types
            // due to contravariance in delegate parameters.
            
            // You can use a method that has an EventArgs parameter,
            // although the KeyDown event expects the KeyEventArgs parameter.
            button1.KeyDown += MultiHandler;

            // You can use the same method for an event that expects 
            // the MouseEventArgs parameter.
            button1.MouseClick += MultiHandler;
        }

        // Event handler that accepts a parameter of the base EventArgs type.
        // This works for both KeyDown and MouseClick events because:
        // - KeyDown expects KeyEventHandler(object sender, KeyEventArgs e)
        // - MouseClick expects MouseEventHandler(object sender, MouseEventArgs e)  
        // - Both KeyEventArgs and MouseEventArgs derive from EventArgs
        // - Contravariance allows a method with a base type parameter (EventArgs)
        //   to be used where a derived type parameter is expected
        private void MultiHandler(object sender, EventArgs e)
        {
            Console.WriteLine($"MultiHandler called at: {DateTime.Now:HH:mm:ss.fff}");
            
            // You can check the actual type of the event args if needed
            switch (e)
            {
                case KeyEventArgs keyArgs:
                    Console.WriteLine($"  - Key event: {keyArgs.KeyCode}");
                    break;
                case MouseEventArgs mouseArgs:
                    Console.WriteLine($"  - Mouse event: ({mouseArgs.X}, {mouseArgs.Y})");
                    break;
                default:
                    Console.WriteLine($"  - Generic event: {e.GetType().Name}");
                    break;
            }
        }

        public void DemonstrateEvents()
        {
            Console.WriteLine("Demonstrating contravariance in event handlers:");
            Console.WriteLine("Same MultiHandler method handles both events!\n");
            
            button1.SimulateKeyPress("Enter");
            button1.SimulateMouseClick(100, 200);
            button1.SimulateKeyPress("Escape");
            button1.SimulateMouseClick(50, 75);
        }
    }
    // </snippet1>

    // <snippet2>
    // Demonstration of how contravariance works with delegates:
    // 
    // 1. KeyDown event signature: KeyEventHandler(object sender, KeyEventArgs e)
    //    where KeyEventArgs derives from EventArgs
    //
    // 2. MouseClick event signature: MouseEventHandler(object sender, MouseEventArgs e)  
    //    where MouseEventArgs derives from EventArgs
    //
    // 3. Our MultiHandler method signature: MultiHandler(object sender, EventArgs e)
    //
    // 4. Contravariance allows us to use MultiHandler (which expects EventArgs)
    //    for events that provide more specific types (KeyEventArgs, MouseEventArgs)
    //    because the more specific types can be safely treated as their base type.
    //
    // This is safe because:
    // - The MultiHandler only uses members available on the base EventArgs type
    // - KeyEventArgs and MouseEventArgs can be implicitly converted to EventArgs
    // - The compiler knows that any EventArgs-derived type can be passed safely
    // </snippet2>

    class Program
    {
        static void Main()
        {
            var form = new Form1();
            form.DemonstrateEvents();
        }
    }
}
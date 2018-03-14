
/*

   This sample demonstrates the Freezable class.

*/

using System;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace Microsoft.Samples.Animation.LocalAnimations
{

    // Displays the sample.
    public class MyApp : Application
    {
        

        protected override void OnStartup (StartupEventArgs e)
        {
            base.OnStartup(e);
            CreateAndShowMainWindow();
        }


        private void CreateAndShowMainWindow ()
        {
            // Create the application's main window.
            NavigationWindow myWindow = new NavigationWindow();
            
            // Display the sample
            Page myContent = new FreezableExample();
            myWindow.Navigate(myContent);
            MainWindow = myWindow;
            myWindow.Show();
        }
    }
    
    
    public class FreezableExample : Page
    {
    
        private StackPanel myMainPanel;
    
        public FreezableExample()
        {
           this.WindowTitle = "Freezable Example";
          
            
            myMainPanel = new StackPanel();
            UnFrozenExample();
            FrozenExample();
            CloneExample();
            exceptionExample();
            this.Content = myMainPanel;
            
        }
        
        private void UnFrozenExample()
        {
        
            // <SnippetUnFrozenExampleShort>
            Button myButton = new Button();
            SolidColorBrush myBrush = new SolidColorBrush(Colors.Yellow);
            myButton.Background = myBrush;  
            
            
            // Changes the button's background to red.
            myBrush.Color = Colors.Red;
            // </SnippetUnFrozenExampleShort>
            
            myMainPanel.Children.Add(myButton);
        }
        
        private void FrozenExample()
        {
            // <SnippetFrozenExamplePart1>
            Button myButton = new Button();
            SolidColorBrush myBrush = new SolidColorBrush(Colors.Yellow);
            myButton.Background = myBrush;  
            // </SnippetFrozenExamplePart1>
            
            // <SnippetFrozenExamplePart2>
            if (myBrush.CanFreeze)
            {
                // Makes the brush unmodifiable.
                myBrush.Freeze();
            }
            // </SnippetFrozenExamplePart2>
            
            myMainPanel.Children.Add(myButton);
        } 
        
        private void exceptionExample()
        {
        
            // <SnippetExceptionExample>

            // <SnippetFreezeExample1>
            Button myButton = new Button();
            SolidColorBrush myBrush = new SolidColorBrush(Colors.Yellow);          

            if (myBrush.CanFreeze)
            {
                // Makes the brush unmodifiable.
                myBrush.Freeze();
            }
            
            myButton.Background = myBrush;  
            // </SnippetFreezeExample1>

            try {
            
                // Throws an InvalidOperationException, because the brush is frozen.
                myBrush.Color = Colors.Red;
            }catch(InvalidOperationException ex)
            {
                MessageBox.Show("Invalid operation: " + ex.ToString());
            }

            // </SnippetExceptionExample>

            myMainPanel.Children.Add(myButton);        
        
        
        }

        private void checkIsFrozenExample()
        {

            // <SnippetCheckIsFrozenExample>

            Button myButton = new Button();
            SolidColorBrush myBrush = new SolidColorBrush(Colors.Yellow);
            
            if (myBrush.CanFreeze)
            {
                // Makes the brush unmodifiable.
                myBrush.Freeze();
            }            
            
            myButton.Background = myBrush;


            if (myBrush.IsFrozen) // Evaluates to true.
            {
                // If the brush is frozen, create a clone and
                // modify the clone.
                SolidColorBrush myBrushClone = myBrush.Clone();
                myBrushClone.Color = Colors.Red;
                myButton.Background = myBrushClone;
            }
            else
            {
                // If the brush is not frozen,
                // it can be modified directly.
                myBrush.Color = Colors.Red;
            }


            // </SnippetCheckIsFrozenExample>

            myMainPanel.Children.Add(myButton);


        }    
     
        
        
        
        private void CloneExample()
        {
        
            // <SnippetCloneExample>
            Button myButton = new Button();
            SolidColorBrush myBrush = new SolidColorBrush(Colors.Yellow);
            
            // Freezing a Freezable before it provides
            // performance improvements if you don't
            // intend on modifying it. 
            if (myBrush.CanFreeze)
            {
                // Makes the brush unmodifiable.
                myBrush.Freeze();
            }
                        
            
            myButton.Background = myBrush;  
            
            // If you need to modify a frozen brush,
            // the Clone method can be used to
            // create a modifiable copy.
            SolidColorBrush myBrushClone = myBrush.Clone();
            
            // Changing myBrushClone does not change
            // the color of myButton, because its
            // background is still set by myBrush.
            myBrushClone.Color = Colors.Red;
            
            // Replacing myBrush with myBrushClone
            // makes the button change to red.
            myButton.Background = myBrushClone;
            // </SnippetCloneExample>
            
            
            
            myMainPanel.Children.Add(myButton);
        }


     
    
    
    }
    
    // <SnippetCreateInstanceCoreExample>
    public class MyFreezable : Freezable
    {
        // Typical implementation of CreateInstanceCore
        protected override Freezable CreateInstanceCore()
        {
        
            return new MyFreezable();      
        }


        // ...
        // Other code for the MyFreezableClass.
        // ...
        
        
    }
    
    // </SnippetCreateInstanceCoreExample>    
    
    

    // Starts the application.
    internal sealed class EntryClass
    {
        [System.STAThread()]
        private static void Main ()
        {
            
            MyApp app = new MyApp ();
            app.Run ();
        }
    }
}

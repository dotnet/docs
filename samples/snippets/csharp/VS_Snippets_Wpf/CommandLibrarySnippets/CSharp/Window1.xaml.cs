using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Input;


namespace SDKSamples
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {

        public Window1()
        {
            InitializeComponent();

           

        }


        // <SnippetKeyGestureGetProperties>
        private void CmdExecutedHandler(object sender, ExecutedRoutedEventArgs e)
        {
            // This method gets the KeyGestures Associated with a Command 
            // and displays the Key and ModifierKeys properties.

            RoutedCommand cmd = e.Command as RoutedCommand;
            ModifierKeys modifierKey;
            Key key;

            foreach (InputGesture gesture in cmd.InputGestures)
            {
                key = ((KeyGesture)gesture).Key;
                modifierKey = ((KeyGesture)gesture).Modifiers;

                // Outputs the key and modifierKeys ToString to a TextBox
                txtResults.Text += "The KeyGesture is: " +
                    key.ToString() +
                    "+" +
                    modifierKey.ToString() +
                    "\n";
            }
        }
        // </SnippetKeyGestureGetProperties>

        private void OnLoaded(object sender, RoutedEventArgs e)
        {


            // <SnippetKeyBindingKeyGestureSetProperties>
            // Defining the KeyGesture.
            KeyGesture FindCmdKeyGesture = new KeyGesture(Key.F,
                (ModifierKeys.Shift | ModifierKeys.Alt));
          
            // Defining the KeyBinding.
            KeyBinding FindKeyBinding = new KeyBinding(
                ApplicationCommands.Find, FindCmdKeyGesture);
            
            // Binding the KeyBinding to the Root Window.
            this.InputBindings.Add(FindKeyBinding);
            // </SnippetKeyBindingKeyGestureSetProperties>

            // <SnippetKeyBindingWithNoModifier>
            KeyGesture OpenCmdKeyGesture = new KeyGesture(Key.F12);
            KeyBinding OpenKeyBinding = new KeyBinding(
                ApplicationCommands.Open,
                OpenCmdKeyGesture);

            this.InputBindings.Add(OpenKeyBinding);
            // </SnippetKeyBindingWithNoModifier>

            // <SnippetKeyBindingWithKeyAndModifiers>
            KeyGesture CloseCmdKeyGesture = new KeyGesture(
                Key.L, ModifierKeys.Alt);

            KeyBinding CloseKeyBinding = new KeyBinding(
                ApplicationCommands.Close, CloseCmdKeyGesture);

            this.InputBindings.Add(CloseKeyBinding);
            // </SnippetKeyBindingWithKeyAndModifiers>

            // <SnippetKeyBindingMultipleModifiers>
            KeyBinding CopyKeyBinding = new KeyBinding(
                ApplicationCommands.Copy, Key.D,
                (ModifierKeys.Control | ModifierKeys.Shift));

            this.InputBindings.Add(CopyKeyBinding);
            // </SnippetKeyBindingMultipleModifiers>

            // <SnippetKeyBindingDefatulCtor>
            KeyBinding RedoKeyBinding = new KeyBinding();
            RedoKeyBinding.Modifiers = ModifierKeys.Alt;
            RedoKeyBinding.Key = Key.F;
            RedoKeyBinding.Command = ApplicationCommands.Redo;

            this.InputBindings.Add(RedoKeyBinding);
            // </SnippetKeyBindingDefatulCtor>

            // <SnippetMouseBindingAddedToInputBinding>
            MouseGesture OpenCmdMouseGesture = new MouseGesture();
            OpenCmdMouseGesture.MouseAction = MouseAction.WheelClick;
            OpenCmdMouseGesture.Modifiers = ModifierKeys.Control;

            MouseBinding OpenCmdMouseBinding = new MouseBinding();
            OpenCmdMouseBinding.Gesture = OpenCmdMouseGesture;
            OpenCmdMouseBinding.Command = ApplicationCommands.Open;

            this.InputBindings.Add(OpenCmdMouseBinding);
            // </SnippetMouseBindingAddedToInputBinding>

            // <SnippetMouseBindingAddedCommand>
            MouseGesture PasteCmdMouseGesture = new MouseGesture(
                MouseAction.MiddleClick, ModifierKeys.Alt);

            ApplicationCommands.Paste.InputGestures.Add(PasteCmdMouseGesture);
            // </SnippetMouseBindingAddedCommand>

            KeyGesture pasteBind = new KeyGesture(Key.V, ModifierKeys.Alt);
            ApplicationCommands.Paste.InputGestures.Add(pasteBind);

            // <SnippetInputBindingAddingComand>
            KeyGesture HelpCmdKeyGesture = new KeyGesture(Key.H,
                ModifierKeys.Alt);

            InputBinding inputBinding;
            inputBinding = new InputBinding(ApplicationCommands.Help,
                HelpCmdKeyGesture);

            this.InputBindings.Add(inputBinding);
            // </SnippetInputBindingAddingComand>

            // <SnippetMouseBindingMouseAction> 
            MouseGesture CutCmdMouseGesture = new MouseGesture(
                MouseAction.MiddleClick);

            MouseBinding CutMouseBinding = new MouseBinding(
                ApplicationCommands.Cut, 
                CutCmdMouseGesture);
            
            // RootWindow is an instance of Window.
            RootWindow.InputBindings.Add(CutMouseBinding);
            // </SnippetMouseBindingMouseAction> 

            // <SnippetMouseBindingGesture>
            MouseGesture NewCmdMouseGesture = new MouseGesture();
            NewCmdMouseGesture.Modifiers = ModifierKeys.Alt;
            NewCmdMouseGesture.MouseAction = MouseAction.MiddleClick;

            MouseBinding NewMouseBinding = new MouseBinding();
            NewMouseBinding.Command = ApplicationCommands.New;
            NewMouseBinding.Gesture = NewCmdMouseGesture;

            // RootWindow is an instance of Window. 
            RootWindow.InputBindings.Add(NewMouseBinding);
            // </SnippetMouseBindingGesture>
        }


        private void MyCommandExecute(object sender, ExecutedRoutedEventArgs e)
        {
            RoutedUICommand srcCommand = e.Command as RoutedUICommand;
            txtGesture.Text = string.Empty;
            txtGesture.FontWeight = FontWeights.Heavy;
            txtGesture.Text += "Command:  " + srcCommand.Name + "\n";
            txtGesture.Text += "Owner Type:  " + srcCommand.OwnerType.ToString() + "\n";
            txtGesture.Text += "Text :  " + srcCommand.Text + "\n" + "\n" + "\n";
            txtGesture.FontWeight = FontWeights.Normal;
            if (srcCommand != null)
            {
                txtGesture.Text += "Number of Gestures: " + srcCommand.InputGestures.Count.ToString() + "\n";
                if (srcCommand.InputGestures.Count == 0)
                {
                    txtGesture.Text += "\n" + "No Gestures";
                }
                else
                {
                    foreach (InputGesture gesture in srcCommand.InputGestures)
                    {
                        txtGesture.Text += "\n" + gesture.ToString() + "\n";

                        KeyGesture keyGesture = gesture as KeyGesture;
                        if (keyGesture != null)
                        {
                            txtGesture.Text += "Key: " + keyGesture.Key.ToString() + "\n";
                            txtGesture.Text += "Modifers: " + keyGesture.Modifiers.ToString() + "\n";
                        }

                        txtGesture.Text += "\n";

                        MouseGesture mouseGesture = gesture as MouseGesture;
                        if (mouseGesture != null)
                        {
                            txtGesture.Text += "Mouse Action: " + mouseGesture.MouseAction.ToString() + "\n";
                            txtGesture.Text += "Modifers: " + mouseGesture.Modifiers.ToString() + "\n";
                        }
                        if (mouseGesture == null)
                        {
                            txtGesture.Text += "No Mouse Gestures" + "\n";
                        }
                   
                    }
                }
              //   cmdButton.Command = srcCommand;

            }
            
        }

        // <SnippetKeyDownHandlerKeyGestureMatches>
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            KeyGesture keyGesture = new KeyGesture(Key.B, ModifierKeys.Control);

            if(keyGesture.Matches(null, e))
            {
                MessageBox.Show("Trapped Key Gesture");
            }
        }
        // </SnippetKeyDownHandlerKeyGestureMatches>

        // <SnippetKeyDownHandlerMouseGestureMatches>
        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            MouseGesture mouseGesture = new MouseGesture(MouseAction.MiddleClick,ModifierKeys.Control);

            if (mouseGesture.Matches(null, e))
            {
                MessageBox.Show("Trapped Mouse Gesture");
            }
        }
        // </SnippetKeyDownHandlerMouseGestureMatches>

        private void MyCanExecuteCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void cmdButtonClick(object sender, RoutedEventArgs e)
        {
            txtGesture.Text = String.Empty;
            txtGesture.Text += "Windows Input Bindings \n";
            foreach (InputBinding binding in this.InputBindings)
            {
                KeyGesture gesture = binding.Gesture as KeyGesture;
                if (gesture != null)
                {
                    txtGesture.Text += gesture.Key.ToString() + 
                        "   " + 
                        gesture.Modifiers.ToString() + "   " + 
                        ((RoutedCommand)binding.Command).Name + "\n";
                }

            }

        }

    }
}
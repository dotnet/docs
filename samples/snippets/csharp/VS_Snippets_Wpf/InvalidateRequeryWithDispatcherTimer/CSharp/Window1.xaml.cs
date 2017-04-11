using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows.Threading;
using System.Globalization;


namespace SDKSamples
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
   
    public partial class Window1 : Window
    {
        //  The custom routed command.
        public static RoutedCommand customCommand = new RoutedCommand();

        //  The timer.
        private System.Windows.Threading.DispatcherTimer dispatcherTimer;

        public Window1()
        {
            InitializeComponent();

            //<SnippetInvalidateSampleDispatcherTimerInit>
            //  DispatcherTimer setup
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0,0,1);
            dispatcherTimer.Start();
            //</SnippetInvalidateSampleDispatcherTimerInit>
        }
        
        //<SnippetInvalidateSampleDispatcherTimer>
        //  System.Windows.Threading.DispatcherTimer.Tick handler
        //
        //  Updates the current seconds display and calls
        //  InvalidateRequerySuggested on the CommandManager to force 
        //  the Command to raise the CanExecuteChanged event.
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            // Updating the Label which displays the current second
            lblSeconds.Content = DateTime.Now.Second;

            // Forcing the CommandManager to raise the RequerySuggested event
            CommandManager.InvalidateRequerySuggested();
        }
        //</SnippetInvalidateSampleDispatcherTimer>

        //<SnippetInvalidateSampleExecuted>
        //  Executed Event Handler
        //
        //  Updates the output TextBox with the current seconds 
        //  and the target second, which is passed through Args.Parameter.
        private void CustomCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            txtResults.Text = "Command Executed at " +
                DateTime.Now.Second + " seconds after the minute \n\n" +
                "The target second is set to " +
                e.Parameter;
        }
        //</SnippetInvalidateSampleExecuted>

        //<SnippetInvalidateSampleCanExecute>
        //CanExecute Event Handler
        //
        //  Retrun True, if the current seconds are greater than the target value
        //  which is set on the Slider that is defined in the XMAL file.
        private void CustomCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (secondSlider != null)
            {
                if (DateTime.Now.Second > secondSlider.Value)
                {
                    e.CanExecute = true;
                }
                else
                {
                    e.CanExecute = false;
                }
            }
            else
            {
                e.CanExecute = false;
            }
        }
        //</SnippetInvalidateSampleCanExecute>

        //<SnippetInvalidateSampleWheelHandler>
        // Moves the slider when the mouse wheel is rotated.
        private void OnSliderMouseWheel(object sender, MouseWheelEventArgs e)
        {
            Slider source = e.Source as Slider;

            if (source != null)
            {

                if (e.Delta > 0)
                {
                    //execute the Slider DecreaseSmall RoutedCommand
                    //the slider.value propety is passed as the command parameter
                    ((RoutedCommand)Slider.DecreaseSmall).Execute(
                        source.Value,source);

                }
                else
                {
                    //execute the Slider IncreaseSmall RoutedCommand
                    //the slider.value propety is passed as the command parameter
                    ((RoutedCommand)Slider.IncreaseSmall).Execute(
                        source.Value,source);
                }
            }
        }
        //</SnippetInvalidateSampleWheelHandler>

        //<SnippetInvalidateSampleMouseUpHandler>
        // Moves the slider when the mouse extended buttons are pressed.
        private void OnSliderMouseUp(object sender, MouseButtonEventArgs e)
        {
            Slider source = e.Source as Slider;

            if (source != null)
            {
                if (e.ChangedButton == MouseButton.XButton1)
                {
                    //  Execute the Slider DecreaseSmall RoutedCommand
                    //  The slider.value propety is passed as the command parameter
                    ((RoutedCommand)Slider.DecreaseSmall).Execute(
                        source.Value, source);
                }
                if (e.ChangedButton == MouseButton.XButton2)
                {
                    //  Execute the Slider IncreaseSmall RoutedCommand
                    //  The slider.value propety is passed as the command parameter
                    ((RoutedCommand)Slider.IncreaseSmall).Execute(
                        source.Value, source);
                }
            }
        //</SnippetInvalidateSampleMouseUpHandler>
        }
    }

    //Converter to convert the Slider value property from a Double to an Int
    [ValueConversion(typeof(double), typeof(int))]
    public class SliderValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter,
            CultureInfo culture)
        {
            double sliderValue = (double)value;

            return (int)sliderValue;
        }

        public object ConvertBack(object value, Type targetType,
            object parameter,
            CultureInfo culture)
        {
            return null;
        }
    }
}
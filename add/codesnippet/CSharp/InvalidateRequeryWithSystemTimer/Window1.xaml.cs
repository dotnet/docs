using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows.Threading;
using System.Timers;  
using System.Globalization;

namespace SDKSamples
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {
        // The custom routed command.
        public static RoutedCommand customCommand = new RoutedCommand();

        // The timer. 
        private System.Timers.Timer timer;

        // Delegate for thr worker item to place on the Dispatcher
        private delegate void TimerDispatcherDelegate();

        public Window1()
        {
            InitializeComponent();

            // System Timer setup.
            timer = new System.Timers.Timer();
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            timer.Interval = 1000;
            timer.Enabled = true;
        }

        // System.Timers.Timer.Elapsed handler
        //<SnippetSystemTimerDispatcherInvoke>
        // Places the delegate onto the UI Thread's Dispatcher
        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // Place delegate on the Dispatcher.
            this.Dispatcher.Invoke(DispatcherPriority.Normal,
                new TimerDispatcherDelegate(TimerWorkItem));
        }
        //</SnippetSystemTimerDispatcherInvoke>

        // Method to place onto the UI thread's dispatcher.
        // Updates the current second display and calls 
        // InvalidateRequerySuggested on the CommandManager to force the
        // Command to raise the CanExecuteChanged event.
        private void TimerWorkItem()
        {
            // Update current second display.
            lblSeconds.Content = DateTime.Now.Second;

            // Forcing the CommandManager to raie the RequerySuggested event.
            CommandManager.InvalidateRequerySuggested();
        }

        // Executed Event Handler.
        //
        // Updates the result TextBox with the current seconds and the 
        // target second, which is the value passed from the command source.
        private void CustomCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            txtResults.Text = "Command Executed at " +
                DateTime.Now.Second + " seconds after the minute \n\n" +
                "The target second is set to " +
                e.Parameter;
        }

        // CanExecute Event Handler.
        //
        // True if the current seconds are greater than the target value that is 
        // set on the Slider, which is defined in the XMAL file.
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

        private void OnSliderMouseWheel(object sender, MouseWheelEventArgs e)
        {
            Slider source = e.Source as Slider;
            if (source != null)
            {
                if (e.Delta > 0)
                {
                    // Execute the Slider DecreaseSmall RoutedCommand.
                    // The slider.value propety is passed as the command parameter.
                    ((RoutedCommand)Slider.DecreaseSmall).Execute(
                        source.Value, source);

                }
                else
                {
                    // Execute the Slider IncreaseSmall RoutedCommand.
                    // The slider.value propety is passed as the command parameter.
                    ((RoutedCommand)Slider.IncreaseSmall).Execute(
                        source.Value, source);
                }
            }
        }

        // Moves the slider when the mouse extended buttons are pressed
        private void OnSliderMouseUp(object sender, MouseButtonEventArgs e)
        {
            Slider source = e.Source as Slider;

            if (source != null)
            {
                if (e.ChangedButton == MouseButton.XButton1)
                {
                    // Execute the Slider DecreaseSmall RoutedCommand.
                    // The slider.value propety is passed as the command parameter.
                    ((RoutedCommand)Slider.DecreaseSmall).Execute(
                        source.Value, source);
                }
                if (e.ChangedButton == MouseButton.XButton2)
                {
                    // Execute the Slider IncreaseSmall RoutedCommand.
                    // The slider.value propety is passed as the command parameter.
                    ((RoutedCommand)Slider.IncreaseSmall).Execute(
                        source.Value, source);
                }
            }
        }
    }

    // Converter to convert the Slider value property to an int32.
    [ValueConversion(typeof(double), typeof(int))]
    public class SliderValueConverter : IValueConverter
    {
        public object Convert(object value, 
            Type targetType, 
            object parameter, 
            CultureInfo culture)
        {
            double sliderValue = (double)value;

            return (int)sliderValue;
        }

        public object ConvertBack(object value,
            Type targetType,
            object parameter, 
            CultureInfo culture)
        {
            return null;
        }
    }
}
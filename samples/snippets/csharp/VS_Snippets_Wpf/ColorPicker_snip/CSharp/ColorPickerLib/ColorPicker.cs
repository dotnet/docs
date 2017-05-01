using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Data;
//<SnippetUsing1>
using System.Windows.Markup;
//</SnippetUsing1>
using System.ComponentModel;

namespace ColorPickerLib
{
    public class ColorPicker : Control
    {
 //<Snippet3>        
        //<SnippetcolorCache>
        private Color _colorCache;
        //</SnippetcolorCache>

        static ColorPicker()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ColorPicker), new FrameworkPropertyMetadata(typeof(ColorPicker)));
        }
 //</Snippet3>

//<Snippet9>
        public ColorPicker()
        {
            _colorCache = (Color)ColorProperty.GetMetadata(this).DefaultValue;
            SetupColorBindings();
        }
//</Snippet9>

//<Snippet7>
        private void SetupColorBindings()
        {
            MultiBinding binding = new MultiBinding();

            binding.Converter = new ByteColorMultiConverter();
            binding.Mode = BindingMode.TwoWay;

            Binding redBinding = new Binding("Red");
            redBinding.Source = this;
            redBinding.Mode = BindingMode.TwoWay;
            binding.Bindings.Add(redBinding);

            Binding greenBinding = new Binding("Green");
            greenBinding.Source = this;
            greenBinding.Mode = BindingMode.TwoWay;
            binding.Bindings.Add(greenBinding);

            Binding blueBinding = new Binding("Blue");
            blueBinding.Source = this;
            blueBinding.Mode = BindingMode.TwoWay;
            binding.Bindings.Add(blueBinding);

            this.SetBinding(ColorProperty, binding);
        }
//</Snippet7>

//<Snippet10>
        public static DependencyProperty ColorProperty = DependencyProperty.Register(
                "Color",
                typeof(Color),
                typeof(ColorPicker),
                new PropertyMetadata(Colors.Black));
//<Snippet10>

//<Snippet4>
        public Color Color
        {
            get
            {
                return (Color)GetValue(ColorProperty);
            }
            set
            {
                SetValue(ColorProperty, value);
            }
        }
//</Snippet4>

//<Snippet5>
        public static DependencyProperty RedProperty = DependencyProperty.Register(
            "Red",
            typeof(byte),
            typeof(ColorPicker));

        public static DependencyProperty GreenProperty = DependencyProperty.Register(
            "Green",
            typeof(byte),
            typeof(ColorPicker));

        public static DependencyProperty BlueProperty = DependencyProperty.Register(
            "Blue",
            typeof(byte),
            typeof(ColorPicker));
//</Snippet5>

//<SnippetRedGreenBlueCLR>
        public byte Red
        {
            get { return (byte)GetValue(RedProperty); }
            set { SetValue(RedProperty, value); }
        }

        public byte Green
        {
            get { return (byte)GetValue(GreenProperty); }
            set { SetValue(GreenProperty, value); }
        }

        public byte Blue
        {
            get { return (byte)GetValue(BlueProperty); }
            set { SetValue(BlueProperty, value); }
        }
//</SnippetRedGreenBlueCLR>

//<Snippet8>

        //<SnippetColorChangedEvent>
        public static readonly RoutedEvent ColorChangedEvent =
            EventManager.RegisterRoutedEvent("ColorChanged", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<Color>), typeof(ColorPicker));
        //</SnippetColorChangedEvent>

        //<SnippetColorChanged>
        public event RoutedPropertyChangedEventHandler<Color> ColorChanged
        {
            add { AddHandler(ColorChangedEvent, value); }
            remove { RemoveHandler(ColorChangedEvent, value); }
        }
        //</SnippetColorChanged>

        //<SnippetOnColorChanged>
        protected virtual void OnColorChanged(Color oldValue, Color newValue)
        {
            RoutedPropertyChangedEventArgs<Color> args = new RoutedPropertyChangedEventArgs<Color>(oldValue, newValue);
            args.RoutedEvent = ColorPicker.ColorChangedEvent;
            RaiseEvent(args);
        }
        //</SnippetOnColorChanged>

//</Snippet8>

//<Snippet11>

        //<SnippetOnColorInvalidated>
        private static void OnColorInvalidated(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ColorPicker picker = (ColorPicker)d;

            Color oldValue = (Color)e.OldValue;
            Color newValue = (Color)e.NewValue;

            picker.OnColorChanged(oldValue, newValue);
        }
        //</SnippetOnColorInvalidated>



//</Snippet11>
    }
//<Snippet6>
    public class ByteColorMultiConverter : IMultiValueConverter
    {

        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values.Length != 3)
            {
                throw new ArgumentException("need three values");
            }

            byte red = (byte)values[0];
            byte green = (byte)values[1];
            byte blue = (byte)values[2];

            return Color.FromRgb(red, green, blue);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            Color color = (Color)value;

            return new object[] { color.R, color.G, color.B };
        }
    }
//</Snippet6>

//<Snippet12>
    public class ByteDoubleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (double)(byte)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (byte)(double)value;
        }
    }
//</Snippet12>

//<Snippet16>
    [ValueConversion(typeof(Color), typeof(SolidColorBrush))]
    public class ColorBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Color color = (Color)value;
            return new SolidColorBrush(color);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
//</Snippet16>
}

//
// SupportingClasses.cs 
//
// 
using System;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Ink;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows.Data;
using System.Windows.Markup;

namespace Microsoft.Samples.CustomControls
{



    #region SpectrumSlider

    public class SpectrumSlider : Slider
    {


        static SpectrumSlider()
        {
            
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SpectrumSlider),
                new FrameworkPropertyMetadata(typeof(SpectrumSlider))); 
        }


        private LinearGradientBrush pickerBrush;



        private static readonly DependencyProperty SelectedColorProperty =
            DependencyProperty.Register
            ("SelectedColor", typeof(Color), typeof(SpectrumSlider),
            new PropertyMetadata(System.Windows.Media.Colors.Transparent));


        public Color SelectedColor
        {
            get
            {

                return (Color)GetValue(SelectedColorProperty);
            }
            set
            {
                SetValue(SelectedColorProperty, value);
            }

        }

        protected override void OnValueChanged(double oldValue, double newValue)
        {

            base.OnValueChanged(oldValue, newValue);
            Color? theColor = ColorUtilities.ConvertHsvToRgb(360 - newValue, 1, 1);
            
            SetValue(SelectedColorProperty, theColor);

        }


        public override void OnApplyTemplate()
        {

            base.OnApplyTemplate();
            m_spectrumDisplay = GetTemplateChild(SpectrumDisplayName) as Rectangle;
            
            
            if (!colorsInitialized)
            {

                updateColorSpectrum();
                OnValueChanged(0, 0);
            }

        }


        private void updateColorSpectrum()
        {


            if (m_spectrumDisplay != null)
            {
                colorsInitialized = true;
                createSpectrum();

            }
            else
            {
                colorsInitialized = false;

            }
        }



        private void createSpectrum()
        {

            pickerBrush = new LinearGradientBrush();
            pickerBrush.StartPoint = new Point(0.5, 0);
            pickerBrush.EndPoint = new Point(0.5, 1);
            pickerBrush.ColorInterpolationMode = ColorInterpolationMode.SRgbLinearInterpolation;


            List<Color> colorsList = ColorUtilities.GenerateHsvSpectrum();
            double stopIncrement = (double)1 / colorsList.Count;

            int i;
            for (i = 0; i < colorsList.Count; i++)
            {
                pickerBrush.GradientStops.Add(new GradientStop(colorsList[i], i * stopIncrement));
            }

            pickerBrush.GradientStops[i - 1].Offset = 1.0;      
            m_spectrumDisplay.Fill = pickerBrush;

        }


        private static string SpectrumDisplayName = "PART_SpectrumDisplay";
        private Rectangle m_spectrumDisplay;
        private bool colorsInitialized = false;

    }

    #endregion SpectrumSlider


    #region ColorUtilities

    static class ColorUtilities
    {

        // Converts an RGB color to an HSV color.
        public static HsvColor ConvertRgbToHsv(int r, int b, int g)
        {
            System.Drawing.Color otherColor = System.Drawing.Color.FromArgb(255, r, b, g);
            
            return 
                new HsvColor(
                    otherColor.GetHue(), 
                    otherColor.GetSaturation(), 
                    otherColor.GetBrightness());

            /*

            double delta, min;
            double h = 0, s, v;

            min = Math.Min(Math.Min(r, g), b);
            v = Math.Max(Math.Max(r, g), b);
            delta = v - min;

            if (v == 0.0) {
                s = 0;
                
            }
            else
                s = delta / v;

            if (s == 0)
                h = 0.0;

            else
            {
                if (r == v)
                    h = (g - b) / delta;
                else if (g == v)
                    h = 2 + (b - r) / delta;
                else if (b == v)
                    h = 4 + (r - g) / delta;

                h *= 60;
                if (h < 0.0)
                    h = h + 360;

            }

            HsvColor hsvColor = new HsvColor();
            hsvColor.H = h;
            hsvColor.S = s;
            hsvColor.V = v / 255;

            return hsvColor;
             */
        }

        // Converts an HSV color to an RGB color.
        public static Color ConvertHsvToRgb(double h, double s, double v)
        {

            double r = 0, g = 0, b = 0;

            if (s == 0)
            {
                r = v;
                g = v;
                b = v;
            }
            else
            {
                int i;
                double f, p, q, t;

                if (h == 360)
                    h = 0;
                else
                    h = h / 60;

                i = (int)Math.Truncate(h);
                f = h - i;

                p = v * (1.0 - s);
                q = v * (1.0 - (s * f));
                t = v * (1.0 - (s * (1.0 - f)));

                switch (i)
                {
                    case 0:
                        r = v;
                        g = t;
                        b = p;
                        break;

                    case 1:
                        r = q;
                        g = v;
                        b = p;
                        break;

                    case 2:
                        r = p;
                        g = v;
                        b = t;
                        break;

                    case 3:
                        r = p;
                        g = q;
                        b = v;
                        break;

                    case 4:
                        r = t;
                        g = p;
                        b = v;
                        break;

                    default:
                        r = v;
                        g = p;
                        b = q;
                        break;
                }

            }

            return Color.FromArgb(255, (byte)(r * 255), (byte)(g * 255), (byte)(b * 255));

        }

        // Generates a list of colors with hues ranging from 0 360
        // and a saturation and value of 1. 
        public static List<Color> GenerateHsvSpectrum()
        {

            List<Color> colorsList = new List<Color>(8);


            for (int i = 0; i < 59; i++)
            {

                colorsList.Add(
                    ColorUtilities.ConvertHsvToRgb(i * 6, 1, 1)

                );

            }
            colorsList.Add(ColorUtilities.ConvertHsvToRgb(0, 1, 1));


            return colorsList;

        }

    }

    #endregion ColorUtilities


    // Describes a color in terms of
    // Hue, Saturation, and Value (brightness)
    #region HsvColor
    struct HsvColor
    {

        public double H;
        public double S;
        public double V;

        public HsvColor(double h, double s, double v)
        {
            this.H = h;
            this.S = s;
            this.V = v;

        }
    }
    #endregion HsvColor

    #region ColorThumb
    public class ColorThumb : System.Windows.Controls.Primitives.Thumb
    {

        static ColorThumb()
        {
            
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ColorThumb),
                new FrameworkPropertyMetadata(typeof(ColorThumb))); 
        }


        public static readonly DependencyProperty ThumbColorProperty =
        DependencyProperty.Register
        ("ThumbColor", typeof(Color), typeof(ColorThumb),
            new FrameworkPropertyMetadata(Colors.Transparent));

        public static readonly DependencyProperty PointerOutlineThicknessProperty =
        DependencyProperty.Register
        ("PointerOutlineThickness", typeof(double), typeof(ColorThumb),
            new FrameworkPropertyMetadata(1.0));

        public static readonly DependencyProperty PointerOutlineBrushProperty =
        DependencyProperty.Register
        ("PointerOutlineBrush", typeof(Brush), typeof(ColorThumb),
            new FrameworkPropertyMetadata(null));



        public Color ThumbColor
        {
            get
            {
                return (Color)GetValue(ThumbColorProperty);
            }
            set
            {

                SetValue(ThumbColorProperty, value);
            }
        }

        public double PointerOutlineThickness
        {
            get
            {
                return (double)GetValue(PointerOutlineThicknessProperty);
            }
            set
            {
                SetValue(PointerOutlineThicknessProperty, value);
            }
        }

        public Brush PointerOutlineBrush
        {
            get
            {
                return (Brush)GetValue(PointerOutlineBrushProperty);
            }
            set
            {
                SetValue(PointerOutlineBrushProperty, value);
            }
        }


    }
    #endregion ColorThumb


}
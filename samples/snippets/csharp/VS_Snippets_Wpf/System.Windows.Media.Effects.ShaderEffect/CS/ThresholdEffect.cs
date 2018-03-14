// <snippet1>
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Reflection;

namespace ShaderEffectDemo
{

    public class ThresholdEffect : ShaderEffect
    {
        private static PixelShader _pixelShader =
            new PixelShader() { UriSource = MakePackUri("ThresholdEffect.fx.ps") };

        public ThresholdEffect()
        {
            PixelShader = _pixelShader;

            UpdateShaderValue(InputProperty);
            UpdateShaderValue(ThresholdProperty);
            UpdateShaderValue(BlankColorProperty);
        }

        // MakePackUri is a utility method for computing a pack uri
        // for the given resource. 
        public static Uri MakePackUri(string relativeFile)
        {
            Assembly a = typeof(ThresholdEffect).Assembly;

            // Extract the short name.
            string assemblyShortName = a.ToString().Split(',')[0];

            string uriString = "pack://application:,,,/" +
                assemblyShortName +
                ";component/" +
                relativeFile;

            return new Uri(uriString);
        }

        ///////////////////////////////////////////////////////////////////////
        #region Input dependency property

        public Brush Input
        {
            get { return (Brush)GetValue(InputProperty); }
            set { SetValue(InputProperty, value); }
        }

        public static readonly DependencyProperty InputProperty =
            ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(ThresholdEffect), 0);

        #endregion

        ///////////////////////////////////////////////////////////////////////
        #region Threshold dependency property

        public double Threshold
        {
            get { return (double)GetValue(ThresholdProperty); }
            set { SetValue(ThresholdProperty, value); }
        }

        public static readonly DependencyProperty ThresholdProperty =
            DependencyProperty.Register("Threshold", typeof(double), typeof(ThresholdEffect),
                    new UIPropertyMetadata(0.5, PixelShaderConstantCallback(0)));

        #endregion

        ///////////////////////////////////////////////////////////////////////
        #region BlankColor dependency property

        public Color BlankColor
        {
            get { return (Color)GetValue(BlankColorProperty); }
            set { SetValue(BlankColorProperty, value); }
        }

        public static readonly DependencyProperty BlankColorProperty =
            DependencyProperty.Register("BlankColor", typeof(Color), typeof(ThresholdEffect),
                    new UIPropertyMetadata(Colors.Transparent, PixelShaderConstantCallback(1)));

        #endregion
    }
}
// </snippet1>
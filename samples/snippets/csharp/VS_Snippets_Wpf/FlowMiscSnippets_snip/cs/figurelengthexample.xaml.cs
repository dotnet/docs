// <SnippetFigureLengthCodeBehindExampleWholePage>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SDKSample
{
    public partial class FigureLengthExample : Page
	{

        void OnMouseDownDecreaseWidth(object sender, MouseButtonEventArgs args)
        {
            FigureLength myFigureLength = myFigure.Width;
            double widthValue = myFigureLength.Value;
            if (widthValue > 0)
            {
                myFigure.Width = new FigureLength((widthValue - 10), FigureUnitType.Pixel);
            }
        }
    }
}
// </SnippetFigureLengthCodeBehindExampleWholePage>
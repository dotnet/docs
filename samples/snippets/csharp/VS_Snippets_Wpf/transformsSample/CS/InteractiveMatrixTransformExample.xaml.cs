using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Microsoft.Samples.Graphics.Transforms
{
 

    public partial class InteractiveMatrixTransformExample : Page
    {
    
    	public InteractiveMatrixTransformExample()
    	{
    		
    	}

		private void applyButtonClicked(object sender, EventArgs args)
		{
			updateMatrixTransform();

		}


		private void updateMatrixTransform()
		{

  

			Matrix myMatrix = new Matrix();

			myMatrix.M11 = Double.Parse(M11TextBox.Text);
			myMatrix.M12 = Double.Parse(M12TextBox.Text);
			myMatrix.M21 = Double.Parse(M21TextBox.Text);
			myMatrix.M22 = Double.Parse(M22TextBox.Text);
			myMatrix.OffsetX = Double.Parse(OffsetXTextBox.Text);
			myMatrix.OffsetY = Double.Parse(OffsetYTextBox.Text);

			myMatrixTransform.Matrix = myMatrix;

		}



    }
}
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace QuaternionView
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {
        //Set globals
        //<SnippetQuaternionView3DN1>
        Quaternion startQuaternion = new Quaternion(0,0,1,0);
        //</SnippetQuaternionView3DN1>
        Quaternion endQuaternion = new Quaternion();
        TranslateTransform3D myTranslation = new TranslateTransform3D();
        RotateTransform3D baseRotateTransform3D = new RotateTransform3D();
        QuaternionRotation3D startRotation = new QuaternionRotation3D();
        QuaternionRotation3D endRotation = new QuaternionRotation3D();
        Transform3DGroup myprocTransformGroup = new Transform3DGroup();
        Rotation3DAnimation mydefaultAnimation = new Rotation3DAnimation();       
        public Window1()
        {
            InitializeComponent();
        }

        private void UpdateWXYZSettings(object sender, EventArgs e)
        {
            //Clear prior values
            myprocTransformGroup.Children.Clear();
            XAxisValue.Clear();
            YAxisValue.Clear();
            ZAxisValue.Clear();
            AngleValue.Clear();

            //<SnippetQuaternionView3DN2>
            //Read new settings
            Double setW = System.Convert.ToDouble(WValue.Text);
            Double setX = System.Convert.ToDouble(XValue.Text);
            Double setY = System.Convert.ToDouble(YValue.Text);
            Double setZ = System.Convert.ToDouble(ZValue.Text);

            endQuaternion = new Quaternion(setX, setY, setZ, setW);
            endRotation.Quaternion = endQuaternion;

            //Update axis and angle textboxes
            XAxisValue.Text = endQuaternion.Axis.X.ToString();
            YAxisValue.Text = endQuaternion.Axis.Y.ToString();
            ZAxisValue.Text = endQuaternion.Axis.Z.ToString();
            AngleValue.Text = endQuaternion.Angle.ToString();

            startAnimation();
            //</SnippetQuaternionView3DN2>
        }

        private void UpdateParseXYZWSettings(object sender, EventArgs e)
        {
            //Clear prior values
            myprocTransformGroup.Children.Clear();
            XAxisValue.Clear();
            YAxisValue.Clear();
            ZAxisValue.Clear();
            AngleValue.Clear();

            //<SnippetQuaternionView3DN3>
            try
            {
                endQuaternion = Quaternion.Parse(ParseValue.Text);
            }
            catch
            {
                ParseValue.Text = "Must input (X, Y, Z, W)";
            }

            endRotation.Quaternion = endQuaternion;
            //</SnippetQuaternionView3DN3>

            //Update axis and angle textboxes
            XAxisValue.Text = endQuaternion.Axis.X.ToString();
            YAxisValue.Text = endQuaternion.Axis.Y.ToString();
            ZAxisValue.Text = endQuaternion.Axis.Z.ToString();
            AngleValue.Text = endQuaternion.Angle.ToString();

            startAnimation();
        }

        private void UpdateAxisAngleSettings(object sender, EventArgs e)
        {
            //Clear prior values
            myprocTransformGroup.Children.Clear();
            WValue.Clear();
            XValue.Clear();
            YValue.Clear();
            ZValue.Clear();

            //<SnippetQuaternionView3DN4>
            //Read new settings
            Double angle = System.Convert.ToDouble(AngleValue.Text);
            try
            {
                Double xaxis = System.Convert.ToDouble(XAxisValue.Text);
                Double yaxis = System.Convert.ToDouble(YAxisValue.Text);
                Double zaxis = System.Convert.ToDouble(ZAxisValue.Text);

                endQuaternion = new Quaternion(new Vector3D(xaxis, yaxis, zaxis), angle);
            }
            catch
            {
                XAxisValue.Text = "Axis must be nonzero Vector3D";
                YAxisValue.Text = "Axis must be nonzero Vector3D";
                ZAxisValue.Text = "Axis must be nonzero Vector3D";
            }

            endRotation.Quaternion = endQuaternion;
            //</SnippetQuaternionView3DN4>

            //Update quaternion display
            WValue.Text = endQuaternion.W.ToString();
            XValue.Text = endQuaternion.X.ToString();
            YValue.Text = endQuaternion.Y.ToString();
            ZValue.Text = endQuaternion.Z.ToString();

            //build in some if clauses to determine the animation method to call
            startAnimation();
        }

        public void startAnimation()
        {
            mydefaultAnimation.From = startRotation;
            mydefaultAnimation.To = endRotation;
            mydefaultAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(3000));
            mydefaultAnimation.FillBehavior = FillBehavior.HoldEnd;

            baseRotateTransform3D.BeginAnimation(RotateTransform3D.RotationProperty, mydefaultAnimation);
            myprocTransformGroup.Children.Add(baseRotateTransform3D);
            topModelVisual3D.Transform = myprocTransformGroup;

            //Update text boxes
            //TransformMatrix.Text = myprocTransformGroup.Value.ToString();
            //TransformMatrix.Text = baseRotateTransform3D.Value.ToString();

            AxisAngleString.Text = endQuaternion.ToString();
            //resulting string is (x,y,z,w)

        }

    }
}
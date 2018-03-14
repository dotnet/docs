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


namespace MatrixTransform3DView
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {
        //Set globals
        Matrix3D endMatrix3D = new Matrix3D();
        Matrix3D rotationMatrix3D = new Matrix3D();
        Matrix3D qrotationMatrix3D = new Matrix3D();
        MatrixTransform3D myMatrixTransform3D = new MatrixTransform3D();
        RotateTransform3D myRotateTransform3D = new RotateTransform3D();
        AxisAngleRotation3D myAxisAngleRotation3D = new AxisAngleRotation3D();
        Quaternion endQuaternion = new Quaternion();
        QuaternionRotation3D myQuaternionRotation3D = new QuaternionRotation3D();
        TranslateTransform3D myTranslateTransform3D = new TranslateTransform3D();
        Transform3DGroup myprocTransformGroup = new Transform3DGroup();
            

        public Window1()
        {
            InitializeComponent();
        }

        private void UpdateMatrix(object sender, EventArgs e)
        {
            //<SnippetMatrixTransform3DView3DN1>
            try
            {
                Double setM11 = System.Convert.ToDouble(M11Text.Text);
                Double setM21 = System.Convert.ToDouble(M21Text.Text);
                Double setM31 = System.Convert.ToDouble(M31Text.Text);
                Double setOffsetX = System.Convert.ToDouble(OffsetXText.Text);

                Double setM12 = System.Convert.ToDouble(M12Text.Text);
                Double setM22 = System.Convert.ToDouble(M22Text.Text);
                Double setM32 = System.Convert.ToDouble(M32Text.Text);
                Double setOffsetY = System.Convert.ToDouble(OffsetYText.Text);

                Double setM13 = System.Convert.ToDouble(M13Text.Text);
                Double setM23 = System.Convert.ToDouble(M23Text.Text);
                Double setM33 = System.Convert.ToDouble(M33Text.Text);
                Double setOffsetZ = System.Convert.ToDouble(OffsetZText.Text);

                Double setM14 = System.Convert.ToDouble(M14Text.Text);
                Double setM24 = System.Convert.ToDouble(M24Text.Text);
                Double setM34 = System.Convert.ToDouble(M34Text.Text);
                Double setM44 = System.Convert.ToDouble(M44Text.Text);

            endMatrix3D = new Matrix3D(setM11, setM12, setM13, setM14, setM21, setM22, setM23, setM24, setM31, setM32, setM33, setM34, setOffsetX, setOffsetY, setOffsetZ, setM44);

            myMatrixTransform3D.Matrix = endMatrix3D;
        }
        catch
        {
            MessageBox.Show("Set Matrix3D values or rotation values before transforming");
        }

            //</SnippetMatrixTransform3DView3DN1>
            //might want to clear the transformgroup before adding more children
            myprocTransformGroup.Children.Clear();
            myprocTransformGroup.Children.Add(myMatrixTransform3D);
            topModelVisual3D.Transform = myprocTransformGroup;

        }

        private void UpdateRotation(object sender, EventArgs e)
        {
            //Clear prior values
            //find a cleaner way to do this--loop?
            QuaternionWText.Clear();
            QuaternionXText.Clear();
            QuaternionYText.Clear();
            QuaternionZText.Clear();

            M11Text.Clear();
            M21Text.Clear();
            M31Text.Clear();
            OffsetXText.Clear();
            M12Text.Clear();
            M22Text.Clear();
            M32Text.Clear();
            OffsetYText.Clear();
            M13Text.Clear();
            M23Text.Clear();
            M33Text.Clear();
            OffsetZText.Clear();
            M14Text.Clear();
            M24Text.Clear();
            M34Text.Clear();
            M44Text.Clear();

            //<SnippetMatrixTransform3DView3DN2>
            
            Double axisX = System.Convert.ToDouble(RotationAxisXText.Text);
            Double axisY = System.Convert.ToDouble(RotationAxisYText.Text);
            Double axisZ = System.Convert.ToDouble(RotationAxisZText.Text);
            Double angle = System.Convert.ToDouble(RotationAngleText.Text);

            Vector3D axis = new Vector3D(axisX, axisY, axisZ);

            try
            {
                myAxisAngleRotation3D = new AxisAngleRotation3D(axis, angle);
            }
            catch
            {
                MessageBox.Show("Set non-null values for the axis Vector3D.");
            }

            myRotateTransform3D.Rotation = myAxisAngleRotation3D;

            //</SnippetMatrixTransform3DView3DN2>


            //update matrix display
            //<SnippetMatrixTransform3DView3DN13>
            rotationMatrix3D = myRotateTransform3D.Value;
            M11Text.Text = rotationMatrix3D.M11.ToString();
            //</SnippetMatrixTransform3DView3DN13>
            M21Text.Text = rotationMatrix3D.M21.ToString();
            M31Text.Text = rotationMatrix3D.M31.ToString();
            OffsetXText.Text = rotationMatrix3D.OffsetX.ToString();
            M12Text.Text = rotationMatrix3D.M12.ToString();
            M22Text.Text = rotationMatrix3D.M22.ToString();
            M32Text.Text = rotationMatrix3D.M32.ToString();
            OffsetYText.Text = rotationMatrix3D.OffsetY.ToString();
            M13Text.Text = rotationMatrix3D.M13.ToString();
            M23Text.Text = rotationMatrix3D.M23.ToString();
            M33Text.Text = rotationMatrix3D.M33.ToString();
            OffsetZText.Text = rotationMatrix3D.OffsetZ.ToString();
            M14Text.Text = rotationMatrix3D.M14.ToString();
            M24Text.Text = rotationMatrix3D.M24.ToString();
            M34Text.Text = rotationMatrix3D.M34.ToString();
            M44Text.Text = rotationMatrix3D.M44.ToString();

            myprocTransformGroup.Children.Clear();
            myprocTransformGroup.Children.Add(myRotateTransform3D);
            topModelVisual3D.Transform = myprocTransformGroup;

            //<SnippetMatrixTransform3DView3DN3>
            //convert to quaternion and update display
            try
            {
                Quaternion tempQuaternion = new Quaternion(axis, angle);
                QuaternionWText.Text = tempQuaternion.W.ToString();
                QuaternionXText.Text = tempQuaternion.X.ToString();
                QuaternionYText.Text = tempQuaternion.Y.ToString();
                QuaternionZText.Text = tempQuaternion.Z.ToString();
            }
            catch
            {
                MessageBox.Show("Set non-null values for the axis Vector3D.");
            }
            //</SnippetMatrixTransform3DView3DN3>
        }

        private void UpdateQuaternionRotation3D(object sender, EventArgs e)
        {
            //Clear prior values
            //find a cleaner way to do this--loop?
            RotationAxisXText.Clear();
            RotationAxisYText.Clear();
            RotationAxisZText.Clear();
            RotationAngleText.Clear();

            M11Text.Clear();
            M21Text.Clear();
            M31Text.Clear();
            OffsetXText.Clear();
            M12Text.Clear();
            M22Text.Clear();
            M32Text.Clear();
            OffsetYText.Clear();
            M13Text.Clear();
            M23Text.Clear();
            M33Text.Clear();
            OffsetZText.Clear();
            M14Text.Clear();
            M24Text.Clear();
            M34Text.Clear();
            M44Text.Clear();

            //<SnippetMatrixTransform3DView3DN4>
            //Read new settings
            try
            {
                Double WValue = System.Convert.ToDouble(QuaternionWText.Text);
                Double XValue = System.Convert.ToDouble(QuaternionXText.Text);
                Double YValue = System.Convert.ToDouble(QuaternionYText.Text);
                Double ZValue = System.Convert.ToDouble(QuaternionZText.Text);

                endQuaternion = new Quaternion(XValue, YValue, ZValue, WValue);
            }
            catch
            {
                MessageBox.Show("Set non-null values for the quaternion.");
            }

            myQuaternionRotation3D = new QuaternionRotation3D(endQuaternion);
            myRotateTransform3D.Rotation = myQuaternionRotation3D;

            //update matrix display
            qrotationMatrix3D = myRotateTransform3D.Value;
            //</SnippetMatrixTransform3DView3DN4>

            M11Text.Text = qrotationMatrix3D.M11.ToString();
            M21Text.Text = qrotationMatrix3D.M21.ToString();
            M31Text.Text = qrotationMatrix3D.M31.ToString();
            OffsetXText.Text = qrotationMatrix3D.OffsetX.ToString();
            M12Text.Text = qrotationMatrix3D.M12.ToString();
            M22Text.Text = qrotationMatrix3D.M22.ToString();
            M32Text.Text = qrotationMatrix3D.M32.ToString();
            OffsetYText.Text = qrotationMatrix3D.OffsetY.ToString();
            M13Text.Text = qrotationMatrix3D.M13.ToString();
            M23Text.Text = qrotationMatrix3D.M23.ToString();
            M33Text.Text = qrotationMatrix3D.M33.ToString();
            OffsetZText.Text = qrotationMatrix3D.OffsetZ.ToString();
            M14Text.Text = qrotationMatrix3D.M14.ToString();
            M24Text.Text = qrotationMatrix3D.M24.ToString();
            M34Text.Text = qrotationMatrix3D.M34.ToString();
            M44Text.Text = qrotationMatrix3D.M44.ToString();

            //apply transform
            myprocTransformGroup.Children.Clear();
            myprocTransformGroup.Children.Add(myRotateTransform3D);
            topModelVisual3D.Transform = myprocTransformGroup;

            //convert to axis/angle and display results
            RotationAxisXText.Text = endQuaternion.Axis.X.ToString();
            RotationAxisYText.Text = endQuaternion.Axis.X.ToString();
            RotationAxisZText.Text = endQuaternion.Axis.X.ToString();
            RotationAngleText.Text = endQuaternion.Angle.ToString();
        }

        private void UpdateTranslation(object sender, EventArgs e)
        {

            Double OffsetXValue = System.Convert.ToDouble(TranslateOffsetXText.Text);
            Double OffsetYValue = System.Convert.ToDouble(TranslateOffsetYText.Text);
            Double OffsetZValue = System.Convert.ToDouble(TranslateOffsetZText.Text);
            Vector3D convertVector3D = new Vector3D(OffsetXValue, OffsetYValue, OffsetZValue);
            myTranslateTransform3D = new TranslateTransform3D(OffsetXValue, OffsetYValue, OffsetZValue);
            
            if (addTranslationCheck.IsChecked == false)
            {
                myprocTransformGroup.Children.Clear();
                myprocTransformGroup.Children.Add(myTranslateTransform3D);
                topModelVisual3D.Transform = myprocTransformGroup;
            }
            if (addTranslationCheck.IsChecked == true)
            {
                myprocTransformGroup.Children.Add(myTranslateTransform3D);
                topModelVisual3D.Transform = myprocTransformGroup;
            }

            Matrix3D tempMatrix3D = myprocTransformGroup.Value;
            M11Text.Text = tempMatrix3D.M11.ToString();
            M21Text.Text = tempMatrix3D.M21.ToString();
            M31Text.Text = tempMatrix3D.M31.ToString();
            OffsetXText.Text = tempMatrix3D.OffsetX.ToString();
            M12Text.Text = tempMatrix3D.M12.ToString();
            M22Text.Text = tempMatrix3D.M22.ToString();
            M32Text.Text = tempMatrix3D.M32.ToString();
            OffsetYText.Text = tempMatrix3D.OffsetY.ToString();
            M13Text.Text = tempMatrix3D.M13.ToString();
            M23Text.Text = tempMatrix3D.M23.ToString();
            M33Text.Text = tempMatrix3D.M33.ToString();
            OffsetZText.Text = tempMatrix3D.OffsetZ.ToString();
            M14Text.Text = tempMatrix3D.M14.ToString();
            M24Text.Text = tempMatrix3D.M24.ToString();
            M34Text.Text = tempMatrix3D.M34.ToString();
            M44Text.Text = tempMatrix3D.M44.ToString();
        }

        //<SnippetMatrixTransform3DView3DN11>
        private void SetMatrixCamera(object sender, EventArgs e)
        {
            //Define matrices for ViewMatrix and ProjectionMatrix properties.
            Matrix3D vmatrix = new Matrix3D(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);
            Matrix3D pmatrix = new Matrix3D(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);

            MatrixCamera mCamera = new MatrixCamera(vmatrix, pmatrix);
            myViewport.Camera = mCamera;
        }
        //</SnippetMatrixTransform3DView3DN11>
    }
}
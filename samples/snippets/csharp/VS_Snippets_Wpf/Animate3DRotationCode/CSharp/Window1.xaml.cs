//This is a list of commonly used namespaces for a window.
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Media.Animation;

namespace Blank3DSample
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

        //declare scene objects
        Model3DGroup modelGroup = new Model3DGroup();
        PerspectiveCamera myPCamera = new PerspectiveCamera();
        DirectionalLight myDirLight = new DirectionalLight();
        DiffuseMaterial bMaterial = new DiffuseMaterial();
        GeometryModel3D cubeModel = new GeometryModel3D();
        GeometryModel3D coneModel = new GeometryModel3D();
        GeometryModel3D teapotModel = new GeometryModel3D();
        Transform3DCollection myTransforms = new Transform3DCollection();
        ModelVisual3D myModelVisual3D = new ModelVisual3D();
        Viewport3D myViewport = new Viewport3D();

        private void WindowLoaded(object sender, EventArgs e)
        {
            RenderSomeModels();
        }

        private void RenderSomeModels()
        {
            myViewport.Name = "myViewport";
            //Set camera viewpoint and properties.
            myPCamera.FarPlaneDistance = 20;
            myPCamera.NearPlaneDistance = 1;
            myPCamera.FieldOfView = 45;
            myPCamera.Position = new Point3D(-5, 2, 3);
            myPCamera.LookDirection = new Vector3D(5, -2, -3);
            myPCamera.UpDirection = new Vector3D(0, 1, 0);

            //Add light sources to the scene.
            myDirLight.Color = Colors.White;
            myDirLight.Direction = new Vector3D(-3, -4, -5);

            teapotModel.Geometry = (MeshGeometry3D)Application.Current.Resources["myTeapot"];

            //Define DiffuseMaterial and apply to the mesh geometries.
            DiffuseMaterial teapotMaterial = new DiffuseMaterial(new SolidColorBrush(Colors.Blue));

            //<SnippetAnimate3DRotationCode3DN1>
            //<SnippetAnimate3DRotationCode3DN2>
            //Define a transformation
            RotateTransform3D myRotateTransform = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 2, 0), 1));
            //</SnippetAnimate3DRotationCode3DN2>
            //<SnippetAnimate3DRotationCode3DN3>
            //Define an animation for the transformation
            DoubleAnimation myAnimation = new DoubleAnimation();
            myAnimation.From = 1;
            myAnimation.To = 361;
            myAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(5000));
            myAnimation.RepeatBehavior = RepeatBehavior.Forever;
            //</SnippetAnimate3DRotationCode3DN3>
            //Add animation to the transformation
            myRotateTransform.Rotation.BeginAnimation(AxisAngleRotation3D.AngleProperty, myAnimation);

            //<SnippetAnimate3DRotationCode3DN4>
            //Add transformation to the model
            teapotModel.Transform = myRotateTransform;
            //</SnippetAnimate3DRotationCode3DN4>
            //</SnippetAnimate3DRotationCode3DN1>

            teapotModel.Material = teapotMaterial;

            //Add the model to the model group collection
            modelGroup.Children.Add(teapotModel);
            modelGroup.Children.Add(myDirLight);
            myViewport.Camera = myPCamera;

            myModelVisual3D.Content = modelGroup;
            myViewport.Children.Add(myModelVisual3D);

            //add the Viewport3D to the window
            mainWindow.Content = myViewport;



        }


    }
}
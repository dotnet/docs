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
        //<SnippetBasic3D3DN11>
        DirectionalLight myDirLight = new DirectionalLight();
        //</SnippetBasic3D3DN11>
        GeometryModel3D teapotModel = new GeometryModel3D();
        Transform3DCollection myTransforms = new Transform3DCollection();
        Viewport3D myViewport = new Viewport3D();

        private void WindowLoaded(object sender, EventArgs e)
        {

            //Set camera viewpoint and properties.
            myPCamera.FarPlaneDistance = 20;
            myPCamera.NearPlaneDistance = 1;
            myPCamera.FieldOfView = 45;
            myPCamera.Position = new Point3D(-5, 2, 3);
            myPCamera.LookDirection = new Vector3D(5, -2, -3);
            myPCamera.UpDirection = new Vector3D(0, 1, 0);

            //Add light sources to the scene.
            //<SnippetBasic3D3DN12>
            myDirLight.Color = Colors.White;
            myDirLight.Direction = new Vector3D(-3, -4, -5);
            //</SnippetBasic3D3DN12>

            //<SnippetBasic3D3DN1>
            teapotModel.Geometry = (MeshGeometry3D)Application.Current.Resources["myTeapot"];
            //</SnippetBasic3D3DN1>

            //Define material and apply to the mesh geometries.
            DiffuseMaterial teapotMaterial = new DiffuseMaterial(new SolidColorBrush(Colors.Blue));

            teapotModel.Material = teapotMaterial;

            //Add 3D model and lights to the collection; add the collection to the visual.

            modelGroup.Children.Add(teapotModel);
            //<SnippetBasic3D3DN13>
            modelGroup.Children.Add(myDirLight);
            //</SnippetBasic3D3DN13>

            ModelVisual3D modelsVisual = new ModelVisual3D();
            modelsVisual.Content = modelGroup;

            //Add the visual and camera to the Viewport3D.
            myViewport.Camera = myPCamera;
            myViewport.Children.Add(modelsVisual);

            mainWindow.Content = myViewport;
        }
    }
}
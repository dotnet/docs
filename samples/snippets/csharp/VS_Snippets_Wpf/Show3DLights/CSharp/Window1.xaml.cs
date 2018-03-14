using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Media.Animation;

namespace SDKSample
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {
        static string _mesh = "";
        private enum KeyMode { Camera, PointLight };
        private KeyMode currKeyMode = KeyMode.Camera;
        MyLights myLights = new MyLights();
        Model3D objModel = null;
		Model3DGroup modelGroup = new Model3DGroup();
		ModelVisual3D modelsVisual = new ModelVisual3D();

		public Window1()
        {
            InitializeComponent();
        }

        private void OnWindowLoaded(object sender, EventArgs e)
        {
            CBObjects.SelectedIndex = 0;
            myViewport3D.Focus();
        }

        private void OnListBoxChanged(object sender, EventArgs e)
        {
            double[] fieldOfView = new double[7] {50.0, 50.0, 2.0, 75.0, 75.0, 75.0, 20.0 };

            if (myViewport3D == null) return;

            ComboBoxItem cbi = (ComboBoxItem)((ComboBox)sender).SelectedItem;
            _mesh = cbi.Content.ToString();
            LoadMesh(fieldOfView[((ComboBox)sender).SelectedIndex]);
            myViewport3D.Focus();
        }

        // Add or remove an ambient light from the 3D viewport.
        private void OnAmbientLightChange(object sender, EventArgs e)
        {
            if (checkBoxAmbientLight.IsChecked == true)
            {
				myLights.ShowAmbientLight(true, modelGroup);
            }
            else
            {
				myLights.ShowAmbientLight(false, modelGroup);
            }

            myViewport3D.Focus();
        }

        // Add or remove a directional light from the 3D viewport.
        private void OnDirectionalLightOneChange(object sender, EventArgs e)
        {
            if (checkBoxDirLightOne.IsChecked == true)
            {
				myLights.ShowDirLight(0, true, modelGroup);
            }
            else
            {
				myLights.ShowDirLight(0, false, modelGroup);
            }

            myViewport3D.Focus();
        }

        // Add or remove a directional light from the 3D viewport.
        private void OnDirectionalLightTwoChange(object sender, EventArgs e)
        {
            if (checkBoxDirLightTwo.IsChecked == true)
            {
				myLights.ShowDirLight(1, true, modelGroup);
            }
            else
            {
				myLights.ShowDirLight(1, false, modelGroup);
            }

            myViewport3D.Focus();
        }

        // Add or remove a point light from the 3D viewport.
        private void OnPointLight(object sender, EventArgs e)
        {
            if (checkBoxPointLight.IsChecked == true)
            {
                currKeyMode = KeyMode.PointLight;
                rbPosition2.IsChecked = true;
				myLights.ShowPointLight(1, true, modelGroup);
                xyzPointLight.Foreground = System.Windows.Media.Brushes.Black;
                xyzPointLight.Content = "x: " + myLights.PointLightPosition.X + "  y: " + myLights.PointLightPosition.Y + "  z: " + myLights.PointLightPosition.Z;
            }
            else
            {
                currKeyMode = KeyMode.Camera;
                rbPosition1.IsChecked = true;
				myLights.ShowPointLight(1, false, modelGroup);
                xyzPointLight.Foreground = System.Windows.Media.Brushes.LightGray;
            }

            myViewport3D.Focus();
        }

        //<SnippetShow3DLights3DN8>
        private void OnAttenuationChecked(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;

            if (rb.Name == "rbAttenuation1")
            {
                myLights.PointLightConstantAttenuation = 3.0;
                myLights.PointLightLinearAttenuation = 0.0;
                myLights.PointLightQuadraticAttenuation = 0.0;
            }

            if (rb.Name == "rbAttenuation2")
            {
                myLights.PointLightConstantAttenuation = 0.0;
                myLights.PointLightLinearAttenuation = 0.5;
                myLights.PointLightQuadraticAttenuation = 0.0;
            }

            if (rb.Name == "rbAttenuation3")
            {
                myLights.PointLightConstantAttenuation = 0.0;
                myLights.PointLightLinearAttenuation = 0.0;
                myLights.PointLightQuadraticAttenuation = 0.5;
            }

            if (myViewport3D != null)
            {
                myViewport3D.Focus();
            }
        }
        //</SnippetShow3DLights3DN8>
        private void OnPositionChecked(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;

            if (rb.Name == "rbPosition1")
            {
                currKeyMode = KeyMode.Camera;
            }

            if (rb.Name == "rbPosition2")
            {
                currKeyMode = KeyMode.PointLight;
            }

            if (myViewport3D != null)
            {
                myViewport3D.Focus();
            }
        }

        private void OnRange(object sender, RoutedEventArgs e)
        {
            double pointLightRange = myLights.PointLightRange;

            try
            {
                pointLightRange = System.Convert.ToDouble(textboxRange.Text);
            }
            catch
            {
                return;
            }

            myLights.PointLightRange = pointLightRange;
        }

        private void LoadMesh(double fieldOfView)
        {
            if ((myViewport3D != null) && (modelGroup.Children.Count > 0))
			{
				myViewport3D.Children.Remove(modelsVisual);
				modelGroup.Children.Clear();
			}
            
            ((PerspectiveCamera)myViewport3D.Camera).FieldOfView = fieldOfView;
            
            // Define the material for the model.
            SolidColorBrush brush = new SolidColorBrush(Colors.Cyan);
            DiffuseMaterial colorMaterial = new DiffuseMaterial(brush);

            // Load the mesh for the model.
            MeshGeometry3D objMesh = (MeshGeometry3D)Application.Current.Resources[_mesh];
            objModel = new GeometryModel3D(objMesh, colorMaterial);

            // Define the projection camera and add to the model.
			SetProjectionCamera(myViewport3D, modelGroup);

			modelGroup.Children.Add(objModel);

			// Add ambient light to the model group.
			if (checkBoxAmbientLight.IsChecked == true)
			{
				myLights.ShowAmbientLight(true, modelGroup);
			}

			// Add directional lights to the model group.
			if (checkBoxDirLightOne.IsChecked == true)
			{
				myLights.ShowDirLight(0, true, modelGroup);
			}
			if (checkBoxDirLightTwo.IsChecked == true)
			{
				myLights.ShowDirLight(1, true, modelGroup);
			}

			// Add the model group data to the viewport.
			modelsVisual.Content = modelGroup;
			myViewport3D.Children.Add(modelsVisual);

			checkBoxPointLight.IsChecked = false;
            xyzPointLight.Foreground = System.Windows.Media.Brushes.LightGray;
            currKeyMode = KeyMode.Camera;
            rbPosition1.IsChecked = true;
        }

		public void SetProjectionCamera(Viewport3D myViewport3D, Model3DGroup modelGroup)
        {
            const double CameraDistance = 80; // distance from camera to origin
            const double CameraLatitude = Math.PI / 2; // angle from +ve y axis to camera (i.e. latitude)
            const double CameraLongitude = Math.PI; // angle from -ve z axis to camera (i.e. longitude)
            double x = CameraDistance * -Math.Sin(CameraLongitude) * Math.Sin(CameraLatitude);
            double y = CameraDistance * Math.Cos(CameraLatitude);
            double z = CameraDistance * -Math.Cos(CameraLongitude) * Math.Sin(CameraLatitude);

            ProjectionCamera projCamera = myViewport3D.Camera.Clone() as ProjectionCamera;
            projCamera.Position = new Point3D(x, y, z);
            myViewport3D.Camera = projCamera;

			TranslateTransform3D pan = new TranslateTransform3D(new Vector3D(0, 0, 0));
			modelGroup.Transform = pan;
        }

    }
}
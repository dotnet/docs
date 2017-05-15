using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace SDKSample
{
    public class MyLights
    {
        //<SnippetShow3DLights3DN1>
		// Ambient light value.
        AmbientLight _ambLight = new AmbientLight(System.Windows.Media.Brushes.DarkBlue.Color);
        //</SnippetShow3DLights3DN1>

        //<SnippetShow3DLights3DN2>
        // Directional light values.
        private const int nbrDirLights = 2;
        private DirectionalLight[] _dirLight = new DirectionalLight[nbrDirLights];
        private Vector3D[] _dirVector = new Vector3D[nbrDirLights] { new Vector3D(0.91, -0.5, -0.26), new Vector3D(-0.91, 0.5, 0.36) };
        private System.Windows.Media.Color[] _dirLightColor = new System.Windows.Media.Color[nbrDirLights] { System.Windows.Media.Brushes.White.Color, System.Windows.Media.Brushes.Yellow.Color };
        //</SnippetShow3DLights3DN2>

        //<SnippetShow3DLights3DN3>
        // Point light values.
        PointLight _ptLight = new PointLight();
        //</SnippetShow3DLights3DN3>
        //<SnippetShow3DLights3DN4>
        // ...
        //</SnippetShow3DLights3DN4>

        //<SnippetShow3DLights3DN5>
        public MyLights()
        {
            for (int i = 0; i < nbrDirLights; i++)
            {
                _dirLight[i] = new DirectionalLight();
                _dirLight[i].Color = _dirLightColor[i];
                _dirLight[i].Direction = _dirVector[i];
            }

            _ptLight.Position = new Point3D(-3, -7, 10);
            _ptLight.Color = System.Windows.Media.Brushes.White.Color;
            _ptLight.Range = 15.0;
            _ptLight.ConstantAttenuation = 3.0;
        }
        //</SnippetShow3DLights3DN5>

		public void ShowAmbientLight(bool show, Model3DGroup modelGroup)
        {
			foreach (Model3D m in modelGroup.Children)
			{
				string s = m.ToString();
			}
            if (show == true)
            {
                modelGroup.Children.Add(_ambLight);
            }

            if (show == false)
            {
				modelGroup.Children.Remove(_ambLight);
            }
        }

		public void ShowDirLight(int index, bool show, Model3DGroup modelGroup)
        {
            if (show == true)
            {
				modelGroup.Children.Add(_dirLight[index]);
            }

            if (show == false)
            {
				modelGroup.Children.Remove(_dirLight[index]);
            }
        }

        public void ShowPointLight(int indexer, bool show, Model3DGroup modelGroup)
        {
            if (show == true)
            {
                modelGroup.Children.Add(_ptLight);
            }

            if (show == false)
            {
                modelGroup.Children.Remove(_ptLight);
            }
        }

        public Point3D PointLightPosition
        {
            get
            {
                return _ptLight.Position;
            }
            set
            {
                _ptLight.Position = value;
            }
        }

        public double PointLightRange
        {
            get
            {
                return _ptLight.Range;
            }
            set
            {
                _ptLight.Range = value;
            }
        }

        public double PointLightConstantAttenuation
        {
            get
            {
                return _ptLight.ConstantAttenuation;
            }
            set
            {
                _ptLight.ConstantAttenuation = value;
            }
        }

        public double PointLightLinearAttenuation
        {
            get
            {
                return _ptLight.LinearAttenuation;
            }
            set
            {
                _ptLight.LinearAttenuation = value;
            }
        }

        public double PointLightQuadraticAttenuation
        {
            get
            {
                return _ptLight.QuadraticAttenuation;
            }
            set
            {
                _ptLight.QuadraticAttenuation = value;
            }
        }

        public void TransformPointLight(Vector3D pointLightVector, Vector3D changeVector)
        {
            // Transform light vector.
            TranslateTransform3D pointLightTransform = new TranslateTransform3D();
            pointLightTransform.OffsetX = pointLightVector.X;
            pointLightTransform.OffsetY = pointLightVector.Y;
            pointLightTransform.OffsetZ = pointLightVector.Z;
            _ptLight.Position = pointLightTransform.Transform(_ptLight.Position);

        }

    }
}

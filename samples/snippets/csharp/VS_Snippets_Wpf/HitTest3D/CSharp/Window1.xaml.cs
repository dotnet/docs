using System;
using System.Windows;
using System.Collections;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;


namespace HitTest3D
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

        //<SnippetHitTest3D3DN4>
        public void HitTest(object sender, System.Windows.Input.MouseButtonEventArgs args)
        {
            Point mouseposition = args.GetPosition(myViewport);
            Point3D testpoint3D = new Point3D(mouseposition.X, mouseposition.Y, 0);
            Vector3D testdirection = new Vector3D(mouseposition.X, mouseposition.Y, 10);
            PointHitTestParameters pointparams = new PointHitTestParameters(mouseposition);
            RayHitTestParameters rayparams = new RayHitTestParameters(testpoint3D, testdirection);

            //test for a result in the Viewport3D
            VisualTreeHelper.HitTest(myViewport, null, HTResult, pointparams);
        //</SnippetHitTest3D3DN4>
            UpdateTestPointInfo(testpoint3D, testdirection);
        }

        //<SnippetHitTest3D3DN5>
        public HitTestResultBehavior HTResult(System.Windows.Media.HitTestResult rawresult)
        {
            //MessageBox.Show(rawresult.ToString());
            RayHitTestResult rayResult = rawresult as RayHitTestResult;

            if (rayResult != null)
            {
                RayMeshGeometry3DHitTestResult rayMeshResult = rayResult as RayMeshGeometry3DHitTestResult;

                if (rayMeshResult != null)
                {
                    GeometryModel3D hitgeo = rayMeshResult.ModelHit as GeometryModel3D;

                    UpdateResultInfo(rayMeshResult);
                    UpdateMaterial(hitgeo, (side1GeometryModel3D.Material as MaterialGroup));
                }
            }

            return HitTestResultBehavior.Continue;
        }
        //</SnippetHitTest3D3DN5>

        public void UpdateMaterial(GeometryModel3D hitgeo, MaterialGroup changegroup)
        {
            MaterialGroup priorMaterial = hitgeo.Material as MaterialGroup;

            if (hitgeo.Geometry == (MeshGeometry3D)Application.Current.Resources["CubeSide01"])
            {
                HitFaceInfo.Text = "CubeSide01";
                if (priorMaterial == (MaterialGroup)Application.Current.Resources["HitMaterial"])
                {
                    hitgeo.Material = (MaterialGroup)Application.Current.Resources["BranchesMaterial"];
                }
                else
                {
                    hitgeo.Material = (MaterialGroup)Application.Current.Resources["HitMaterial"];
                }
            }
            if (hitgeo.Geometry == (MeshGeometry3D)Application.Current.Resources["CubeSide02"])
            {
                HitFaceInfo.Text = "CubeSide02";
                if (priorMaterial == (MaterialGroup)Application.Current.Resources["HitMaterial"])
                {
                    hitgeo.Material = (MaterialGroup)Application.Current.Resources["FlowersMaterial"];
                }
                else
                {
                    hitgeo.Material = (MaterialGroup)Application.Current.Resources["HitMaterial"];
                }
            }
            if (hitgeo.Geometry == (MeshGeometry3D)Application.Current.Resources["CubeSide03"])
            {
                HitFaceInfo.Text = "CubeSide03";
                if (priorMaterial == (MaterialGroup)Application.Current.Resources["HitMaterial"])
                {
                    hitgeo.Material = (MaterialGroup)Application.Current.Resources["BerriesMaterial"];
                }
                else
                {
                    hitgeo.Material = (MaterialGroup)Application.Current.Resources["HitMaterial"];
                }
            }
            if (hitgeo.Geometry == (MeshGeometry3D)Application.Current.Resources["CubeSide04"])
            {
                HitFaceInfo.Text = "CubeSide04";
                if (priorMaterial == (MaterialGroup)Application.Current.Resources["HitMaterial"])
                {
                    hitgeo.Material = (MaterialGroup)Application.Current.Resources["LeavesMaterial"];
                }
                else
                {
                    hitgeo.Material = (MaterialGroup)Application.Current.Resources["HitMaterial"];
                }
            }
            if (hitgeo.Geometry == (MeshGeometry3D)Application.Current.Resources["CubeSide05"])
            {
                HitFaceInfo.Text = "CubeSide05";
                if (priorMaterial == (MaterialGroup)Application.Current.Resources["HitMaterial"])
                {
                    hitgeo.Material = (MaterialGroup)Application.Current.Resources["RocksMaterial"];
                }
                else
                {
                    hitgeo.Material = (MaterialGroup)Application.Current.Resources["HitMaterial"];
                }
            }
            if (hitgeo.Geometry == (MeshGeometry3D)Application.Current.Resources["CubeSide06"])
            {
                HitFaceInfo.Text = "CubeSide06";
                if (priorMaterial == (MaterialGroup)Application.Current.Resources["HitMaterial"])
                {
                    hitgeo.Material = (MaterialGroup)Application.Current.Resources["SunsetMaterial"];
                }
                else
                {
                    hitgeo.Material = (MaterialGroup)Application.Current.Resources["HitMaterial"];
                }
            }

        }

        //<SnippetHitTest3D3DN7>
        public void UpdateResultInfo(RayMeshGeometry3DHitTestResult rayMeshResult)
        {
            HitVisualInfo.Text = rayMeshResult.VisualHit.ToString();
            HitModelInfo.Text = rayMeshResult.ModelHit.ToString();
            HitMeshInfo.Text = rayMeshResult.MeshHit.ToString();
            //HitMaterialInfo.Text = (rayMeshResult.ModelHit as GeometryModel3D).Material.GetType().Name;
            //HitMaterialBrushInfo.Text = ((rayMeshResult.ModelHit as GeometryModel3D).Material as DiffuseMaterial).Brush.ToString();
            HitDistanceInfo.Text = rayMeshResult.DistanceToRayOrigin.ToString();
            Vertex1Info.Text = (rayMeshResult.VertexWeight1 * 100) + "%";
            Vertex2Info.Text = (rayMeshResult.VertexWeight2 * 100) + "%";
            Vertex3Info.Text = (rayMeshResult.VertexWeight3 * 100) + "%";
        }
        //</SnippetHitTest3D3DN7>

        public void UpdateTestPointInfo(Point3D testpoint3D, Vector3D testdirection)
        {
            TestPointInfo.Text = "Test point (" + testpoint3D.X + "," + testpoint3D.Y + "," + testpoint3D.Z + ")";
            TestVectorInfo.Text = "Test vector (" + testdirection.X + "," + testdirection.Y + "," + testdirection.Z + ")";
        }

        //<SnippetHitTest3D3DN12>
        //Toggle between camera projections.
        public void ToggleCamera(object sender, EventArgs e)
        {
            if ((bool)CameraCheck.IsChecked == true)
            {
                OrthographicCamera myOCamera = new OrthographicCamera(new Point3D(0, 0, -3), new Vector3D(0, 0, 1), new Vector3D(0, 1, 0), 3);
                myViewport.Camera = myOCamera;
            }
            if ((bool)CameraCheck.IsChecked != true)
            {
                PerspectiveCamera myPCamera = new PerspectiveCamera(new Point3D(0, 0, -3), new Vector3D(0, 0, 1), new Vector3D(0, 1, 0), 50);
                myViewport.Camera = myPCamera;
            }
        }
        //</SnippetHitTest3D3DN12>

        //<SnippetHitTest3D3DN13>
        public void AddAnimation(object sender, EventArgs e)
        {
            if ((bool)CenterAnimCheck.IsChecked == true)
            {
                //Shift point around which model rotates to (-0.5, -0.5, -0.5).
                myHorizontalRTransform.CenterX = -0.5;
                myHorizontalRTransform.CenterY = -0.5;
                myHorizontalRTransform.CenterZ = -0.5;
            }
            if ((bool)CenterAnimCheck.IsChecked != true)
            {
                //Set point around which model rotates back to (0, 0, 0).
                myHorizontalRTransform.CenterX = 0;
                myHorizontalRTransform.CenterY = 0;
                myHorizontalRTransform.CenterZ = 0;
            }
        }
        //</SnippetHitTest3D3DN13>


 
    }
}


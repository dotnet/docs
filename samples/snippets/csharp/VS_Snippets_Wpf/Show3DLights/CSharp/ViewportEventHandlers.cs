using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Media3D;

namespace SDKSample
{
    public partial class Window1 : Window
    {
        private readonly double stepAngle = 5.0;
        private readonly double stepDistance = 0.5;
        private readonly double minDistance = 24.0;
        private readonly double maxDistance = 90.0;
        private Vector3D spaceLinesChangeVector = new Vector3D(0.0, 0.0, 0.0);

        // Set focus to viewport when the left mouse button is clicked.
        private void ViewportMouseHandler(object sender, MouseButtonEventArgs e)
        {
           myViewport3D.Focus();
        }

        // Determine whether the camera or point light handles the pressed key.
        private void ViewportKeyHandler(object sender, KeyEventArgs e)
        {
            if (currKeyMode == KeyMode.Camera)
            {
                KeyDownHandlerForCamera(sender, e);
            }

            if (currKeyMode == KeyMode.PointLight)
            {
                KeyDownHandlerForPointLight(sender, e);
            }
        }

        // Process keys for moving the camera position.
        private void KeyDownHandlerForCamera(object sender, KeyEventArgs e)
        {
            double currentDistance, newDistance;
            Vector3D rotationAxis;
            RotateTransform3D rotationTransform;
            PerspectiveCamera camera = (PerspectiveCamera)myViewport3D.Camera;

            switch (e.Key)
            {
                case Key.Up:
                    rotationAxis = Vector3D.CrossProduct((Vector3D)camera.Position, camera.UpDirection);
                    rotationTransform = new RotateTransform3D(new AxisAngleRotation3D(rotationAxis, stepAngle));

                    camera.Position = rotationTransform.Transform(camera.Position);
                    camera.UpDirection = rotationTransform.Transform(camera.UpDirection);

                    e.Handled = true;
                    break;

                case Key.Down:
                    rotationAxis = Vector3D.CrossProduct((Vector3D)camera.Position, camera.UpDirection);
                    rotationTransform = new RotateTransform3D(new AxisAngleRotation3D(rotationAxis, -stepAngle));

                    camera.Position = rotationTransform.Transform(camera.Position);
                    camera.UpDirection = rotationTransform.Transform(camera.UpDirection);

                    e.Handled = true;
                    break;

                case Key.Left:
                    rotationAxis = camera.UpDirection;
                    rotationTransform = new RotateTransform3D(new AxisAngleRotation3D(rotationAxis, -stepAngle));

                    camera.Position = rotationTransform.Transform(camera.Position);
                    camera.UpDirection = rotationTransform.Transform(camera.UpDirection);

                    e.Handled = true;
                    break;

                case Key.Right:
                    rotationAxis = camera.UpDirection;
                    rotationTransform = new RotateTransform3D(new AxisAngleRotation3D(rotationAxis, stepAngle));

                    camera.Position = rotationTransform.Transform(camera.Position);
                    camera.UpDirection = rotationTransform.Transform(camera.UpDirection);

                    e.Handled = true;
                    break;

                case Key.OemPlus:
                case Key.Add:
                    currentDistance = ((Vector3D)camera.Position).Length;
                    newDistance = currentDistance - stepDistance;

                    if (newDistance > minDistance)
                    {
                        double scale = newDistance / currentDistance;
                        camera.Position *= new ScaleTransform3D(new Vector3D(scale, scale, scale)).Value;
                    }

                    e.Handled = true;
                    break;

                case Key.OemMinus:
                case Key.Subtract:
                    currentDistance = ((Vector3D)camera.Position).Length;
                    newDistance = currentDistance + stepDistance;

                    if (newDistance < maxDistance)
                    {
                        double scale = newDistance / currentDistance;
                        camera.Position *= new ScaleTransform3D(new Vector3D(scale, scale, scale)).Value;
                    }

                    e.Handled = true;
                    break;

                case Key.OemComma:
                    rotationAxis = (Vector3D)camera.Position;
                    rotationTransform = new RotateTransform3D(new AxisAngleRotation3D(rotationAxis, stepAngle));

                    camera.UpDirection = rotationTransform.Transform(camera.UpDirection);

                    e.Handled = true;
                    break;

                case Key.OemPeriod:
                    rotationAxis = (Vector3D)camera.Position;
                    rotationTransform = new RotateTransform3D(new AxisAngleRotation3D(rotationAxis, -stepAngle));

                    camera.UpDirection = rotationTransform.Transform(camera.UpDirection);

                    e.Handled = true;
                    break;
            }
        }

        // Process keys for moving the point light position.
        private void KeyDownHandlerForPointLight(object sender, KeyEventArgs e)
        {
            Vector3D pointLightVector = new Vector3D(0.0, 0.0, 0.0);

            switch (e.Key)
            {
                case Key.Up:
                    spaceLinesChangeVector.Y += 1;
                    pointLightVector.Y = 1;
                    e.Handled = true;
                    break;

                case Key.Down:
                    spaceLinesChangeVector.Y -= 1;
                    pointLightVector.Y = -1;
                    e.Handled = true;
                    break;

                case Key.Left:
                    spaceLinesChangeVector.X -= 1;
                    pointLightVector.X = -1;
                    e.Handled = true;
                    break;

                case Key.Right:
                    spaceLinesChangeVector.X += 1;
                    pointLightVector.X = 1;
                    e.Handled = true;
                    break;

                case Key.OemPlus:
                case Key.Add:
                    spaceLinesChangeVector.Z -= 1;
                    pointLightVector.Z = -1;
                    e.Handled = true;
                    break;

                case Key.OemMinus:
                case Key.Subtract:
                    spaceLinesChangeVector.Z += 1;
                    pointLightVector.Z = 1;
                    e.Handled = true;
                    break;
            }

            if (e.Handled == true)
            {
                // Transform point light.
                myLights.TransformPointLight(pointLightVector, spaceLinesChangeVector);

                xyzPointLight.Content = "x: " + myLights.PointLightPosition.X + "  y: " + myLights.PointLightPosition.Y + "  z: " + myLights.PointLightPosition.Z;
            }
        }
    }
}

Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Media.Media3D
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes


Namespace QuaternionView
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window
		'Set globals
		'<SnippetQuaternionView3DN1>
		Private startQuaternion As New Quaternion(0,0,1,0)
		'</SnippetQuaternionView3DN1>
		Private endQuaternion As New Quaternion()
		Private myTranslation As New TranslateTransform3D()
		Private baseRotateTransform3D As New RotateTransform3D()
		Private startRotation As New QuaternionRotation3D()
		Private endRotation As New QuaternionRotation3D()
		Private myprocTransformGroup As New Transform3DGroup()
		Private mydefaultAnimation As New Rotation3DAnimation()
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub UpdateWXYZSettings(ByVal sender As Object, ByVal e As EventArgs)
			'Clear prior values
			myprocTransformGroup.Children.Clear()
			XAxisValue.Clear()
			YAxisValue.Clear()
			ZAxisValue.Clear()
			AngleValue.Clear()

			'<SnippetQuaternionView3DN2>
			'Read new settings
			Dim setW As Double = System.Convert.ToDouble(WValue.Text)
			Dim setX As Double = System.Convert.ToDouble(XValue.Text)
			Dim setY As Double = System.Convert.ToDouble(YValue.Text)
			Dim setZ As Double = System.Convert.ToDouble(ZValue.Text)

			endQuaternion = New Quaternion(setX, setY, setZ, setW)
			endRotation.Quaternion = endQuaternion

			'Update axis and angle textboxes
			XAxisValue.Text = endQuaternion.Axis.X.ToString()
			YAxisValue.Text = endQuaternion.Axis.Y.ToString()
			ZAxisValue.Text = endQuaternion.Axis.Z.ToString()
			AngleValue.Text = endQuaternion.Angle.ToString()

			startAnimation()
			'</SnippetQuaternionView3DN2>
		End Sub

		Private Sub UpdateParseXYZWSettings(ByVal sender As Object, ByVal e As EventArgs)
			'Clear prior values
			myprocTransformGroup.Children.Clear()
			XAxisValue.Clear()
			YAxisValue.Clear()
			ZAxisValue.Clear()
			AngleValue.Clear()

			'<SnippetQuaternionView3DN3>
			Try
				endQuaternion = Quaternion.Parse(ParseValue.Text)
			Catch
				ParseValue.Text = "Must input (X, Y, Z, W)"
			End Try

			endRotation.Quaternion = endQuaternion
			'</SnippetQuaternionView3DN3>

			'Update axis and angle textboxes
			XAxisValue.Text = endQuaternion.Axis.X.ToString()
			YAxisValue.Text = endQuaternion.Axis.Y.ToString()
			ZAxisValue.Text = endQuaternion.Axis.Z.ToString()
			AngleValue.Text = endQuaternion.Angle.ToString()

			startAnimation()
		End Sub

		Private Sub UpdateAxisAngleSettings(ByVal sender As Object, ByVal e As EventArgs)
			'Clear prior values
			myprocTransformGroup.Children.Clear()
			WValue.Clear()
			XValue.Clear()
			YValue.Clear()
			ZValue.Clear()

			'<SnippetQuaternionView3DN4>
			'Read new settings
			Dim angle As Double = System.Convert.ToDouble(AngleValue.Text)
			Try
				Dim xaxis As Double = System.Convert.ToDouble(XAxisValue.Text)
				Dim yaxis As Double = System.Convert.ToDouble(YAxisValue.Text)
				Dim zaxis As Double = System.Convert.ToDouble(ZAxisValue.Text)

				endQuaternion = New Quaternion(New Vector3D(xaxis, yaxis, zaxis), angle)
			Catch
				XAxisValue.Text = "Axis must be nonzero Vector3D"
				YAxisValue.Text = "Axis must be nonzero Vector3D"
				ZAxisValue.Text = "Axis must be nonzero Vector3D"
			End Try

			endRotation.Quaternion = endQuaternion
			'</SnippetQuaternionView3DN4>

			'Update quaternion display
			WValue.Text = endQuaternion.W.ToString()
			XValue.Text = endQuaternion.X.ToString()
			YValue.Text = endQuaternion.Y.ToString()
			ZValue.Text = endQuaternion.Z.ToString()

			'build in some if clauses to determine the animation method to call
			startAnimation()
		End Sub

		Public Sub startAnimation()
			mydefaultAnimation.From = startRotation
			mydefaultAnimation.To = endRotation
			mydefaultAnimation.Duration = New Duration(TimeSpan.FromMilliseconds(3000))
			mydefaultAnimation.FillBehavior = FillBehavior.HoldEnd

			baseRotateTransform3D.BeginAnimation(RotateTransform3D.RotationProperty, mydefaultAnimation)
			myprocTransformGroup.Children.Add(baseRotateTransform3D)
			topModelVisual3D.Transform = myprocTransformGroup

			'Update text boxes
			'TransformMatrix.Text = myprocTransformGroup.Value.ToString()
			'TransformMatrix.Text = baseRotateTransform3D.Value.ToString()

			AxisAngleString.Text = endQuaternion.ToString()
			'resulting string is (x,y,z,w)

		End Sub

	End Class
End Namespace
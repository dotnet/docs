//<Snippet1>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Ink;

public class RotatingStrokesAdorner : Adorner
{
    // The Thumb to drag to rotate the strokes.
    private Thumb _rotateHandle;

    // The surrounding boarder.
    private Path _outline;

    private VisualCollection _visualChildren;

    // The center of the strokes.
    private Point _center;
    private double _lastAngle;

    private RotateTransform _rotation;

    private const int HANDLEMARGIN = 10;

    // The bounds of the Strokes;
    private Rect _strokeBounds;

    public RotatingStrokesAdorner(UIElement adornedElement)
        : base(adornedElement)
    {

        _visualChildren = new VisualCollection(this);
        _rotateHandle = new Thumb();
        _rotateHandle.Cursor = Cursors.SizeNWSE;
        _rotateHandle.Width = 20;
        _rotateHandle.Height = 20;
        _rotateHandle.Background = Brushes.Blue;

        _rotateHandle.DragDelta += new DragDeltaEventHandler(RotateHandle_DragDelta);
        _rotateHandle.DragCompleted += new DragCompletedEventHandler(RotateHandle_DragCompleted);

        _outline = new Path();
        _outline.Stroke = Brushes.Blue;
        _outline.StrokeThickness = 1;

        _visualChildren.Add(_outline);
        _visualChildren.Add(_rotateHandle);

        _strokeBounds = AdornedStrokes.GetBounds();
    }

    /// <summary>
    /// Draw the rotation handle and the outline of
    /// the element.
    /// </summary>
    /// <param name="finalSize">The final area within the
    /// parent that this element should use to arrange
    /// itself and its children.</param>
    /// <returns>The actual size used. </returns>
    protected override Size ArrangeOverride(Size finalSize)
    {
        if (_strokeBounds.IsEmpty)
        {
            return finalSize;
        }

        _center = new Point(_strokeBounds.X + _strokeBounds.Width / 2,
                           _strokeBounds.Y + _strokeBounds.Height / 2);

        // The rectangle that determines the position of the Thumb.
        Rect handleRect = new Rect(_strokeBounds.X,
                              _strokeBounds.Y - (_strokeBounds.Height / 2 +
                                                HANDLEMARGIN),
                              _strokeBounds.Width, _strokeBounds.Height);

        if (_rotation != null)
        {
            handleRect.Transform(_rotation.Value);
        }

        // Draws the thumb and the rectangle around the strokes.
        _rotateHandle.Arrange(handleRect);
        _outline.Data = new RectangleGeometry(_strokeBounds);
        _outline.Arrange(new Rect(finalSize));
        return finalSize;
    }

    /// <summary>
    /// Rotates the rectangle representing the
    /// strokes' bounds as the user drags the
    /// Thumb.
    /// </summary>
    private void RotateHandle_DragDelta(object sender, DragDeltaEventArgs e)
    {
        // Find the angle of which to rotate the shape.  Use the right
        // triangle that uses the center and the mouse's position
        // as vertices for the hypotenuse.

        Point pos = Mouse.GetPosition(this);

        double deltaX = pos.X - _center.X;
        double deltaY = pos.Y - _center.Y;

        if (deltaY.Equals(0))
        {

            return;
        }

        double tan = deltaX / deltaY;
        double angle = Math.Atan(tan);

        // Convert to degrees.
        angle = angle * 180 / Math.PI;

        // If the mouse crosses the vertical center,
        // find the complementary angle.
        if (deltaY > 0)
        {
            angle = 180 - Math.Abs(angle);
        }

        // Rotate left if the mouse moves left and right
        // if the mouse moves right.
        if (deltaX < 0)
        {
            angle = -Math.Abs(angle);
        }
        else
        {
            angle = Math.Abs(angle);
        }

        if (double.IsNaN(angle))
        {
            return;
        }

        // Apply the rotation to the strokes' outline.
        _rotation = new RotateTransform(angle, _center.X, _center.Y);
        _outline.RenderTransform = _rotation;
    }

    /// <summary>
    /// Rotates the strokes to the same angle as outline.
    /// </summary>
    private void RotateHandle_DragCompleted(object sender,
                                    DragCompletedEventArgs e)
    {
        if (_rotation == null)
        {
            return;
        }

        // Rotate the strokes to match the new angle.
        Matrix mat = new Matrix();
        mat.RotateAt(_rotation.Angle - _lastAngle, _center.X, _center.Y);
        AdornedStrokes.Transform(mat, true);

        // Save the angle of the last rotation.
        _lastAngle = _rotation.Angle;

        // Redraw rotateHandle.
        this.InvalidateArrange();
    }

    /// <summary>
    /// Gets the strokes of the adorned element
    /// (in this case, an InkPresenter).
    /// </summary>
    private StrokeCollection AdornedStrokes
    {
        get
        {
            return ((InkPresenter)AdornedElement).Strokes;
        }
    }

    // Override the VisualChildrenCount and
    // GetVisualChild properties to interface with
    // the adorner's visual collection.
    protected override int VisualChildrenCount
    {
        get { return _visualChildren.Count; }
    }

    protected override Visual GetVisualChild(int index)
    {
        return _visualChildren[index];
    }
}
//</Snippet1>

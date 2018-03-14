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
    Thumb rotateHandle;

    // The surrounding boarder.
    Path outline;

    VisualCollection visualChildren;

    // The center of the strokes.
    Point center;
    double lastAngle;

    RotateTransform rotation;

    const int HANDLEMARGIN = 10;

    // The bounds of the Strokes;
    Rect strokeBounds = Rect.Empty;

    public RotatingStrokesAdorner(UIElement adornedElement)
        : base(adornedElement)
    {

        visualChildren = new VisualCollection(this);
        rotateHandle = new Thumb();
        rotateHandle.Cursor = Cursors.SizeNWSE;
        rotateHandle.Width = 20;
        rotateHandle.Height = 20;
        rotateHandle.Background = Brushes.Blue;

        rotateHandle.DragDelta += new DragDeltaEventHandler(rotateHandle_DragDelta);
        rotateHandle.DragCompleted += new DragCompletedEventHandler(rotateHandle_DragCompleted);

        outline = new Path();
        outline.Stroke = Brushes.Blue;
        outline.StrokeThickness = 1;

        visualChildren.Add(outline);
        visualChildren.Add(rotateHandle);

        strokeBounds = AdornedStrokes.GetBounds();
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
        if (strokeBounds.IsEmpty)
        {
            return finalSize;
        }

        center = new Point(strokeBounds.X + strokeBounds.Width / 2,
                           strokeBounds.Y + strokeBounds.Height / 2);

        // The rectangle that determines the position of the Thumb.
        Rect handleRect = new Rect(strokeBounds.X,
                              strokeBounds.Y - (strokeBounds.Height / 2 +
                                                HANDLEMARGIN),
                              strokeBounds.Width, strokeBounds.Height);

        if (rotation != null)
        {
            handleRect.Transform(rotation.Value);
        }

        // Draws the thumb and the rectangle around the strokes.
        rotateHandle.Arrange(handleRect);
        outline.Data = new RectangleGeometry(strokeBounds);
        outline.Arrange(new Rect(finalSize));
        return finalSize;
    }

    /// <summary>
    /// Rotates the rectangle representing the
    /// strokes' bounds as the user drags the
    /// Thumb.
    /// </summary>
    void rotateHandle_DragDelta(object sender, DragDeltaEventArgs e)
    {
        // Find the angle of which to rotate the shape.  Use the right
        // triangle that uses the center and the mouse's position 
        // as vertices for the hypotenuse.

        Point pos = Mouse.GetPosition(this);

        double deltaX = pos.X - center.X;
        double deltaY = pos.Y - center.Y;

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

        if (Double.IsNaN(angle))
        {
            return;
        }

        // Apply the rotation to the strokes' outline.
        rotation = new RotateTransform(angle, center.X, center.Y);
        outline.RenderTransform = rotation;
    }

    /// <summary>
    /// Rotates the strokes to the same angle as outline.
    /// </summary>
    void rotateHandle_DragCompleted(object sender,
                                    DragCompletedEventArgs e)
    {
        if (rotation == null)
        {
            return;
        }

        // Rotate the strokes to match the new angle.
        Matrix mat = new Matrix();
        mat.RotateAt(rotation.Angle - lastAngle, center.X, center.Y);
        AdornedStrokes.Transform(mat, true);

        // Save the angle of the last rotation.
        lastAngle = rotation.Angle;

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
        get { return visualChildren.Count; }
    }

    protected override Visual GetVisualChild(int index)
    {
        return visualChildren[index];
    }
}
//</Snippet1>
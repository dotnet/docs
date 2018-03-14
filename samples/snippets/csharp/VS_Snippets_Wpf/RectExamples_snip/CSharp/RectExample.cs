using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Microsoft.Samples.RectExamples
{

    public class RectExample : Page
    {
    
        
        public RectExample()
        {
            
            StackPanel mainPanel = new StackPanel();

            mainPanel.Children.Add(createRectExample1());

            TextBlock createRectExample2Text = new TextBlock();
            createRectExample2Text.Text = "createRectExample2: " + createRectExample2().ToString();
            mainPanel.Children.Add(createRectExample2Text);

            TextBlock createRectExample3Text = new TextBlock();
            createRectExample3Text.Text = "createRectExample3: " + createRectExample3().ToString();
            mainPanel.Children.Add(createRectExample3Text);

            TextBlock createRectExample4Text = new TextBlock();
            createRectExample4Text.Text = "createRectExample4: " + createRectExample4().ToString();
            mainPanel.Children.Add(createRectExample4Text);

            TextBlock createRectExample5Text = new TextBlock();
            createRectExample5Text.Text = "createRectExample5: " + createRectExample5().ToString();
            mainPanel.Children.Add(createRectExample5Text);

            TextBlock createRectExample6Text = new TextBlock();
            createRectExample6Text.Text = "createRectExample6: " + createRectExample6().ToString();
            mainPanel.Children.Add(createRectExample6Text);

            TextBlock rectContainsExample1Text = new TextBlock();
            rectContainsExample1Text.Text = "rectContainsExample1: " + rectContainsExample1().ToString();
            mainPanel.Children.Add(rectContainsExample1Text);

            TextBlock rectContainsExample2Text = new TextBlock();
            rectContainsExample2Text.Text = "rectContainsExample2: " + rectContainsExample2().ToString();
            mainPanel.Children.Add(rectContainsExample2Text);

            TextBlock rectContainsExample3Text = new TextBlock();
            rectContainsExample3Text.Text = "rectContainsExample3: " + rectContainsExample3().ToString();
            mainPanel.Children.Add(rectContainsExample3Text);

            TextBlock rectEqualsExample1Text = new TextBlock();
            rectEqualsExample1Text.Text = "rectEquals1: " + rectEqualsExample1().ToString();
            mainPanel.Children.Add(rectEqualsExample1Text);

            TextBlock rectEqualsExample2Text = new TextBlock();
            rectEqualsExample2Text.Text = "rectEquals2: " + rectEqualsExample2().ToString();
            mainPanel.Children.Add(rectEqualsExample2Text);

            TextBlock getHashCodeExampleText = new TextBlock();
            getHashCodeExampleText.Text = "getHashCodeExample: " + getHashCodeExample().ToString();
            mainPanel.Children.Add(getHashCodeExampleText);

            TextBlock inflateExample1Text = new TextBlock();
            inflateExample1Text.Text = "inflateExample1: " + inflateExample1().ToString();
            mainPanel.Children.Add(inflateExample1Text);

            TextBlock inflateExample2Text = new TextBlock();
            inflateExample2Text.Text = "inflateExample2: " + inflateExample2().ToString();
            mainPanel.Children.Add(inflateExample2Text);

            TextBlock inflateExample3Text = new TextBlock();
            inflateExample3Text.Text = "inflateExample3: " + inflateExample3().ToString();
            mainPanel.Children.Add(inflateExample3Text);

            TextBlock inflateExample4Text = new TextBlock();
            inflateExample4Text.Text = "inflateExample4: " + inflateExample4().ToString();
            mainPanel.Children.Add(inflateExample4Text);

            TextBlock intersectExample1Text = new TextBlock();
            intersectExample1Text.Text = "intersectExample1: " + intersectExample1().ToString();
            mainPanel.Children.Add(intersectExample1Text);

            TextBlock intersectExample2Text = new TextBlock();
            intersectExample2Text.Text = "intersectExample2: " + intersectExample2().ToString();
            mainPanel.Children.Add(intersectExample2Text);

            TextBlock intersectsWithExampleText = new TextBlock();
            intersectsWithExampleText.Text = "intersectsWithExample: " + intersectsWithExample().ToString();
            mainPanel.Children.Add(intersectsWithExampleText);

            TextBlock offsetExample1Text = new TextBlock();
            offsetExample1Text.Text = "offsetExample1: " + offsetExample1().ToString();
            mainPanel.Children.Add(offsetExample1Text);

            TextBlock offsetExample2Text = new TextBlock();
            offsetExample2Text.Text = "offsetExample2: " + offsetExample2().ToString();
            mainPanel.Children.Add(offsetExample2Text);

            TextBlock offsetExample3Text = new TextBlock();
            offsetExample3Text.Text = "offsetExample3: " + offsetExample3().ToString();
            mainPanel.Children.Add(offsetExample3Text);

            TextBlock offsetExample4Text = new TextBlock();
            offsetExample4Text.Text = "offsetExample4: " + offsetExample4().ToString();
            mainPanel.Children.Add(offsetExample4Text);

            TextBlock overloadedEqualityOperatorExampleText = new TextBlock();
            overloadedEqualityOperatorExampleText.Text = "overloadedEqualityOperatorExample: " + overloadedEqualityOperatorExample().ToString();
            mainPanel.Children.Add(overloadedEqualityOperatorExampleText);

            TextBlock overloadedInequalityOperatorExampleText = new TextBlock();
            overloadedInequalityOperatorExampleText.Text = "overloadedInequalityOperatorExample: " + overloadedInequalityOperatorExample().ToString();
            mainPanel.Children.Add(overloadedInequalityOperatorExampleText);

            TextBlock parseExampleText = new TextBlock();
            parseExampleText.Text = "parseExample: " + parseExample().ToString();
            mainPanel.Children.Add(parseExampleText);

            TextBlock scaleExampleText = new TextBlock();
            scaleExampleText.Text = "scaleExample: " + scaleExample().ToString();
            mainPanel.Children.Add(scaleExampleText);

            TextBlock unionExample1Text = new TextBlock();
            unionExample1Text.Text = "unionExample1: " + unionExample1().ToString();
            mainPanel.Children.Add(unionExample1Text);

            TextBlock unionExample2Text = new TextBlock();
            unionExample2Text.Text = "unionExample2: " + unionExample2().ToString();
            mainPanel.Children.Add(unionExample2Text);

            TextBlock unionExample3Text = new TextBlock();
            unionExample3Text.Text = "unionExample3: " + unionExample3().ToString();
            mainPanel.Children.Add(unionExample3Text);

            TextBlock unionExample4Text = new TextBlock();
            unionExample4Text.Text = "unionExample4: " + unionExample4().ToString();
            mainPanel.Children.Add(unionExample4Text);

            TextBlock transformExample1Text = new TextBlock();
            transformExample1Text.Text = "transformExample1: " + transformExample1().ToString();
            mainPanel.Children.Add(transformExample1Text);

            TextBlock transformExample2Text = new TextBlock();
            transformExample2Text.Text = "transformExample2: " + transformExample2().ToString();
            mainPanel.Children.Add(transformExample2Text);
            
            this.Content = mainPanel;
        }


        // <SnippetCreateRectExample1_csharp>
        // Create a rectangle and add it to the page. Also,
        // find size and coordinate information about this
        // new rectangle and render information in a TextBox 
        // below the rectangle.
        private StackPanel createRectExample1()
        {
            // Initialize new rectangle.
            Rect myRectangle = new Rect();

            // The Location property specifies the coordinates of the upper left-hand 
            // corner of the rectangle. Set the Location property to an X coordinate of 10 and a
            // Y coordinate of 5. 
            myRectangle.Location = new Point(10, 5);

            // Set the Size property of the rectangle with a width of 200
            // and a height of 50.
            myRectangle.Size = new Size(200, 50);

            RectangleGeometry myRectangleGeometry = new RectangleGeometry();
            myRectangleGeometry.Rect = myRectangle;

            // This path is defined by the rectangle.
            Path myPath = new Path();
            myPath.Fill = Brushes.LemonChiffon;
            myPath.Stroke = Brushes.Black;
            myPath.StrokeThickness = 1;
            myPath.Data = myRectangleGeometry;

            //////////// Create string of rectangle property information /////////////
            // This string will contain all the size and coordinate property
            // information about the rectangle.
            /////////////////////////////////////////////////////////////////////////
            string rectInfo = "Rectangle Property Information: ";

            // Bottom property gets the y-axis value of the bottom of the rectangle. 
            // For this rectangle the value is 55.
            rectInfo = rectInfo + "Bottom: " + myRectangle.Bottom;

            // BottomLeft property gets the coordinates of the bottom left corner of the rectangle. 
            // For this rectangle the value is 10,55.
            rectInfo = rectInfo + "| BottomLeft: " + myRectangle.BottomLeft;

            // BottomRight property gets the coordinates of the bottom right corner of the rectangle. 
            // For this rectangle the value is 210,55.
            rectInfo = rectInfo + "| BottomRight: " + myRectangle.BottomRight;

            // Height property gets or sets the height of the rectangle. 
            // For this rectangle the value is 50.
            rectInfo = rectInfo + "| Height: " + myRectangle.Height;

            // Width property gets or sets the width of the rectangle. 
            // For this rectangle the value is 200.
            rectInfo = rectInfo + "| Width: " + myRectangle.Width;

            // Left property gets the x-axis position of the left side of the rectangle which is 
            // equivalent to getting the rectangle's X property. 
            // For this rectangle the value is 10.
            rectInfo = rectInfo + "| Left: " + myRectangle.Left;

            // Location property gets or sets the position of the rectangle's top-left corner.
            // For this rectangle the value is 10,5.
            rectInfo = rectInfo + "| Location: " + myRectangle.Location;

            // Right property gets the x-axis value of the right side of the rectangle. 
            // For this rectangle the value is 210.
            rectInfo = rectInfo + "| Right: " + myRectangle.Right;

            // Size property gets or sets the width and height of the rectangle.  
            // For this rectangle the value is 200,50.
            rectInfo = rectInfo + "| Size: " + myRectangle.Size;

            // Top property gets the y-axis position of the top of the rectangle which is 
            // equivalent to getting the rectangle's Y property.
            // For this rectangle the value is 5.
            rectInfo = rectInfo + "| Top: " + myRectangle.Top;

            // TopLeft property gets the position of the top-left corner of the rectangle, which 
            // is equivalent to (X, Y).   
            // For this rectangle the value is 10,5.
            rectInfo = rectInfo + "| TopLeft: " + myRectangle.TopLeft;

            // TopRight property gets the position of the top-left corner of the rectangle, which 
            // is equivalent to (X + Width, Y).   
            // For this rectangle the value is 210,5.
            rectInfo = rectInfo + "| TopRight: " + myRectangle.TopRight;

            // X property gets or sets the location of the rectangle's left side.  
            // For this rectangle the value is 10.
            rectInfo = rectInfo + "| X: " + myRectangle.X;

            // Y property gets or sets the location of the rectangle's top side.  
            // For this rectangle the value is 5.
            rectInfo = rectInfo + "| Y: " + myRectangle.Y;

            //////// End of creating string containing rectangle property information ////////

            // This StackPanel will contain the rectangle and TextBlock.
            StackPanel parentPanel = new StackPanel();

            // Add the rectangle path to the StackPanel. This will display the rectangle.
            parentPanel.Children.Add(myPath);

            // Add a TextBlock to display the rectangle's size and coordinate information.
            TextBlock myTextBlock = new TextBlock();
            myTextBlock.Text = rectInfo;
            parentPanel.Children.Add(myTextBlock);

            // Return the parent container to be displayed to the screen.
            return parentPanel;
        }
        // </SnippetCreateRectExample1_csharp> 

        // <SnippetCreateRectExample2_csharp>
        private Rect createRectExample2()
        {
            // This constructor initializes a new instance of the Rect structure that 
            // is of the specified size and is located at (0,0). 
            Rect myRectangle = new Rect(new Size(200, 50));

            // Returns a rectangle with a width of 200, a height of 50 and a position
            // of 0,0.
            return myRectangle;

        }
        // </SnippetCreateRectExample2_csharp>

        // <SnippetCreateRectExample3_csharp>
        private Rect createRectExample3()
        {
            // This constructor intializes a new instance of the Rect structure that is 
            // exactly large enough to contain the two specified points.  
            Rect myRectangle = new Rect(new Point(15, 30), new Point(50,70));

            // Returns a rectangle with a position of 15,30, a width of 35 and height of 40.
            return myRectangle;

        }
        // </SnippetCreateRectExample3_csharp>

        // <SnippetCreateRectExample4_csharp>
        private Rect createRectExample4()
        {
            // This constructor initializes a new instance of the Rect structure that has the 
            // specified top-left corner location and the specified width and height (Size).    
            Rect myRectangle = new Rect(new Point(15, 30), new Size(35, 40));

            // Returns a rectangle with a position of 15,30, a width of 35 and height of 40.
            return myRectangle;

        }
        // </SnippetCreateRectExample4_csharp>

        // <SnippetCreateRectExample5_csharp>
        private Rect createRectExample5()
        {
            // This constructor Intializes a new instance of the Rect structure that is exactly 
            // large enough to contain the specified point and the sum of the specified point 
            // and the specified vector.   
            Rect myRectangle = new Rect(new Point(15, 30), new Vector(35, 40));

            // Returns a rectangle with a position of 15,30, a width of 35 and height of 40.
            return myRectangle;

        }
        // </SnippetCreateRectExample5_csharp>

        // <SnippetCreateRectExample6_csharp>
        private Rect createRectExample6()
        {
            // This constructor intializes a new instance of the Rect structure with the specified 
            // x- and y-coordinates and the specified width and height. 
            Rect myRectangle = new Rect(15, 30, 35, 40);

            // Returns a rectangle with a position of 15,30, a width of 35 and height of 40.
            return myRectangle;

        }
        // </SnippetCreateRectExample6_csharp>


        // <SnippetContainsExample1_csharp>
        private bool rectContainsExample1()
        {
            // Initialize new rectangle.
            Rect myRectangle = new Rect();

            // The Location property specifies the coordinates of the upper left-hand 
            // corner of the rectangle. 
            myRectangle.Location = new Point(10, 5);

            // Set the Size property of the rectangle with a width of 200
            // and a height of 50.
            myRectangle.Size = new Size(200, 50);

            // Using the Contains method, see if the rectangle contains the specified
            // point. doesContain is true because the point is inside of myRectangle.
            bool doesContain = myRectangle.Contains(new Point(13, 30));

            return doesContain;

        }
        // </SnippetContainsExample1_csharp>

        // <SnippetContainsExample2_csharp>
        private bool rectContainsExample2()
        {
            // Create a rectangle.
            Rect myRectangle1 = new Rect();

            // The Location property specifies the coordinates of the upper left-hand 
            // corner of the rectangle. 
            myRectangle1.Location = new Point(10, 5);

            // Set the Size property of the rectangle with a width of 200
            // and a height of 50.
            myRectangle1.Size = new Size(200, 50);

            // Create second rectangle.
            Rect myRectangle2 = new Rect();
            myRectangle2.Location = new Point(12, 12);
            myRectangle2.Size = new Size(10, 60);

            // Using the Contains method, see if the second rectangle is 
            // contained within the first rectangle. doesContain is false
            // because only part of myRectangle2 is contained in myRectangle1 
            // (myRectangle2 is too wide).
            bool doesContain = myRectangle1.Contains(myRectangle2);

            return doesContain;

        }
        // </SnippetContainsExample2_csharp>

        // <SnippetContainsExample3_csharp>
        private bool rectContainsExample3()
        {
            // Initialize new rectangle.
            Rect myRectangle = new Rect();

            // The Location property specifies the coordinates of the upper left-hand 
            // corner of the rectangle. 
            myRectangle.Location = new Point(10, 5);

            // Set the Size property of the rectangle with a width of 200
            // and a height of 50.
            myRectangle.Size = new Size(200, 50);

            // Using the Contains method, see if the rectangle contains the specified
            // point specified by the given X and Y coordinates. doesContain is false 
            // because the X and Y coordinates specify a point outside of myRectangle.
            bool doesContain = myRectangle.Contains(4, 13);

            return doesContain;

        }
        // </SnippetContainsExample3_csharp>


        // <SnippetEqualsExample1_csharp>
        private bool rectEqualsExample1()
        {
            // Create a rectangle.
            Rect myRectangle1 = new Rect();

            // The Location property specifies the coordinates of the upper left-hand 
            // corner of the rectangle. 
            myRectangle1.Location = new Point(10, 5);

            // Set the Size property of the rectangle with a width of 200
            // and a height of 50.
            myRectangle1.Size = new Size(200, 50);

            // Create second rectangle to compare to the first.
            Rect myRectangle2 = new Rect();
            myRectangle2.Location = new Point(10, 5);
            myRectangle2.Size = new Size(200, 50);

            // Using the Equals method, see if the second rectangle is the
            // same as the first rectangle. doesEqual is true because both
            // rectangles are exactly the same with respect to location and size. 
            bool doesEqual = myRectangle1.Equals(myRectangle2);

            return doesEqual;

        }
        // </SnippetEqualsExample1_csharp>

        // <SnippetEqualsExample2_csharp>
        private bool rectEqualsExample2()
        {
            // Create a rectangle.
            Rect myRectangle1 = new Rect();

            // The Location property specifies the coordinates of the upper left-hand 
            // corner of the rectangle. 
            myRectangle1.Location = new Point(10, 5);

            // Set the Size property of the rectangle with a width of 200
            // and a height of 50.
            myRectangle1.Size = new Size(200, 50);

            // Create second rectangle to compare to the first.
            Rect myRectangle2 = new Rect();
            myRectangle2.Location = new Point(10, 5);
            myRectangle2.Size = new Size(200, 50);

            // Using the Equals method, see if the second rectangle is 
            // the same as the first rectangle. doesEqual is true because
            // both rectangles are exactly the same in that they both have the 
            // same location and size.
            bool doesEqual = Rect.Equals(myRectangle1, myRectangle2);

            return doesEqual;

        }
        // </SnippetEqualsExample2_csharp>

        // <SnippetGetHashCodeExample_csharp>
        private int getHashCodeExample()
        {
            // Initialize new rectangle.
            Rect myRectangle = new Rect();

            // The Location property specifies the coordinates of the upper left-hand 
            // corner of the rectangle. 
            myRectangle.Location = new Point(10, 5);

            // Set the Size property of the rectangle with a width of 200
            // and a height of 50.
            myRectangle.Size = new Size(200, 50);
            
            // Get the hashcode of the rectangle.
            int returnHashCode = myRectangle.GetHashCode();

            return returnHashCode;

        }
        // </SnippetGetHashCodeExample_csharp>

        // <SnippetInflateExample1_csharp>
        private Size inflateExample1()
        {
            // Initialize new rectangle.
            Rect myRectangle = new Rect();

            // The Location property specifies the coordinates of the upper left-hand 
            // corner of the rectangle. 
            myRectangle.Location = new Point(10, 5);

            // Set the Size property of the rectangle with a width of 200
            // and a height of 50.
            myRectangle.Size = new Size(200, 50);

            // Use the Inflate method to expand the rectangle by the specified Size in all
            // directions. The new size is 240,110. Note: Width of the resulting rectangle  
            // is increased by twice the Width of the specified Size structure because  
            // both the left and right sides of the rectangle are inflated. Likewise, the 
            // Height of the resulting rectangle is increased by twice the Height of the 
            // specified Size structure.
            myRectangle.Inflate(new Size(20,30));

            return myRectangle.Size;

        }
        // </SnippetInflateExample1_csharp>

        // <SnippetInflateExample2_csharp>
        private Size inflateExample2()
        {
            // Initialize new rectangle.
            Rect myRectangle = new Rect();

            // The Location property specifies the coordinates of the upper left-hand 
            // corner of the rectangle. 
            myRectangle.Location = new Point(10, 5);

            // Set the Size property of the rectangle with a width of 200
            // and a height of 50.
            myRectangle.Size = new Size(200,50);

            // Use the Inflate method to expand or shrink the rectangle by the specified 
            // width and height amounts. The new size is 160,150 (width shrunk by 40 and  
            // height increased by 100). Note: Width of the resulting rectangle is increased 
            // or shrunk by twice the specified width, because both the left and right sides  
            // of the rectangle are inflated or shrunk. Likewise, the height of the resulting 
            // rectangle is increased or shrunk by twice the specified height.
            myRectangle.Inflate(-20,50);

            return myRectangle.Size;

        }
        // </SnippetInflateExample2_csharp>

        // <SnippetInflateExample3_csharp>
        private Size inflateExample3()
        {
            // Initialize new rectangle.
            Rect myRectangle = new Rect();

            // The Location property specifies the coordinates of the upper left-hand 
            // corner of the rectangle. 
            myRectangle.Location = new Point(10, 5);

            // Set the Size property of the rectangle with a width of 200
            // and a height of 50.
            myRectangle.Size = new Size(200, 50);

            // Use the static Inflate method to return an expanded version of myRectangle1.   
            // The size of myRectangle2 is 240,110. Note: Width of the resulting rectangle is increased 
            // by twice the Width of the specified Size structure, because both the left and right 
            // sides of the rectangle are inflated. Likewise, the Height of the resulting 
            // rectangle is increased by twice the Height of the specified Size structure.
            Rect myRectangle2 = Rect.Inflate(myRectangle, new Size(20, 30));

            return myRectangle2.Size;

        }
        // </SnippetInflateExample3_csharp>

        // <SnippetInflateExample4_csharp>
        private Size inflateExample4()
        {
            // Initialize new rectangle.
            Rect myRectangle = new Rect();

            // The Location property specifies the coordinates of the upper left-hand 
            // corner of the rectangle. 
            myRectangle.Location = new Point(10, 5);

            // Set the Size property of the rectangle with a width of 200
            // and a height of 50.
            myRectangle.Size = new Size(200, 50);

            // Use the static Inflate method to return a version of myRectangle with a shrunk
            // width and expanded height. The size of myRectangle2 is 160,150. Note: Width of the resulting 
            // rectangle is increased or shrunk by twice the specified width, because both the
            // left and right sides of the rectangle are inflated or shrunk. Likewise, the height 
            // of the resulting rectangle is increased or shrunk by twice the specified height.
            Rect myRectangle2 = Rect.Inflate(myRectangle, -20, 50);

            return myRectangle2.Size;

        }
        // </SnippetInflateExample4_csharp>

        // <SnippetIntersectExample1_csharp>
        private Rect intersectExample1()
        {
            // Initialize new rectangle.
            Rect myRectangle = new Rect();

            // The Location property specifies the coordinates of the upper left-hand 
            // corner of the rectangle. 
            myRectangle.Location = new Point(10, 5);

            // Set the Size property of the rectangle with a width of 200
            // and a height of 50.
            myRectangle.Size = new Size(200, 50);

            // Create second rectangle to compare to the first.
            Rect myRectangle2 = new Rect();
            myRectangle2.Location = new Point(0, 0);
            myRectangle2.Size = new Size(200, 50);

            // Intersect method finds the intersection between the current rectangle and the 
            // specified rectangle, and stores the result as the current rectangle. If no 
            // intersection exists, the current rectangle becomes the Empty rectangle. 
            // myRectangle now has a size of 190,45 and location of 10,5. 
            myRectangle.Intersect(myRectangle2);

            // myRectangle has been changed into the intersection area between the old myRectangle
            // and myRectangle2 (new size of 190,45 and new location of 10,5).
            return myRectangle;

        }
        // </SnippetIntersectExample1_csharp>

        // <SnippetIntersectExample2_csharp>
        private Rect intersectExample2()
        {
            // Initialize new rectangle.
            Rect myRectangle = new Rect();

            // The Location property specifies the coordinates of the upper left-hand 
            // corner of the rectangle. 
            myRectangle.Location = new Point(10, 5);

            // Set the Size property of the rectangle with a width of 200
            // and a height of 50.
            myRectangle.Size = new Size(200, 50);

            // Create second rectangle to compare to the first.
            Rect myRectangle2 = new Rect();
            myRectangle2.Location = new Point(0, 0);
            myRectangle2.Size = new Size(200, 50);

            // Intersect method finds the intersection between the specified rectangles and 
            // returns the result as a Rect. If there is no intersection then the Empty Rect 
            // is returned. resultRectangle has a size of 190,45 and location of 10,5. 
            Rect resultRectangle = Rect.Intersect(myRectangle, myRectangle2);

            return resultRectangle;

        }
        // </SnippetIntersectExample2_csharp>

        // <SnippetIntersectsWithExample_csharp>
        private bool intersectsWithExample()
        {
            // Initialize new rectangle.
            Rect myRectangle = new Rect();

            // The Location property specifies the coordinates of the upper left-hand 
            // corner of the rectangle. 
            myRectangle.Location = new Point(10, 5);

            // Set the Size property of the rectangle with a width of 200
            // and a height of 50.
            myRectangle.Size = new Size(200, 50);

            // Create second rectangle to compare to the first.
            Rect myRectangle2 = new Rect();
            myRectangle2.Location = new Point(0, 0);
            myRectangle2.Size = new Size(200, 50);

            // IntersectsWith method indicates whether the specified rectangle intersects 
            // with this rectangle. doesIntersect returns true because the two rectangles
            // intersect. 
            bool doesIntersect = myRectangle.IntersectsWith(myRectangle2);

            // Returns true.
            return doesIntersect;

        }
        // </SnippetIntersectsWithExample_csharp>

        // <SnippetOffsetExample1_csharp>
        private Point offsetExample1()
        {
            // Initialize new rectangle.
            Rect myRectangle = new Rect();

            // The Location property specifies the coordinates of the upper left-hand 
            // corner of the rectangle. 
            myRectangle.Location = new Point(10, 5);

            // Set the Size property of the rectangle with a width of 200
            // and a height of 50.
            myRectangle.Size = new Size(200, 50);

            // Create a vector to use to offset the position of the rectangle.
            Vector vector1 = new Vector(20, 30);

            // The Offset method translates this rectangle by the specified vector.
            // myRectangle location changed from 10,5 to 30,35.
            myRectangle.Offset(vector1);

            // This rectangle's location changed from 10,5 to 30,35.
            return myRectangle.Location;

        }
        // </SnippetOffsetExample1_csharp>

        // <SnippetOffsetExample2_csharp>
        private Point offsetExample2()
        {
            // Initialize new rectangle.
            Rect myRectangle = new Rect();

            // The Location property specifies the coordinates of the upper left-hand 
            // corner of the rectangle. 
            myRectangle.Location = new Point(10, 5);

            // Set the Size property of the rectangle with a width of 200
            // and a height of 50.
            myRectangle.Size = new Size(200, 50);

            // The Offset method translates this rectangle by the specified horizontal and 
            // vertical amounts. 
            // myRectangle location changed from 10,5 to 30,35.
            myRectangle.Offset(20,30);

            // This rectangle's location changed from 10,5 to 30,35.
            return myRectangle.Location;

        }
        // </SnippetOffsetExample2_csharp>

        // <SnippetOffsetExample3_csharp>
        private Point offsetExample3()
        {
            // Initialize new rectangle.
            Rect myRectangle = new Rect();

            // The Location property specifies the coordinates of the upper left-hand 
            // corner of the rectangle. 
            myRectangle.Location = new Point(10, 5);

            // Set the Size property of the rectangle with a width of 200
            // and a height of 50.
            myRectangle.Size = new Size(200, 50);

            // Create a vector to use to offset the position of the rectangle.
            Vector vector1 = new Vector(20, 30);

            // The Offset method translates the specified rectangle by the specified amount 
            // and returns the resulting Rect. 
            // resultRect location changed from 10,5 to 30,35.
            Rect resultRect = Rect.Offset(myRectangle, vector1);

            // This rectangle's location changed from 10,5 to 30,35.
            return resultRect.Location;

        }
        // </SnippetOffsetExample3_csharp>

        // <SnippetOffsetExample4_csharp>
        private Point offsetExample4()
        {
            // Initialize new rectangle.
            Rect myRectangle = new Rect();

            // The Location property specifies the coordinates of the upper left-hand 
            // corner of the rectangle. 
            myRectangle.Location = new Point(10, 5);

            // Set the Size property of the rectangle with a width of 200
            // and a height of 50.
            myRectangle.Size = new Size(200, 50);

            // Create a vector to use to offset the position of the rectangle.
            Vector vector1 = new Vector(20, 30);

            // The Offset method translates the specified rectangle by the specified horizontal 
            // and vertical amounts and returns the resulting Rect. 
            // resultRect location changed from 10,5 to 30,35.
            Rect resultRect = Rect.Offset(myRectangle, 20, 30);

            // This rectangle's location changed from 10,5 to 30,35.
            return resultRect.Location;

        }
        // </SnippetOffsetExample4_csharp>

        // <SnippetOverloadedEqualityOperatorExample>
        private Boolean overloadedEqualityOperatorExample()
        {
            // Initialize new rectangle.
            Rect myRectangle = new Rect();

            // The Location property specifies the coordinates of the upper left-hand 
            // corner of the rectangle. 
            myRectangle.Location = new Point(10, 5);

            // Set the Size property of the rectangle with a width of 200
            // and a height of 50.
            myRectangle.Size = new Size(200, 50);

            // Create second rectangle to compare to the first.
            Rect myRectangle2 = new Rect();
            myRectangle2.Location = new Point(0, 0);
            myRectangle2.Size = new Size(200, 50);

            // Check if the two Rects are exactly equal using the overloaded equality operator.
            // areEqual is false because although the size of each rectangle is the same,
            // the locations are different.
            bool areEqual = (myRectangle == myRectangle2);

            // Returns false.
            return areEqual;

        }
        // </SnippetOverloadedEqualityOperatorExample>

        // <SnippetOverloadedInequalityOperatorExample>
        private Boolean overloadedInequalityOperatorExample()
        {
            // Initialize new rectangle.
            Rect myRectangle = new Rect();

            // The Location property specifies the coordinates of the upper left-hand 
            // corner of the rectangle. 
            myRectangle.Location = new Point(10, 5);

            // Set the Size property of the rectangle with a width of 200
            // and a height of 50.
            myRectangle.Size = new Size(200, 50);

            // Create second rectangle to compare to the first.
            Rect myRectangle2 = new Rect();
            myRectangle2.Location = new Point(0, 0);
            myRectangle2.Size = new Size(200, 50);

            // Check if the two Rects are not equal using the overloaded inequality operator.
            // notEqual is true because although the size of each rectangle is the same,
            // the locations are different.
            bool notEqual = (myRectangle != myRectangle2);

            // Returns true.
            return notEqual;

        }
        // </SnippetOverloadedInequalityOperatorExample>

        // <SnippetParseExample>
        private Rect parseExample()
        {

            // Converts a string representation of a Rect into a Rect structure
            // using the Parse static method.
            Rect resultRect = Rect.Parse("10,5, 200,50");

            return resultRect;

        }
        // </SnippetParseExample>

        // <SnippetScaleExample_csharp>
        private Size scaleExample()
        {
            // Initialize new rectangle.
            Rect myRectangle = new Rect();

            // The Location property specifies the coordinates of the upper left-hand 
            // corner of the rectangle. 
            myRectangle.Location = new Point(10, 5);

            // Set the Size property of the rectangle with a width of 200
            // and a height of 50.
            myRectangle.Size = new Size(200, 50);
          
            // The Scale method multiplies the size of the rectangle by the specified amount. 
            // myRectangle size changed from (200,50) to (4000,1500).
            myRectangle.Scale(20, 30);

            // Returns a size of 4000,1500.
            return myRectangle.Size;

        }
        // </SnippetScaleExample_csharp>

        // <SnippetToStringExample_csharp>
        private string toStringExample()
        {
            // Initialize new rectangle.
            Rect myRectangle = new Rect();

            // The Location property specifies the coordinates of the upper left-hand 
            // corner of the rectangle. 
            myRectangle.Location = new Point(10, 5);

            // Set the Size property of the rectangle with a width of 200
            // and a height of 50.
            myRectangle.Size = new Size(200, 50);

            // Get a string representation of a Rect structure.
            // rectString is equal to "10,5,200,50"	.
            string rectString = myRectangle.ToString();

            return rectString;

        }
        // </SnippetToStringExample_csharp>

        // <SnippetUnionExample1_csharp>
        private Rect unionExample1()
        {
            // Initialize new rectangle.
            Rect myRectangle = new Rect();

            // The Location property specifies the coordinates of the upper left-hand 
            // corner of the rectangle. 
            myRectangle.Location = new Point(10, 5);

            // Set the Size property of the rectangle with a width of 200
            // and a height of 50.
            myRectangle.Size = new Size(200, 50);

            // The Union method expands the current rectangle exactly enough to contain 
            // the specified point. myRectangle expands to a location of 0,0 and a size
            // of 210,55.
            myRectangle.Union(new Point(0,0));

            // Returns 0,0,210,55
            return myRectangle;

        }
        // </SnippetUnionExample1_csharp>

        // <SnippetUnionExample2_csharp>
        private Rect unionExample2()
        {
            // Initialize new rectangle.
            Rect myRectangle = new Rect();

            // The Location property specifies the coordinates of the upper left-hand 
            // corner of the rectangle. 
            myRectangle.Location = new Point(10, 5);

            // Set the Size property of the rectangle with a width of 200
            // and a height of 50.
            myRectangle.Size = new Size(200, 50);

            // Create second rectangle.
            Rect myRectangle2 = new Rect();
            myRectangle2.Location = new Point(0, 0);
            myRectangle2.Size = new Size(200, 50);

            // The Union method expands the current rectangle exactly enough to contain 
            // the specified rectangle. myRectangle expands to a location of 0,0 and a size
            // of 210,55.
            myRectangle.Union(myRectangle2);

            // Returns 0,0,210,55
            return myRectangle;

        }
        // </SnippetUnionExample2_csharp>

        // <SnippetUnionExample3_csharp>
        private Rect unionExample3()
        {
            // Initialize new rectangle.
            Rect myRectangle = new Rect();

            // The Location property specifies the coordinates of the upper left-hand 
            // corner of the rectangle. 
            myRectangle.Location = new Point(10, 5);

            // Set the Size property of the rectangle with a width of 200
            // and a height of 50.
            myRectangle.Size = new Size(200, 50);

            // Create second rectangle.
            Rect myRectangle2 = new Rect();
            myRectangle2.Location = new Point(0, 0);
            myRectangle2.Size = new Size(200, 50);

            // The Union method expands the current rectangle exactly enough to contain 
            // the specified rectangle and the specified Point. In this example, returnRect 
            // expands to a location of 0,0 and a size of 250,60.
            Rect returnRect = Rect.Union(myRectangle2, new Point(250,60));

            // Returns 0,0,250,60
            return returnRect;

        }
        // </SnippetUnionExample3_csharp>

        // <SnippetUnionExample4_csharp>
        private Rect unionExample4()
        {
            // Initialize new rectangle.
            Rect myRectangle = new Rect();

            // The Location property specifies the coordinates of the upper left-hand 
            // corner of the rectangle. 
            myRectangle.Location = new Point(10, 5);

            // Set the Size property of the rectangle with a width of 200
            // and a height of 50.
            myRectangle.Size = new Size(200, 50);

            // Create second rectangle.
            Rect myRectangle2 = new Rect();
            myRectangle2.Location = new Point(0, 0);
            myRectangle2.Size = new Size(200, 50);

            // Create a third rectangle.
            Rect myRectangle3 = new Rect();
            myRectangle3.Location = new Point(210, 60);
            myRectangle3.Size = new Size(50, 50);

            // The Union method expands the current rectangle exactly enough to contain 
            // the two specified rectangles. In this example, returnRect expands to 
            // a location of 0,0 and a size of 260,110.
            Rect returnRect = Rect.Union(myRectangle2, myRectangle3);

            // Returns 0,0,260,110
            return returnRect;

        }
        // </SnippetUnionExample4_csharp>

        // <SnippetTransformExample1_csharp>
        private Rect transformExample1()
        {
            // Initialize new rectangle.
            Rect myRectangle = new Rect();

            // Set the Size property of the rectangle with a width of 200
            // and a height of 60.
            myRectangle.Size = new Size(200, 60);

            // Creating a Matrix structure.
            Matrix myMatrix = new Matrix(0, 1, 1, 0, 20, 2);

            // The Transform method transforms this rectangle using the specified matrix.  
            // myRectangle location changed from 0,0 to 20, 2 and the size changed from
            // 200,60 to 60,200.
            myRectangle.Transform(myMatrix);

            return myRectangle;

        }
        // </SnippetTransformExample1_csharp>

        // <SnippetTransformExample2_csharp>
        private Rect transformExample2()
        {
            // Initialize new rectangle.
            Rect myRectangle = new Rect();

            // Set the Size property of the rectangle with a width of 200
            // and a height of 60.
            myRectangle.Size = new Size(200, 60);

            // Creating a Matrix structure.
            Matrix myMatrix = new Matrix(0, 1, 1, 0, 20, 2);

            // The Transform method Transforms the specified rectangle using the specified matrix 
            // and returns the results.  
            // resultRect is an alterned version of myRectangle with a location of 20,2 rather
            // then 0,0 and a size of 60,200 rather then 200,60.
            Rect resultRect = Rect.Transform(myRectangle,myMatrix);

            return resultRect;

        }
        // </SnippetTransformExample2_csharp>
    

    }

}

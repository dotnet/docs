using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;


namespace SampleApp
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
//<SnippetFEParentProperty>
        private void OnUIReady(object sender, System.EventArgs e)
        {
            LinePane.Width = ((StackPanel)LinePane.Parent).ActualWidth;
            LinePane.Height = ((StackPanel)LinePane.Parent).ActualHeight;
            DesignerPane.MouseLeave += new System.Windows.Input.MouseEventHandler(DesignerPane_MouseLeave);
            this.SizeChanged += new SizeChangedEventHandler(Window1_SizeChanged);
        }
//</SnippetFEParentProperty>


        void Window1_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            XAMLPane.BeginAnimation(Canvas.TopProperty, null);
            if (IsShow)
            {
                XAMLPane.SetValue(Canvas.TopProperty, e.NewSize.Height - 70);
            }
            else
            {
                XAMLPane.SetValue(Canvas.TopProperty, e.NewSize.Height);
            }
            XAMLPane.Width = e.NewSize.Width - 205;
        }


        void OnShowHideXAML(object sender, RoutedEventArgs e)
        {
            string xamlstring = System.Windows.Markup.XamlWriter.Save(DrawingPane);
            ((TextBox)XAMLPane.Children[0]).Text = xamlstring;

            if (!IsShow)
            {
                IsShow = !IsShow;
                XAMLPane.Width = this.ActualWidth - 205;
                XAMLPane.Height = 50;
                double yLocation = DesignerPane.ActualHeight;
                XAMLPane.SetValue(Canvas.LeftProperty, DesignerPane.GetValue(Canvas.LeftProperty));
                XAMLPane.SetValue(Canvas.TopProperty, yLocation );
                ((Label)((Button)sender).Content).Content = "Hide XAML";

                //Start animation
                DoubleAnimation db = new DoubleAnimation();
                db.Duration = TimeSpan.FromMilliseconds(500);
                db.FillBehavior = FillBehavior.HoldEnd;
                db.To = yLocation - 50;

                XAMLPane.BeginAnimation(Canvas.TopProperty, db);
                
            }
            else
            {
                IsShow = !IsShow;
                ((Label)((Button)sender).Content).Content = "Show XAML";

                DoubleAnimation dbShrink = new DoubleAnimation();
                dbShrink.Duration = TimeSpan.FromMilliseconds(500);
                dbShrink.FillBehavior = FillBehavior.HoldEnd;
                dbShrink.To = DesignerPane.ActualHeight;
                dbShrink.From = DesignerPane.ActualHeight - 50;

                XAMLPane.BeginAnimation(Canvas.TopProperty, dbShrink);

            }

        }

        void OnGeometrySelectionChange(object sender, SelectionChangedEventArgs e)
        {
          ComboBox box = sender as ComboBox;
   
          if (box.Name != "GeometryTypeCB")
            return;

          if (InitialSelection)
          {
            InitialSelection = !InitialSelection;
          }
          else
          {
            GeometryPaneChange(((ComboBoxItem)box.SelectedItem).Content, true);
          }
    
        }

        // ---------------------------------------------------------------------------------
        #region private action functions
        private void GeometryPaneChange(object GeometryName, bool AllowInsert)
        {
            foreach (Canvas c in ControlPointPane.Children)
            {
                if (string.Compare(c.Name, (string)GeometryName + "Pane", false, System.Globalization.CultureInfo.InvariantCulture) == 0)
                {
                    c.Width = ((StackPanel)c.Parent).ActualWidth;
                    c.Height = ((StackPanel)c.Parent).ActualHeight;
                    if (AllowInsert)
                    {
                        foreach (object b in c.Children)
                        {
                            if (b is TextBox)
                            {
                                ((TextBox)b).Text = "";
                                continue;
                            }

                            if (b is Button && ((Button)b).Content is string && ((String)((Button)b).Content == "Insert" || (String)((Button)b).Content == "Update"))
                            {
                                ((Button)b).IsEnabled = true;
                                ((Button)b).Content = "Insert";
                                IsInsert = true;
                            }
                        }
                    }
                    else
                    {
                        foreach (object b in c.Children)
                        {
                           if (b is Button && ((Button)b).Content is string && (String)((Button)b).Content == "Insert")
                           {
                                ((Button)b).IsEnabled = false;
                           }
                        }
                    }
                }
                else
                {
                    c.Width = 0;
                    c.Height = 0;
                }
            }
        }


        //If mouse leaves the DesignerPane, hide all of the control points
        void DesignerPane_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            foreach (object o in DesignerPane.Children)
            {
                if (o is Ellipse)
                {
                    ((Ellipse)o).Visibility = Visibility.Hidden;
                }
            }
        }


        void path_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            string pathID = ((Path)sender).Name;

            //Search and set visibility on all of the related control points
            foreach (object o in DesignerPane.Children)
            {
                //Search for the control point that contains the element's ID
                //e.g Line1_StartPoint for Line1 element
                if (o is Ellipse)
                {
                    
                    if (
                        ((Ellipse)o).Name.Contains(pathID)
                        
                        ) {
                        //show that control point
                        ((Ellipse)o).Visibility = Visibility.Visible;
                    
                    }
                    else 
                    {
                    
                        //hide all other control points
                        ((Ellipse)o).Visibility = Visibility.Hidden;
                    }

                }
            }
        }


        private void OnInsertGeometry(object sender, RoutedEventArgs e)
        {

            try
            {
                if (IsInsert)
                {
                    Path path = new Path();
                    path.Stroke = Brushes.Black;
                    path.StrokeThickness = 2;

                    GeometryBase gb = GeometryFactory((FrameworkElement)((Button)sender).Parent);


                    switch (gb.geometryType)
                    {
                        case "Line":
                            path.Name = "Line" + LineCount;
                            AddControlPoints(gb.controlPoints, "Line");
                            LineCount++;
                            break;
                        case "Rectangle":
                            path.Name = "Rectangle" + RectangleCount;
                            AddControlPoints(gb.controlPoints, "Rectangle");
                            RectangleCount++;                            
                            break;
                        case "Ellipse":
                            path.Name = "Ellipse" + ElliipseCount;
                            AddControlPoints(gb.controlPoints, "Ellipse");
                            ElliipseCount++;
                            break;
                        case "Arc":
                            path.Name = "Arc" + ArcCount;
                            AddControlPoints(gb.controlPoints, "Arc");
                            ArcCount++;
                            break;
                        case "Bezier":
                            path.Name = "Bezier" + BezierCount;
                            AddControlPoints(gb.controlPoints, "Bezier");
                            BezierCount++;
                            break;
                        default:
                            throw new System.ApplicationException("Error:  Incorrect Geometry type");
                    }

                    path.Data = gb.CreateGeometry();
                    path.MouseEnter += new System.Windows.Input.MouseEventHandler(path_MouseEnter);
                    currentElement = path;
                    DrawingPane.Children.Add(path);
                    ((Button)sender).Content = "Update";
                    IsInsert = !IsInsert;
                }
                else
                {
                    GeometryBase gbUpdate = GeometryFactory((FrameworkElement)((Button)sender).Parent);
                    currentElement.Data = gbUpdate.CreateGeometry();
                    UpdateControlPoints(gbUpdate.controlPoints);
                }
            }
            catch (ApplicationException argExcept)
            {
                MessageBox.Show(argExcept.Message);
            }

        }
        #endregion

        // ---------------------------------------------------------------------------------
        #region Drag and Move
        //Special variable for Drag and move actions
        private bool IsMoving = false;
        private Point movingPreviousLocation;



        void Ellipse_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Ellipse el = (Ellipse)sender;
            el.Cursor = System.Windows.Input.Cursors.Hand;
            IsMoving = true;
            movingPreviousLocation = e.GetPosition(DrawingPane);
        }

        void Ellipse_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Ellipse el = (Ellipse)sender;
            el.Cursor = System.Windows.Input.Cursors.Arrow;
            IsMoving = false;
        }


        void Ellipse_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Ellipse el = (Ellipse)sender;
            Point movingEndLocation;
            if (IsMoving)
            {
                movingEndLocation = e.GetPosition(DrawingPane);
                
                
                Canvas.SetLeft(el, movingEndLocation.X - el.Width / 2);
                Canvas.SetTop(el, movingEndLocation.Y - el.Height / 2);
                
                UpdateGeometries(movingEndLocation, el.Name);
                movingPreviousLocation = movingEndLocation;
            }
        }
        #endregion
        // ---------------------------------------------------------------------------------
        #region private helper functions
        private void UpdateControlPoints(ArrayList controlPoints)
        {
            string GeometryType = GetGeometryTypeInID(currentElement.Name);

            switch (GeometryType)
            {
                case "Line":
                    UpdateLineGeometryControlPoints(controlPoints);
                    break;
                case "Ellipse":
                    UpdateEllipseGeometryControlPoints(controlPoints);
                    break;
                case "Rectangle":
                    UpdateRectangleGeometryControlPoints(controlPoints);
                    break;
                case "Arc":
                    UpdateArcGeometryControlPoints(controlPoints);
                    break;
                case "Bezier":
                    UpdateBezierGeometryControlPoints(controlPoints);
                    break;
                default:
                    throw new System.ApplicationException("Error: incorrect Element name");
            }
        }


        private void UpdateLineGeometryControlPoints(ArrayList controlPoints)
        {
            if (controlPoints.Count != 2)
                throw new System.ApplicationException("Error:  incorrect # of control points for LineGeometry");

            for (int i = 0; i < controlPoints.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        Ellipse eStartPoint = LogicalTreeHelper.FindLogicalNode(DesignerPane, currentElement.Name + "_StartPoint") as Ellipse;
                        Canvas.SetLeft(eStartPoint,  ((Point)controlPoints[i]).X - eStartPoint.Width / 2);
                        Canvas.SetTop(eStartPoint, ((Point)controlPoints[i]).Y - eStartPoint.Height / 2);
                        break;
                    case 1:
                        Ellipse eEndPoint = LogicalTreeHelper.FindLogicalNode(DesignerPane, currentElement.Name + "_EndPoint") as Ellipse;
                        Canvas.SetLeft(eEndPoint, ((Point)controlPoints[i]).X - eEndPoint.Width / 2);
                        Canvas.SetTop(eEndPoint, ((Point)controlPoints[i]).Y - eEndPoint.Height /2 );
                        break;
                    default:
                        throw new System.ApplicationException("Error: incorrect # of control points in LineG");
                }
            }
        }

        private void UpdateEllipseGeometryControlPoints(ArrayList controlPoints)
        {
            if (controlPoints.Count != 5)
            {
                throw new System.ApplicationException("Error:  incorrect # of control points for EllipseGeometry");
            }
            for (int i = 0; i < controlPoints.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        Ellipse eCenter = LogicalTreeHelper.FindLogicalNode(DesignerPane, currentElement.Name + "_Center") as Ellipse;                        
                        Canvas.SetLeft(eCenter, ((Point)controlPoints[i]).X - eCenter.Width / 2);
                        Canvas.SetTop(eCenter, ((Point)controlPoints[i]).Y - eCenter.Height / 2);
                        break;
                    case 1:
                        Ellipse eTopLeft = LogicalTreeHelper.FindLogicalNode(DesignerPane, currentElement.Name + "_TopLeft") as Ellipse;
                        Canvas.SetLeft(eTopLeft, ((Point)controlPoints[i]).X - eTopLeft.Width / 2);
                        Canvas.SetTop(eTopLeft, ((Point)controlPoints[i]).Y - eTopLeft.Height / 2);
                        break;
                    case 2:
                        Ellipse eTopMiddle = LogicalTreeHelper.FindLogicalNode(DesignerPane, currentElement.Name + "_TopMiddle") as Ellipse;
                        Canvas.SetLeft(eTopMiddle, ((Point)controlPoints[i]).X - eTopMiddle.Width / 2);
                        Canvas.SetTop(eTopMiddle, ((Point)controlPoints[i]).Y - eTopMiddle.Height / 2);
                        break;
                    case 3:
                        Ellipse eTopRight = LogicalTreeHelper.FindLogicalNode(DesignerPane, currentElement.Name + "_TopRight") as Ellipse;
                        Canvas.SetLeft(eTopRight, ((Point)controlPoints[i]).X - eTopRight.Width / 2);
                        Canvas.SetTop(eTopRight, ((Point)controlPoints[i]).Y - eTopRight.Height / 2);
                        break;
                    case 4:
                        Ellipse eBottomMiddle = LogicalTreeHelper.FindLogicalNode(DesignerPane, currentElement.Name + "_BottomMiddle") as Ellipse;
                        Canvas.SetLeft(eBottomMiddle, ((Point)controlPoints[i]).X - eBottomMiddle.Width / 2);
                        Canvas.SetTop(eBottomMiddle, ((Point)controlPoints[i]).Y - eBottomMiddle.Height / 2);
                        break;
                    default:
                        throw new System.ApplicationException("Error: incorrect # of control points in EllipseG");
                }

            }
        }

        private void UpdateRectangleGeometryControlPoints(ArrayList controlPoints)
        {
            if (controlPoints.Count != 5 && controlPoints.Count != 4)
            {
                throw new System.ApplicationException("Error:  incorrect # of control points for RectangleGeometry");
            }
            for (int i = 0; i < controlPoints.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        Ellipse eTopLeft = LogicalTreeHelper.FindLogicalNode(DesignerPane, currentElement.Name + "_TopLeft") as Ellipse;
                        Canvas.SetLeft(eTopLeft, ((Point)controlPoints[i]).X - eTopLeft.Width / 2);
                        Canvas.SetTop(eTopLeft, ((Point)controlPoints[i]).Y - eTopLeft.Height / 2);
                        break;
                    case 1:
                        Ellipse eTopRight = LogicalTreeHelper.FindLogicalNode(DesignerPane, currentElement.Name + "_TopRight") as Ellipse;
                        Canvas.SetLeft(eTopRight, ((Point)controlPoints[i]).X - eTopRight.Width / 2);
                        Canvas.SetTop(eTopRight, ((Point)controlPoints[i]).Y - eTopRight.Height / 2);
                        break;
                    case 2:
                        Ellipse eBottomLeft = LogicalTreeHelper.FindLogicalNode(DesignerPane, currentElement.Name + "_BottomLeft") as Ellipse;
                        Canvas.SetLeft(eBottomLeft, ((Point)controlPoints[i]).X - eBottomLeft.Width / 2);
                        Canvas.SetTop(eBottomLeft, ((Point)controlPoints[i]).Y - eBottomLeft.Height / 2);
                        break;
                    case 3:
                        Ellipse eBottomRight = LogicalTreeHelper.FindLogicalNode(DesignerPane, currentElement.Name + "_BottomRight") as Ellipse;
                        Canvas.SetLeft(eBottomRight, ((Point)controlPoints[i]).X - eBottomRight.Width / 2 );
                        Canvas.SetTop(eBottomRight, ((Point)controlPoints[i]).Y - eBottomRight.Height / 2);
                        break;
                    case 4:
                        Ellipse eCorner = LogicalTreeHelper.FindLogicalNode(DesignerPane, currentElement.Name + "_Corner") as Ellipse;
                        Canvas.SetLeft(eCorner, ((Point)controlPoints[i]).X - eCorner.Width / 2);
                        Canvas.SetTop(eCorner, ((Point)controlPoints[i]).Y - eCorner.Height / 2);
                        break;
                    default:
                        throw new System.ApplicationException("Error: incorrect # of control points in RectangleG");
                }
            }
        }

        private void UpdateArcGeometryControlPoints(ArrayList controlPoints)
        {
            if (controlPoints.Count != 2)
            {
                throw new System.ApplicationException("Error:  incorrect # of control points for Arc Geometry");
            }
            for (int i = 0; i < controlPoints.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        Ellipse eStartPoint = LogicalTreeHelper.FindLogicalNode(DesignerPane, currentElement.Name + "_StartPoint") as Ellipse;
                        Canvas.SetLeft(eStartPoint, ((Point)controlPoints[i]).X - eStartPoint.Width / 2 );
                        Canvas.SetTop(eStartPoint, ((Point)controlPoints[i]).Y - eStartPoint.Height / 2);
                        break;
                    case 1:
                        Ellipse ePoint1 = LogicalTreeHelper.FindLogicalNode(DesignerPane, currentElement.Name + "_Point") as Ellipse;
                        Canvas.SetLeft(ePoint1, ((Point)controlPoints[i]).X - ePoint1.Width / 2);
                        Canvas.SetTop(ePoint1, ((Point)controlPoints[i]).Y - ePoint1.Height / 2);
                        break;
                    default:
                        throw new System.ApplicationException("Error: Incorrect # of control points in ArcG");
                }
            }
        }

        private void UpdateBezierGeometryControlPoints(ArrayList controlPoints)
        {
            if (controlPoints.Count != 4)
            {
                throw new System.ApplicationException("Error:  incorrect # of control points for Bezier Geometry");
            }
            for (int i = 0; i < controlPoints.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        Ellipse eStartPoint = LogicalTreeHelper.FindLogicalNode(DesignerPane, currentElement.Name + "_StartPoint") as Ellipse;
                        Canvas.SetLeft(eStartPoint, ((Point)controlPoints[i]).X - eStartPoint.Width / 2);
                        Canvas.SetTop(eStartPoint, ((Point)controlPoints[i]).Y - eStartPoint.Height / 2);
                        break;
                    case 1:
                        Ellipse ePoint1 = LogicalTreeHelper.FindLogicalNode(DesignerPane, currentElement.Name + "_Point1") as Ellipse;
                        Canvas.SetLeft(ePoint1, ((Point)controlPoints[i]).X - ePoint1.Width / 2);
                        Canvas.SetTop(ePoint1, ((Point)controlPoints[i]).Y - ePoint1.Height / 2);
                        break;
                    case 2:
                        Ellipse ePoint2 = LogicalTreeHelper.FindLogicalNode(DesignerPane, currentElement.Name + "_Point2") as Ellipse;
                        Canvas.SetLeft(ePoint2, ((Point)controlPoints[i]).X - ePoint2.Width / 2);
                        Canvas.SetTop(ePoint2, ((Point)controlPoints[i]).Y - ePoint2.Height / 2);
                        break;
                    case 3:
                        Ellipse ePoint3 = LogicalTreeHelper.FindLogicalNode(DesignerPane, currentElement.Name + "_Point3") as Ellipse;
                        Canvas.SetLeft(ePoint3, ((Point)controlPoints[i]).X - ePoint3.Width / 2);
                        Canvas.SetTop(ePoint3, ((Point)controlPoints[i]).Y - ePoint3.Height / 2);
                        break;
                    default:
                        throw new ApplicationException("Error: incorrect # of control points in BezierG");
                }
            }
        }

        private void UpdateGeometries(Point movingEndLocation, string ID)
        {
            string GeometryType = GetGeometryTypeInID(ID);

            //Switch the controlpoint pane to the right panel
            GeometryPaneChange(GeometryType, false);

            switch (GeometryType)
            {
                case "Line":
                    UpdateLineGeometry(movingEndLocation, ID);
                    break;
                case "Ellipse":
                    UpdateEllipseGeometry(movingEndLocation, ID);
                    break;
                case "Rectangle":
                    UpdateRectangleGeometry(movingEndLocation, ID);
                    break;
                case "Bezier":
                    UpdateBezierGeometry(movingEndLocation, ID);
                    break;
                case "Arc":
                    UpdateArcGeometry(movingEndLocation, ID);
                    break;
                default:
                    throw new System.ApplicationException("Error: incorrect GeometryType in UpdateGeometries()");
            }
        }

        private object SearchUpdatedElement(string p)
        {
            foreach (object o in DrawingPane.Children)
            {
                if (o is Path && ((Path)o).Name == p)
                {
                    return o;
                }
            }
            return null;
        }

        private void UpdateArcGeometry(Point movingEndLocation, string ID)
        {
            string[] s = ID.Split('_');
            string controlPointType = GetContronPointTypeInID(ID);
            Path p = SearchUpdatedElement(s[0]) as Path;
            if (p == null)
            {
                throw new System.ApplicationException("Error: incorrect geometry ID");
            }
            currentElement = p;
            PathGeometry pg = p.Data as PathGeometry;
            PathFigure pf = pg.Figures[0];

            switch (controlPointType)
            {
                case "StartPoint":
                    pf.StartPoint = movingEndLocation;
                    ArcStartPoint.Text = movingEndLocation.X + " " + movingEndLocation.Y;
                    break;
                case "Point":
                    ((ArcSegment)pf.Segments[0]).Point = movingEndLocation;
                    ArcPoint.Text = movingEndLocation.X + " " + movingEndLocation.Y;
                    break;
                default:
                    throw new System.ApplicationException("Error: incorrect control point type");
            }

            p.Data = pg;
            string xamlstring = System.Windows.Markup.XamlWriter.Save(DrawingPane);
            ((TextBox)XAMLPane.Children[0]).Text = xamlstring;
        }

        private void UpdateLineGeometry(Point movingEndLocation, string ID)
        {
            string[] s = ID.Split('_');
            string controlPointType = GetContronPointTypeInID(ID);
            Path p = SearchUpdatedElement(s[0]) as Path;
            if (p == null)
            {
                throw new System.ApplicationException("Error: incorrect geometry ID");
            }
            currentElement = p;
            LineGeometry lg = p.Data as LineGeometry;

            switch (controlPointType)
            {
                case "StartPoint":
                    LineStartPoint.Text = movingEndLocation.X + " " + movingEndLocation.Y;
                    lg.StartPoint = movingEndLocation;
                    
                    break;
                case "EndPoint":
                    LineEndPoint.Text = movingEndLocation.X + " " + movingEndLocation.Y;
                    lg.EndPoint = movingEndLocation;
                    
                    break;
                default:
                    throw new System.ApplicationException("Error: Incorrect controlpoint type, '" + controlPointType + "' in UpdateLineGeometry()");
            }
            string xamlstring = System.Windows.Markup.XamlWriter.Save(DrawingPane);
            ((TextBox)XAMLPane.Children[0]).Text = xamlstring;
        }

        private void UpdateEllipseGeometry(Point movingEndLocation, string ID)
        {
        
            
            string[] s = ID.Split('_');
            string controlPointType = GetContronPointTypeInID(ID);
            Path p = SearchUpdatedElement(s[0]) as Path;
            if (p == null)
            {
                throw new System.ApplicationException("Error: incorrect geometry ID");
            }
            currentElement = p;
            EllipseGeometry eg = p.Data.Clone() as EllipseGeometry;
            double diffX = movingEndLocation.X - eg.Center.X;
            double diffY = movingEndLocation.Y - eg.Center.Y;

            double radians, angle;
            radians = Math.Atan2(diffY, diffX);
            angle = radians * (180 / Math.PI);

            switch (controlPointType)
            {
                case "Center":
                    eg.Center = movingEndLocation;

                    //Update the center in the RotateTransform when the ellipsegeometry's center is moved
                    if (eg.Transform != null && eg.Transform is RotateTransform)
                    {
                        RotateTransform rtWithNewCenter = eg.Transform as RotateTransform;
                        rtWithNewCenter.CenterX = eg.Center.X;
                        rtWithNewCenter.CenterY = eg.Center.Y;
                    }
                    foreach (object o in DesignerPane.Children)
                    {
                        if (o is Ellipse && ((Ellipse)o).Name.Contains(s[0]) && ((Ellipse)o).Name != s[0])
                        {
                            Canvas.SetLeft(((Ellipse)o), Canvas.GetLeft(((Ellipse)o)) + diffX);
                            Canvas.SetTop(((Ellipse)o), Canvas.GetTop(((Ellipse)o)) + diffY);
                        }
                    }
                    p.Data = eg;

                    EllipseCenterPoint.Text = eg.Center.X + " " + eg.Center.Y;
                    break;
                    
                case "TopLeft":
                    Vector v0 = new Vector(-eg.RadiusX , 0);
                    Vector v1 = new Vector(diffX, diffY);

                    RotateTransform rt_TopLeft = new RotateTransform(angle + 180, eg.Center.X, eg.Center.Y);
                    eg.Transform = rt_TopLeft;
                    eg.RadiusX = v1.Length;
                    EllipseRadiusX.Text = v1.Length.ToString();
                    p.Data = eg;

                    //Update the TopRight control point for this EllipseGeometry
                    Ellipse e_TopRight = (Ellipse)LogicalTreeHelper.FindLogicalNode(DesignerPane, s[0] + "_TopRight");                                        
                    Canvas.SetLeft(e_TopRight, (eg.Center.X - diffX) - e_TopRight.Width / 2);                    
                    Canvas.SetTop(e_TopRight, (eg.Center.Y - diffY) - e_TopRight.Height / 2 );

                    Ellipse e_TopMiddle = (Ellipse)LogicalTreeHelper.FindLogicalNode(DesignerPane, s[0] + "_TopMiddle");                    
                    Canvas.SetLeft(e_TopMiddle, (eg.Center.X - diffY * eg.RadiusY / v1.Length) - e_TopMiddle.Width / 2);
                    Canvas.SetTop(e_TopMiddle, eg.Center.Y + diffX * eg.RadiusY / v1.Length -  e_TopMiddle.Height / 2 );

                    Ellipse e_BottomMiddle = (Ellipse)LogicalTreeHelper.FindLogicalNode(DesignerPane, s[0] + "_BottomMiddle");
                    Canvas.SetLeft(e_BottomMiddle,  (eg.Center.X + diffY * eg.RadiusY / v1.Length) - e_BottomMiddle.Width / 2);
                    Canvas.SetTop(e_BottomMiddle, (eg.Center.Y - diffX * eg.RadiusY / v1.Length) - e_BottomMiddle.Height / 2);

                    break;
                case "TopMiddle":
                    Vector v1_TopMiddle = new Vector(diffX, diffY);
                    RotateTransform rt_TopMiddle = new RotateTransform(angle + 90, eg.Center.X, eg.Center.Y);
                    eg.Transform = rt_TopMiddle;
                    eg.RadiusY = v1_TopMiddle.Length;
                    EllipseRadiusY.Text = v1_TopMiddle.Length.ToString();
                    p.Data = eg;

                    Ellipse e_TopLeft2 = (Ellipse)LogicalTreeHelper.FindLogicalNode(DesignerPane, s[0] + "_TopLeft");
                    Canvas.SetLeft(e_TopLeft2, (eg.Center.X + diffY * eg.RadiusX / v1_TopMiddle.Length) - e_TopLeft2.Width / 2 );
                    Canvas.SetTop(e_TopLeft2, (eg.Center.Y - diffX * eg.RadiusX / v1_TopMiddle.Length) - e_TopLeft2.Height /2 );

                    Ellipse e_TopRight2 = (Ellipse)LogicalTreeHelper.FindLogicalNode(DesignerPane, s[0] + "_TopRight");
                    Canvas.SetLeft(e_TopRight2, (eg.Center.X - diffY * eg.RadiusX / v1_TopMiddle.Length) - e_TopRight2.Width / 2);
                    Canvas.SetTop(e_TopRight2, (eg.Center.Y + diffX * eg.RadiusX / v1_TopMiddle.Length) - e_TopRight2.Height / 2);

                    Ellipse e_BottomMiddle2 = (Ellipse)LogicalTreeHelper.FindLogicalNode(DesignerPane, s[0] + "_BottomMiddle");
                    Canvas.SetLeft(e_BottomMiddle2, (eg.Center.X - diffX) - e_BottomMiddle2.Width /2);
                    Canvas.SetTop(e_BottomMiddle2, (eg.Center.Y - diffY) - e_BottomMiddle2.Height / 2);
                    break;

                case "TopRight":
                    Vector v1_TopRight = new Vector(diffX, diffY);
                    RotateTransform rt_TopRight = new RotateTransform(angle, eg.Center.X, eg.Center.Y);
                    eg.Transform = rt_TopRight;
                    eg.RadiusX = v1_TopRight.Length;
                    EllipseRadiusX.Text = v1_TopRight.Length.ToString();
                    p.Data = eg;

                    Ellipse e_TopLeft3 = (Ellipse)LogicalTreeHelper.FindLogicalNode(DesignerPane, s[0] + "_TopLeft");
                    Canvas.SetLeft(e_TopLeft3, (eg.Center.X - diffX) - e_TopLeft3.Width / 2 );
                    Canvas.SetTop(e_TopLeft3, (eg.Center.Y - diffY) - e_TopLeft3.Height / 2 );

                    Ellipse e_TopMiddle3 = (Ellipse)LogicalTreeHelper.FindLogicalNode(DesignerPane, s[0] + "_TopMiddle");
                    Canvas.SetLeft(e_TopMiddle3, (eg.Center.X + diffY * eg.RadiusY / v1_TopRight.Length) - e_TopMiddle3.Width / 2);
                    Canvas.SetTop(e_TopMiddle3, (eg.Center.Y - diffX * eg.RadiusY / v1_TopRight.Length) - e_TopMiddle3.Height / 2 );

                    Ellipse e_BottomMiddle3 = (Ellipse)LogicalTreeHelper.FindLogicalNode(DesignerPane, s[0] + "_BottomMiddle");
                    Canvas.SetLeft(e_BottomMiddle3, (eg.Center.X - diffY * eg.RadiusY / v1_TopRight.Length) - e_BottomMiddle3.Width / 2);
                    Canvas.SetTop(e_BottomMiddle3, (eg.Center.Y + diffX * eg.RadiusY / v1_TopRight.Length) - e_BottomMiddle3.Height / 2);
                    break;
                    
                case "BottomMiddle":
                    Vector v1_BottomMiddle = new Vector(diffX, diffY);
                    RotateTransform rt_BottomMiddle = new RotateTransform(angle - 90, eg.Center.X, eg.Center.Y);
                    eg.Transform = rt_BottomMiddle;
                    eg.RadiusY = v1_BottomMiddle.Length;
                    EllipseRadiusY.Text = v1_BottomMiddle.Length.ToString();
                    p.Data = eg;

                    Ellipse e_TopLeft4 = (Ellipse)LogicalTreeHelper.FindLogicalNode(DesignerPane, s[0] + "_TopLeft");
                    Canvas.SetLeft(e_TopLeft4, (eg.Center.X - diffY * eg.RadiusX / v1_BottomMiddle.Length) - e_TopLeft4.Width / 2);
                    Canvas.SetTop(e_TopLeft4, (eg.Center.Y + diffX * eg.RadiusX / v1_BottomMiddle.Length) - e_TopLeft4.Height / 2);

                    Ellipse e_TopRight4 = (Ellipse)LogicalTreeHelper.FindLogicalNode(DesignerPane, s[0] + "_TopRight");
                    Canvas.SetLeft(e_TopRight4, (eg.Center.X + diffY * eg.RadiusX / v1_BottomMiddle.Length) - e_TopRight4.Width / 2);
                    Canvas.SetTop(e_TopRight4, (eg.Center.Y - diffX * eg.RadiusX / v1_BottomMiddle.Length) - e_TopRight4.Height / 2);

                    Ellipse e_TopMiddle4 = (Ellipse)LogicalTreeHelper.FindLogicalNode(DesignerPane, s[0] + "_TopMiddle");
                    Canvas.SetLeft(e_TopMiddle4, (eg.Center.X - diffX) - e_TopMiddle4.Width / 2);
                    Canvas.SetTop(e_TopMiddle4, (eg.Center.Y - diffY) - e_TopMiddle4.Height / 2);
                    break;
                    
                default:
                    throw new System.ApplicationException("Error: incorrect EllipseGeometry controlpoint type");
            }
            string xamlstring = System.Windows.Markup.XamlWriter.Save(DrawingPane);
            ((TextBox)XAMLPane.Children[0]).Text = xamlstring;
        }

        private void UpdateRectangleGeometry(Point movingEndLocation, string ID)
        {
            
            double width, height;
            string[] s = ID.Split('_');
            string controlPointType = GetContronPointTypeInID(ID);
            Path p = SearchUpdatedElement(s[0]) as Path;
            if (p == null)
            {
                throw new System.ApplicationException("Error:  incorrect geometry ID");
            }
            currentElement = p;
            RectangleGeometry rg = p.Data as RectangleGeometry;

            //Get all of the related control points in DesignerPane
            Ellipse r_TopLeft = (Ellipse)LogicalTreeHelper.FindLogicalNode(DesignerPane, s[0] + "_TopLeft");
            Ellipse r_TopRight = (Ellipse)LogicalTreeHelper.FindLogicalNode(DesignerPane, s[0] + "_TopRight");
            Ellipse r_BottomLeft = (Ellipse)LogicalTreeHelper.FindLogicalNode(DesignerPane, s[0] + "_BottomLeft");
            Ellipse r_BottomRight = (Ellipse)LogicalTreeHelper.FindLogicalNode(DesignerPane, s[0] + "_BottomRight");
            Ellipse r_Corner = (Ellipse)LogicalTreeHelper.FindLogicalNode(DesignerPane, s[0] + "_Corner");


            switch (controlPointType)
            {
                case "TopLeft":
                    width  = rg.Rect.Width  +  (rg.Rect.X - movingEndLocation.X);
                    height = rg.Rect.Height +  (rg.Rect.Y - movingEndLocation.Y);
                    RectangleWidth.Text = width.ToString();
                    RectangleHeight.Text = height.ToString();

                    //Update the RectangleGeometry.
                    rg.Rect = new Rect(movingEndLocation.X, movingEndLocation.Y, width, height);

                    //Update the control points
                    Canvas.SetLeft(r_TopRight, (movingEndLocation.X + width) - r_TopRight.Width / 2);
                    Canvas.SetTop(r_TopRight, (movingEndLocation.Y) - r_TopRight.Height / 2);
                    Canvas.SetLeft(r_BottomLeft, movingEndLocation.X - r_BottomLeft.Width / 2);

                    if (r_Corner != null)
                    {
                        Canvas.SetLeft(r_Corner, movingEndLocation.X + rg.RadiusX - r_Corner.Width / 2);
                        Canvas.SetTop(r_Corner, movingEndLocation.Y + rg.RadiusY - r_Corner.Height / 2);
                    }
                    
                    RectangleTopLeftPoint.Text = movingEndLocation.X + " " + movingEndLocation.Y;
                    break;
                case "TopRight":
                    width = movingEndLocation.X - rg.Rect.X;
                    height = (rg.Rect.Y + rg.Rect.Height) - movingEndLocation.Y;
                    RectangleWidth.Text = width.ToString();
                    RectangleHeight.Text = height.ToString();

                    //Update the control points
                    Canvas.SetTop(r_TopLeft, movingEndLocation.Y - r_TopLeft.Height / 2 );
                    Canvas.SetLeft(r_BottomRight, movingEndLocation.X - r_BottomRight.Width / 2);
                    
                    if (r_Corner != null)
                    {
                        Canvas.SetTop(r_Corner, Canvas.GetTop(r_Corner) + (movingEndLocation.Y - rg.Rect.Y) - r_Corner.Height / 2);                    
                    }

                    //Update the RectangleGeometry
                    rg.Rect = new Rect(Canvas.GetLeft(r_TopLeft) + r_TopLeft.Width / 2, Canvas.GetTop(r_TopLeft) + r_TopLeft.Height / 2, width, height);

                    //Update the TopLeft control field
                    RectangleTopLeftPoint.Text = movingEndLocation.X + " " + movingEndLocation.Y;

                    break;
                case "BottomLeft":
                
                    width = rg.Rect.Width + (rg.Rect.X - movingEndLocation.X);
                    height = movingEndLocation.Y - rg.Rect.Y;
                    RectangleWidth.Text = width.ToString();
                    RectangleHeight.Text = height.ToString();

                    //Update the control points
                    Canvas.SetLeft(r_TopLeft, movingEndLocation.X - r_TopLeft.Width / 2);
                    Canvas.SetLeft(r_BottomRight, movingEndLocation.X + width - r_BottomRight.Width / 2);
                    Canvas.SetTop(r_BottomRight, movingEndLocation.Y - r_BottomRight.Height / 2);
                    
                    if (r_Corner != null)
                    {
                        Canvas.SetLeft(r_Corner, movingEndLocation.X + rg.RadiusX - r_Corner.Width / 2);            
                    }

                    RectangleTopLeftPoint.Text = Canvas.GetLeft(r_TopLeft) + r_TopLeft.Width / 2 + " " + Canvas.GetTop(r_TopLeft) + r_TopLeft.Height / 2;

                    //Update the RectangleGeometry
                    rg.Rect = new Rect(Canvas.GetLeft(r_TopLeft) + r_TopLeft.Width / 2, Canvas.GetTop(r_TopLeft) + r_TopLeft.Height / 2, width, height);
                    
                    break;
                    
                case "BottomRight":
                    width = movingEndLocation.X - rg.Rect.X;
                    height = movingEndLocation.Y - rg.Rect.Y;
                    RectangleWidth.Text = width.ToString();
                    RectangleHeight.Text = height.ToString();

                    //Update the control points
                    Canvas.SetLeft(r_TopRight, movingEndLocation.X - r_TopRight.Width / 2);
                    Canvas.SetTop(r_BottomLeft, movingEndLocation.Y - r_BottomLeft.Height / 2);

                    //Update the RectangleGeometry
                    rg.Rect = new Rect(Canvas.GetLeft(r_TopLeft) + r_TopLeft.Width / 2, Canvas.GetTop(r_TopLeft) + r_TopLeft.Height / 2, width, height);

                    p.Data = rg;
                    break;
                case "Corner":
                    double radiusx = movingEndLocation.X - rg.Rect.X;
                    double radiusy = movingEndLocation.Y - rg.Rect.Y;

                    if (radiusx <= 0)
                    {
                        Canvas.SetLeft(r_Corner, rg.Rect.X + 0.1 - r_Corner.Width);
                        radiusx = 0.1;
                    }
                    if (radiusy <= 0)
                    {
                        Canvas.SetTop(r_Corner, rg.Rect.Y + 0.1 - r_Corner.Height / 2);
                        radiusy = 0.1;
                    }

                    RectangleWidth.Text = radiusx.ToString();
                    RectangleHeight.Text = radiusy.ToString();

                    rg.RadiusX = radiusx;
                    rg.RadiusY = radiusy;

                    p.Data = rg;
                    break;
                default:
                    throw new System.ApplicationException("Error: Incorrect control point type");
            }
            string xamlstring = System.Windows.Markup.XamlWriter.Save(DrawingPane);
            ((TextBox)XAMLPane.Children[0]).Text = xamlstring;
        }

        private void UpdateBezierGeometry(Point movingEndLocation, string ID)
        {
            string[] s = ID.Split('_');
            string controlPointType = GetContronPointTypeInID(ID);
            Path p = SearchUpdatedElement(s[0]) as Path;
            if (p == null)
            {
                throw new System.ApplicationException("Error:  incorrect geometry ID");
            }
            currentElement = p;
            PathGeometry pg = p.Data.Clone() as PathGeometry;
            PathFigure pf = pg.Figures[0];
            switch (controlPointType)
            {
                case "StartPoint":
                    pf.StartPoint = movingEndLocation;
                    BezierStartPoint.Text = movingEndLocation.X + " " + movingEndLocation.Y;
                    break;
                case "Point1":
                    BezierPoint1.Text = movingEndLocation.X + " " + movingEndLocation.Y;
                    ((BezierSegment)pf.Segments[0]).Point1 = movingEndLocation;
                    break;
                case "Point2":
                    BezierPoint2.Text = movingEndLocation.X + " " + movingEndLocation.Y;
                    ((BezierSegment)pf.Segments[0]).Point2 = movingEndLocation;
                    break;
                case "Point3":
                    BezierPoint3.Text = movingEndLocation.X + " " + movingEndLocation.Y;
                    ((BezierSegment)pf.Segments[0]).Point3 = movingEndLocation;
                    break;
                default:
                    throw new System.ApplicationException("Error:  Incorrect control point type");
            }

            p.Data = pg;
            string xamlstring = System.Windows.Markup.XamlWriter.Save(DrawingPane);
            ((TextBox)XAMLPane.Children[0]).Text = xamlstring;
        }

        private string GetContronPointTypeInID(string ID)
        {
            string[] s = ID.Split('_');
            return s[1];
        }

        private string GetGeometryTypeInID(string ID)
        {
            string[] s = ID.Split('_');
            if (s[0].Contains("Line"))
            {
                return "Line";
            }
            else
            {
                if (s[0].Contains("Ellipse"))
                {
                    return "Ellipse";
                }
                else
                {
                    if (s[0].Contains("Rectangle"))
                    {
                        return "Rectangle";
                    }
                    else
                    {
                        if (s[0].Contains("Arc"))
                        {
                            return "Arc";
                        }
                        else
                        {
                            return "Bezier";
                        }
                    }
                }
            }
        }

        private string GetControlPointName(string ID)
        {
            return null;
        }
        
        private void AddControlPoints(ArrayList controlPoints, string geometryType)
        {
            switch (geometryType)
            {
                case "Line":
                    AddLineGeometryControlPoints(controlPoints);
                    break;
                case "Ellipse":
                    AddEllipseGeometryControlPoints(controlPoints);
                    break;
                case "Rectangle":
                    AddRectangleGeometryControlPoints(controlPoints);
                    break;
                case "Arc":
                    AddArcGeometryControlPoints(controlPoints);
                    break;
                case "Bezier":
                    AddBezierGeometryControlPoints(controlPoints);
                    break;
                default:
                    throw new System.ApplicationException("Error:  incorrect Geometry type");
            }
        }


        private static double ControlPointMarkerWidth = 20;
        private static double ControlPointMarkerHeight = 20;
        
        private void AddLineGeometryControlPoints(ArrayList controlPoints)
        {
            if (controlPoints.Count != 2)
                throw new System.ApplicationException("Error:  incorrect # of control points for LineGeometry");

            for (int i = 0; i < controlPoints.Count; i++)
            {
                Ellipse e = new Ellipse();
                e.Visibility = Visibility.Hidden;
                e.Stroke = Brushes.Black;
                e.StrokeThickness = 1;
                e.Fill = Brushes.White;
                e.Opacity = 0.5;
                e.Width = 3;
                e.Height = 3;

                if (i == 0)
                {
                    e.Name = "Line" + LineCount + "_StartPoint";
                }
                else
                {
                    e.Name = "Line" + LineCount + "_EndPoint";
                }

                e.Width =  ControlPointMarkerWidth; 
                e.Height =  ControlPointMarkerHeight; 
                Canvas.SetLeft(e, ((Point)controlPoints[i]).X - e.Width / 2 ); 
                Canvas.SetTop(e, ((Point)controlPoints[i]).Y - e.Height / 2 );
                
                
                e.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(Ellipse_MouseLeftButtonDown);
                e.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(Ellipse_MouseLeftButtonUp);
                e.MouseMove += new System.Windows.Input.MouseEventHandler(Ellipse_MouseMove);

                //Add the control point to the Designer Pane
                //DesignerPane.Children.Add(e);
                DesignerPane.Children.Insert(DesignerPane.Children.Count - 1, e);
            }
            
        }

        private void AddEllipseGeometryControlPoints(ArrayList controlPoints)
        {
            if (controlPoints.Count != 5)
            {
                throw new System.ApplicationException("Error:  incorrect # of control points for EllipseGeometry");
            }
            for (int i = 0; i < controlPoints.Count; i++)
            {
                Ellipse e = new Ellipse();
                e.Visibility = Visibility.Hidden;
                e.Stroke = Brushes.Black;
                e.StrokeThickness = 1;
                e.Fill = Brushes.White;
                e.Opacity = 0.5;
                e.Width = 3;
                e.Height = 3;

                switch (i)
                {
                    case 0:
                        e.Name = "Ellipse" + ElliipseCount + "_Center";
                        break;
                    case 1:
                        e.Name = "Ellipse" + ElliipseCount + "_TopLeft";
                        break;
                    case 2:
                        e.Name = "Ellipse" + ElliipseCount + "_TopMiddle";
                        break;
                    case 3:
                        e.Name = "Ellipse" + ElliipseCount + "_TopRight";
                        break;
                    case 4:
                        e.Name = "Ellipse" + ElliipseCount + "_BottomMiddle";
                        break;
                    default:
                        throw new System.ApplicationException("Error: Incorrect control point ");
                }

                e.Width =  ControlPointMarkerWidth; 
                e.Height =  ControlPointMarkerHeight; 
                Canvas.SetLeft(e, ((Point)controlPoints[i]).X - e.Width / 2 ); 
                Canvas.SetTop(e, ((Point)controlPoints[i]).Y - e.Height / 2 );                
      
                e.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(Ellipse_MouseLeftButtonDown);
                e.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(Ellipse_MouseLeftButtonUp);
                e.MouseMove += new System.Windows.Input.MouseEventHandler(Ellipse_MouseMove);

                //Add the control point to the Designer Pane
                DesignerPane.Children.Insert(DesignerPane.Children.Count - 1, e);
            }
        }

        private void AddRectangleGeometryControlPoints(ArrayList controlPoints)
        {
            
            if (controlPoints.Count != 5 && controlPoints.Count != 4)
            {
                throw new System.ApplicationException("Error:  incorrect # of control points for RectangleGeometry");
            }
            for (int i = 0; i < controlPoints.Count; i++)
            {
                Ellipse e = new Ellipse();
                e.Visibility = Visibility.Hidden;
                e.Stroke = Brushes.Black;
                e.StrokeThickness = 1;
                e.Fill = Brushes.White;
                e.Opacity = 0.5;
                e.Width = 3;
                e.Height = 3;

                switch (i)
                {
                    case 0:
                        e.Name = "Rectangle" + RectangleCount + "_TopLeft";
                        break;
                    case 1:
                        e.Name = "Rectangle" + RectangleCount + "_TopRight";
                        break;
                    case 2:
                        e.Name = "Rectangle" + RectangleCount + "_BottomLeft";
                        break;
                    case 3:
                        e.Name = "Rectangle" + RectangleCount + "_BottomRight";
                        break;
                    case 4:
                        e.Name = "Rectangle" + RectangleCount + "_Corner";
                        break;
                    default:
                        throw new System.ApplicationException("Error: Incorrect control point ");
                }


                e.Width = ControlPointMarkerWidth;
                e.Height = ControlPointMarkerHeight;
                Canvas.SetLeft(e, ((Point)controlPoints[i]).X - e.Width / 2);
                Canvas.SetTop(e, ((Point)controlPoints[i]).Y - e.Height / 2);
                e.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(Ellipse_MouseLeftButtonDown);
                e.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(Ellipse_MouseLeftButtonUp);
                e.MouseMove += new System.Windows.Input.MouseEventHandler(Ellipse_MouseMove);

                //Add the control point to the Designer Pane
                DesignerPane.Children.Insert(DesignerPane.Children.Count - 1, e);

            }
        }

        private void AddArcGeometryControlPoints(ArrayList controlPoints)
        {
            if (controlPoints.Count != 2)
            {
                throw new System.ApplicationException("Error:  incorrect # of control points for Arc Geometry");
            }
            for (int i = 0; i < controlPoints.Count; i++)
            {
                Ellipse e = new Ellipse();
                e.Visibility = Visibility.Hidden;
                e.Stroke = Brushes.Black;
                e.StrokeThickness = 1;
                e.Fill = Brushes.White;
                e.Opacity = 0.5;
                e.Width = 3;
                e.Height = 3;

                switch (i)
                {
                    case 0:
                        e.Name = "Arc" + ArcCount + "_StartPoint";
                        break;
                    case 1:
                        e.Name = "Arc" + ArcCount + "_Point";
                        break;
                    default:
                        throw new System.ApplicationException("Error: Incorrect control point ");
                }

                e.Width = ControlPointMarkerWidth;
                e.Height = ControlPointMarkerHeight;
                Canvas.SetLeft(e, ((Point)controlPoints[i]).X - e.Width / 2);
                Canvas.SetTop(e, ((Point)controlPoints[i]).Y - e.Height / 2);
                
                e.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(Ellipse_MouseLeftButtonDown);
                e.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(Ellipse_MouseLeftButtonUp);
                e.MouseMove += new System.Windows.Input.MouseEventHandler(Ellipse_MouseMove);
                
                //Add the control point to the Designer Pane
                //DesignerPane.Children.Insert(DesignerPane.Children.Count - 2, e);
                DesignerPane.Children.Insert(DesignerPane.Children.Count - 1, e);

            }
        }

        private void AddBezierGeometryControlPoints(ArrayList controlPoints)
        {
            if (controlPoints.Count != 4)
            {
                throw new System.ApplicationException("Error:  incorrect # of control points for Bezier Geometry");
            }
            for (int i = 0; i < controlPoints.Count; i++)
            {
                Ellipse e = new Ellipse();
                e.Visibility = Visibility.Hidden;
                e.Stroke = Brushes.Black;
                e.StrokeThickness = 1;
                e.Fill = Brushes.White;
                e.Opacity = 0.5;
                e.Width = 3;
                e.Height = 3;

                switch (i)
                {
                    case 0:
                        e.Name = "Bezier" + BezierCount + "_StartPoint";
                        break;
                    case 1:
                        e.Name = "Bezier" + BezierCount + "_Point1";
                        break;
                    case 2:
                        e.Name = "Bezier" + BezierCount + "_Point2";
                        break;
                    case 3:
                        e.Name = "Bezier" + BezierCount + "_Point3";
                        break;
                    default:
                        throw new System.ApplicationException("Error: Incorrect control point ");
                }

                e.Width = ControlPointMarkerWidth;
                e.Height = ControlPointMarkerHeight;
                Canvas.SetLeft(e, ((Point)controlPoints[i]).X - e.Width / 2);
                Canvas.SetTop(e, ((Point)controlPoints[i]).Y - e.Height / 2);
                e.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(Ellipse_MouseLeftButtonDown);
                e.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(Ellipse_MouseLeftButtonUp);
                e.MouseMove += new System.Windows.Input.MouseEventHandler(Ellipse_MouseMove);

                //Add the control point to the Designer Pane
                DesignerPane.Children.Insert(DesignerPane.Children.Count - 1, e);
            }

        }

        /// <summary>
        /// The function takes the design pane element,e.g. LinePane, RectanglePane, 
        /// and extract the value from the different control point fields from the pane and construct 
        /// a Path with the correct Geometry
        /// </summary>
        /// <param name="pane"></param>
        /// <returns></returns>
        private GeometryBase GeometryFactory(FrameworkElement pane)
        {

            switch (pane.Name.Remove(pane.Name.LastIndexOf("Pane")))
            {
                case "Line":
                    return new LineG(pane);
                case "Ellipse":
                    return new EllipseG(pane);
                case "Rectangle":
                    return new RectanlgeG(pane);
                case "Arc":
                    return new ArcG(pane);
                case "Bezier":
                    return new BezierG(pane);
                default:
                    throw new System.ApplicationException("Error:  Unknow Geometry name?");
            }

        }
        #endregion

        #region Data members
        private bool InitialSelection = true;
        private int LineCount = 1;
        private int ElliipseCount = 1;
        private int RectangleCount = 1;
        private int ArcCount = 1;
        private int BezierCount = 1;
        private bool IsShow = false;
        private Path currentElement = null;
        private bool IsInsert = true;
        #endregion

        public abstract class GeometryBase
        {
            public GeometryBase(FrameworkElement pane)
            {
                parentPane = pane;
            }

            public abstract void Parse();
            public abstract Geometry CreateGeometry();

            protected double  doubleParser( string s )
            {

                return Double.Parse(s);
            }
            
            protected Point pointParser(string o)
            {

                try
                {
                    
                    return Point.Parse(o);

                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    throw new System.ApplicationException("Error: please enter two numeric values separated  by a comma or a space; for example, 10,30.");
                }

            }
            protected Size sizeParser(string o)
            {
                Size retval = new Size();

                string[] sizeString = o.Split(new char[] { ' ', ',', ';' });
                if (sizeString.Length == 0 || sizeString.Length != 2)
                    throw new System.ApplicationException("Error: a size should contain two double that seperated by a space or ',' or ';'");

                try
                {
                    double d1 = Convert.ToDouble(sizeString[0], System.Globalization.CultureInfo.InvariantCulture);
                    double d2 = Convert.ToDouble(sizeString[1], System.Globalization.CultureInfo.InvariantCulture);
                    retval.Width = d1;
                    retval.Height = d2;
                }
                catch (Exception)
                {
                    throw new System.ApplicationException("Error: please enter only two numeric values into the field");
                }

                return retval;
            }

            #region Data member
            protected FrameworkElement parentPane;
            public ArrayList controlPoints;
            public string geometryType;
            #endregion
        }

        public class LineG : GeometryBase
        {
            public LineG(FrameworkElement pane)
                : base(pane)
            {
                controlPoints = new ArrayList();
                geometryType = "Line";
                Parse(); 
            }

            public override void Parse()
            {
                TextBox tb_startPoint = LogicalTreeHelper.FindLogicalNode(parentPane, "LineStartPoint") as TextBox;
                TextBox tb_endPoint = LogicalTreeHelper.FindLogicalNode(parentPane, "LineEndPoint") as TextBox;

                startPoint = pointParser(tb_startPoint.Text);
                endPoint = pointParser(tb_endPoint.Text);

                controlPoints.Add(startPoint);
                controlPoints.Add(endPoint);
            }

            public override Geometry CreateGeometry()
            {
                LineGeometry lg = new LineGeometry(startPoint, endPoint);
                return lg;
            }

            #region Data members
            private Point startPoint;
            private Point endPoint;
            #endregion
        }

        public class EllipseG : GeometryBase
        {
            public EllipseG(FrameworkElement pane) : base(pane)
            {
                controlPoints = new ArrayList();
                geometryType = "Ellipse";
                Parse();
            }

            public override void Parse()
            {
                TextBox tb_center = LogicalTreeHelper.FindLogicalNode(parentPane, "EllipseCenterPoint") as TextBox;
                TextBox tb_radiusx = LogicalTreeHelper.FindLogicalNode(parentPane, "EllipseRadiusX") as TextBox;
                TextBox tb_radiusy = LogicalTreeHelper.FindLogicalNode(parentPane, "EllipseRadiusY") as TextBox;

                center = pointParser(tb_center.Text);
                radiusx = doubleParser(tb_radiusx.Text);
                radiusy = doubleParser(tb_radiusy.Text);

                //Center point
                controlPoints.Add(center);

                //TopLeft
                controlPoints.Add(new Point(center.X - radiusx , center.Y));

                //TopMiddle
                controlPoints.Add(new Point(center.X , center.Y - radiusy));

                //TopRight
                controlPoints.Add(new Point(center.X + radiusx, center.Y));

                //BottomMiddle
                controlPoints.Add(new Point(center.X , center.Y + radiusy));

            }

            public override Geometry CreateGeometry()
            {
                EllipseGeometry retval = new EllipseGeometry(center, radiusx, radiusy);
                return retval;
            }

            #region Data Members
            private Point  center;
            private double radiusx;
            private double radiusy;
            #endregion
        }

        public class RectanlgeG : GeometryBase
        {
            public RectanlgeG(FrameworkElement pane)
                : base(pane)
            {
                controlPoints = new ArrayList();
                geometryType = "Rectangle";
                Parse();
            }

            public override Geometry CreateGeometry()
            {
                RectangleGeometry retval = new RectangleGeometry(new Rect(topleft.X, topleft.Y, width, height), radiusx, radiusy);
                
                return retval;
            }

            public override void Parse()
            {
                TextBox tb_topleft = LogicalTreeHelper.FindLogicalNode(parentPane, "RectangleTopLeftPoint") as TextBox;
                TextBox tb_radiusx = LogicalTreeHelper.FindLogicalNode(parentPane, "RectangleRadiusX") as TextBox;
                TextBox tb_radiusy = LogicalTreeHelper.FindLogicalNode(parentPane, "RectangleRadiusY") as TextBox;
                TextBox tb_width = LogicalTreeHelper.FindLogicalNode(parentPane, "RectangleWidth") as TextBox;
                TextBox tb_height = LogicalTreeHelper.FindLogicalNode(parentPane, "RectangleHeight") as TextBox;

                topleft = pointParser(tb_topleft.Text);
                radiusx = doubleParser(tb_radiusx.Text);
                radiusy = doubleParser(tb_radiusy.Text);
                width = doubleParser(tb_width.Text);
                height = doubleParser(tb_height.Text);

                //TopLeft point
                controlPoints.Add(topleft);

                //TopRight
                controlPoints.Add(new Point(topleft.X + width, topleft.Y));

                //BottomLeft
                controlPoints.Add(new Point(topleft.X, topleft.Y + height));

                //BottomRight
                controlPoints.Add(new Point(topleft.X + width, topleft.Y + height));

                if (radiusx != 0 && radiusy != 0)
                {
                    controlPoints.Add(new Point(topleft.X + radiusx, topleft.Y + radiusy));
                }

            }

            #region Data Members
            private Point topleft;
            private double width;
            private double height;
            private double radiusx;
            private double radiusy;
            #endregion
        }

        public class BezierG : GeometryBase
        {
            public BezierG(FrameworkElement pane)
                : base(pane)
            {
                controlPoints = new ArrayList();
                geometryType = "Bezier";
                Parse();
            }

            public override Geometry CreateGeometry()
            {
                PathGeometry retval = new PathGeometry();
                PathFigure pf = new PathFigure();
                pf.StartPoint = startpoint;
                pf.Segments.Add(new BezierSegment(p1, p2, p3, true));
                retval.Figures.Add(pf);
                return retval;
            }

            public override void Parse()
            {
                TextBox tb_startpoint = LogicalTreeHelper.FindLogicalNode(parentPane, "BezierStartPoint") as TextBox;
                TextBox tb_point1 = LogicalTreeHelper.FindLogicalNode(parentPane, "BezierPoint1") as TextBox;
                TextBox tb_point2 = LogicalTreeHelper.FindLogicalNode(parentPane, "BezierPoint2") as TextBox;
                TextBox tb_point3 = LogicalTreeHelper.FindLogicalNode(parentPane, "BezierPoint3") as TextBox;

                startpoint = pointParser(tb_startpoint.Text);
                p1 = pointParser(tb_point1.Text);
                p2 = pointParser(tb_point2.Text);
                p3 = pointParser(tb_point3.Text);

                controlPoints.Add(startpoint);
                controlPoints.Add(p1);
                controlPoints.Add(p2);
                controlPoints.Add(p3);
            }

            #region Data Members
            Point startpoint, p1, p2, p3;
            #endregion


        }

        public class ArcG : GeometryBase
        {
            public ArcG(FrameworkElement pane)
                : base(pane)
            {
                controlPoints = new ArrayList();
                geometryType = "Arc";
                Parse();
            }

            public override Geometry CreateGeometry()
            {
                PathGeometry retval = new PathGeometry();
                PathFigure pf = new PathFigure();
                pf.StartPoint = startpoint;
                pf.Segments.Add(new ArcSegment(point, size, xrotation, largearc, sweepArcDirection, true));
                retval.Figures.Add(pf);
                return retval;
            }

            public override void Parse()
            {
                TextBox tb_startpoint = LogicalTreeHelper.FindLogicalNode(parentPane, "ArcStartPoint") as TextBox;
                TextBox tb_point = LogicalTreeHelper.FindLogicalNode(parentPane, "ArcPoint") as TextBox;
                TextBox tb_size = LogicalTreeHelper.FindLogicalNode(parentPane, "ArcSize") as TextBox;
                TextBox tb_xrotation = LogicalTreeHelper.FindLogicalNode(parentPane, "ArcXRotation") as TextBox;
                ComboBox cb_sweeparc = LogicalTreeHelper.FindLogicalNode(parentPane, "ArcSweepArc") as ComboBox;
                ComboBox cb_largearc = LogicalTreeHelper.FindLogicalNode(parentPane, "ArcLargeArc") as ComboBox;

                startpoint = pointParser(tb_startpoint.Text);
                point = pointParser(tb_point.Text);
                size = sizeParser(tb_size.Text);
                xrotation = doubleParser(tb_xrotation.Text);
                sweepArcDirection = (SweepDirection)Enum.Parse(
                    
                    typeof(SweepDirection), 
                    (
                        (string)
                        (
                            (ComboBoxItem)cb_sweeparc.SelectedItem
                        ).Content
                    )
                );                

                largearc = Boolean.Parse(((String)((ComboBoxItem)cb_largearc.SelectedItem).Content));
                controlPoints.Add(startpoint);
                controlPoints.Add(point);
            }

            #region Data Members
            Point startpoint, point;
            Size size;
            bool largearc;
            SweepDirection sweepArcDirection;
            double xrotation;
            #endregion


        }


    }


}
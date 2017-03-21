        private void GetLastPointExample(PaintEventArgs e)
        {
            GraphicsPath myPath = new GraphicsPath();
            myPath.AddLine(20, 20, 100, 20);
            PointF lastPoint = myPath.GetLastPoint();
            if(lastPoint.IsEmpty == false)
            {
                string lastPointXString = lastPoint.X.ToString();
                string lastPointYString = lastPoint.Y.ToString();
                MessageBox.Show(lastPointXString + ", " + lastPointYString);
            }
            else
                MessageBox.Show("lastPoint is empty");
        }
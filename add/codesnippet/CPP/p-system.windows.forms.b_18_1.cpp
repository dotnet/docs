        void Form1_Load(Object^ sender, EventArgs^ e)
        {
            // Set the data source to the Brush type and populate
            // bindingSource1; with some brushes.
            bindingSource1->DataSource = System::Drawing::Brush::typeid;
            bindingSource1->Add(
                gcnew TextureBrush(gcnew Bitmap(Button::typeid, "Button.bmp")));
            bindingSource1->Add(gcnew HatchBrush(HatchStyle::Cross, Color::Red));
            bindingSource1->Add(gcnew SolidBrush(Color::Blue));
        }


    private:
        void moveNextButton_Click(Object^ sender, EventArgs^ e)
        {
            // If you are not at the end of the list, move to the next item
            // in the BindingSource.
            if (bindingSource1->Position + 1 < bindingSource1->Count)
            {
                bindingSource1->MoveNext();
            }
            // Otherwise, move back to the first item.
            else
            {
                bindingSource1->MoveFirst();
            }
            // Force the form to repaint.
            this->Invalidate();
        }

        void Form1_Paint(Object^ sender, PaintEventArgs^ e)
        {
            // Get the current item in the BindingSource.
            Brush^ item = (Brush^) bindingSource1->Current;

            // If the current type is a TextureBrush, fill an ellipse.
            if (item->GetType() == TextureBrush::typeid)
            {
                e->Graphics->FillEllipse(item,e->ClipRectangle);
            }
            // If the current type is a HatchBrush, fill a triangle.
            else if (item->GetType() == HatchBrush::typeid)
            {

                e->Graphics->FillPolygon(item, 
                    gcnew array<Point> {*gcnew Point(0, 0),
                    *gcnew Point(0, 200),
                    *gcnew Point(200, 0)});
            }
            // Otherwise, fill a rectangle.
            else
            {
                e->Graphics->FillRectangle(
                    (Brush^)bindingSource1->Current, e->ClipRectangle);
            }
        }

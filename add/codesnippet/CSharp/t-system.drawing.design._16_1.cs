        public PaintValueEventArgs CreatePaintValueEventArgs(System.ComponentModel.ITypeDescriptorContext context, object value, Graphics graphics, Rectangle bounds)
        {
            PaintValueEventArgs e = new PaintValueEventArgs(context, value, graphics, bounds);
            // The context of the paint value event         e.Context
            // The object representing the value to paint   e.Value
            // The graphics to use to paint                 e.Graphics
            // The rectangle in which to paint              e.Bounds                       
            return e;
        }
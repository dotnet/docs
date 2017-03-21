        public ActiveDesignerEventArgs CreateActiveDesignerEventArgs(IDesignerHost losingFocus, IDesignerHost gainingFocus)
        {
            ActiveDesignerEventArgs e = new ActiveDesignerEventArgs(losingFocus, gainingFocus);
	        return e;
        }
        // Do not allow direct resizing unless in TemplateMode
        public override bool AllowResize
        {
            get
            {
                if (this.InTemplateMode)
                    return true;
                else
                    return false;
            }
        }
        // Provide a design-time caption for the panel.
        public override string FrameCaption 
        {
            get
            {
                // If the FrameCaption is empty, use the panel control ID.
                string localCaption = base.FrameCaption;
                if (localCaption == null || localCaption == "")
                    localCaption = ((Panel)Component).ID.ToString();

                return localCaption;
            }
        } // FrameCaption
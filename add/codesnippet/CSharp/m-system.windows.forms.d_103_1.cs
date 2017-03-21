        void changeService_ComponentChanged(object sender, ComponentChangedEventArgs e)
        {
            if (object.ReferenceEquals(
                e.Component, 
                this.relatedControl))
            {
                if (e.Member.Name == "Margin" ||
                    e.Member.Name == "Padding" )
                {
                    this.marginAndPaddingAdorner.Invalidate();
                }
            }
        }
    // This is the shadowed property on the designer.
    // This value will be serialized instead of the 
    // value of the control's property.
    public Color BackColor
    {
        get
        {
            return (Color)ShadowProperties["BackColor"];
        }
        set
        {
            if (this.changeService != null)
            {
                PropertyDescriptor backColorDesc =
                    TypeDescriptor.GetProperties(this.Control)["BackColor"];

                this.changeService.OnComponentChanging(
                    this.Control,
                    backColorDesc);

                this.ShadowProperties["BackColor"] = value;

                this.changeService.OnComponentChanged(
                    this.Control,
                    backColorDesc,
                    null,
                    null);
            }
        }
    }
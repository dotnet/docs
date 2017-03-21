        [AmbientValue(typeof(Color), "Empty")]
        [Category("Appearance")]
        [DefaultValue(typeof(Color), "White")]
        [Description("The color used for painting alert text.")]
        public Color AlertForeColor
        {
            get
            {
                if (this.alertForeColorValue == Color.Empty &&
                    this.Parent != null)
                {
                    return Parent.ForeColor;
                }

                return this.alertForeColorValue;
            }

            set
            {
                this.alertForeColorValue = value;
            }
        }

        // This method is used by designers to enable resetting the
        // property to its default value.
        public void ResetAlertForeColor()
        {
            this.AlertForeColor = AttributesDemoControl.defaultAlertForeColorValue;
        }

        // This method indicates to designers whether the property
        // value is different from the ambient value, in which case
        // the designer should persist the value.
        private bool ShouldSerializeAlertForeColor()
        {
            return (this.alertForeColorValue != AttributesDemoControl.ambientColorValue);
        }
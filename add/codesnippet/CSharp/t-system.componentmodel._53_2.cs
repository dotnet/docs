    [TypeConverter(typeof(BorderAppearanceConverter))]
    public class BorderAppearance
    {
        private int borderSizeValue = 1;
        private Color borderColorValue = Color.Empty;

        [Browsable(true),
        NotifyParentProperty(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DefaultValue(1)]
        public int BorderSize
        {
            get
            {
                return borderSizeValue;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "BorderSize",
                        value,
                        "must be >= 0");
                }

                if (borderSizeValue != value)
                {
                    borderSizeValue = value;
                }
            }
        }

        [Browsable(true)]
        [NotifyParentProperty(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DefaultValue(typeof(Color), "")]
        public Color BorderColor
        {
            get
            {
                return borderColorValue;
            }
            set
            {
                if (value.Equals(Color.Transparent))
                {
                    throw new NotSupportedException("Transparent colors are not supported.");
                }

                if (borderColorValue != value)
                {
                    borderColorValue = value;
                }
            }
        }
    }
        // Normal implementation:
        public float Length()
        {
            return lengthInches;
        }
        public float Width()
        {
            return widthInches;
        }

        // Explicit implementation:
        float IMetricDimensions.Length()
        {
            return lengthInches * 2.54f;
        }
        float IMetricDimensions.Width()
        {
            return widthInches * 2.54f;
        }
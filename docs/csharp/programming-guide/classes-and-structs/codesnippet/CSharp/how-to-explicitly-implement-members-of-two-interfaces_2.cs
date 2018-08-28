        // Normal implementation:
        public float Length() => lengthInches;
        public float Width() => widthInches;

        // Explicit implementation:
        float IMetricDimensions.Length() => lengthInches * 2.54f;
        float IMetricDimensions.Width() => widthInches * 2.54f;

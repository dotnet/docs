    class CS0663_Example
    {
        // Compiler error CS0663: "Cannot define overloaded 
        // methods that differ only on ref and out".
        public void SampleMethod(out int i) { }
        public void SampleMethod(ref int i) { }
    }
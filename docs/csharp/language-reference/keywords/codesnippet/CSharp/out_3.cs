    class OutOverloadExample
    {
        public void SampleMethod(int i) { }
        public void SampleMethod(out int i) { i = 5; }
    }
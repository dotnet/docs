        public static void TestRefType()
        {
            SampleRefType rt = new SampleRefType();
            rt.value = 44;
            ModifyObject(rt);
            Console.WriteLine(rt.value);
        }
        static void ModifyObject(SampleRefType obj)
        {
            obj.value = 33;
        }
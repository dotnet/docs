        static void WriteObjectInfo(object testObject)
        {
            TypeCode    typeCode = Type.GetTypeCode( testObject.GetType() );

            switch( typeCode )
            {
                case TypeCode.Boolean:
                    Console.WriteLine("Boolean: {0}", testObject);
                    break;

                case TypeCode.Double:
                    Console.WriteLine("Double: {0}", testObject);
                    break;

                default:
                    Console.WriteLine("{0}: {1}", typeCode.ToString(), testObject);
                    break;
            }
        }
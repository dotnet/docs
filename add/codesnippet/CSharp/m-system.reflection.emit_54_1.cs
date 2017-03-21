            Type t1 = tbldr.MakeGenericType(typeof(string));
            Type t2 = tbldr.MakeGenericType(typeof(string));
            bool result = t1.Equals(t2);
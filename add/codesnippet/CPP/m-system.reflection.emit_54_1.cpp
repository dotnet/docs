            Type^ t1 = tbldr->MakeGenericType(String::typeid);
            Type^ t2 = tbldr->MakeGenericType(String::typeid);
            bool result = t1->Equals(t2);
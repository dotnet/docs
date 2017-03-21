      array<MemberInfo^>^ others = t->GetMember( mi->Name, mi->MemberType,
         (BindingFlags)(BindingFlags::Public | BindingFlags::Static |
            BindingFlags::NonPublic | BindingFlags::Instance) );
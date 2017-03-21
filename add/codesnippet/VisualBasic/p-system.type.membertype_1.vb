      Dim others As MemberInfo() = t.GetMember(mi.Name, mi.MemberType, _
      BindingFlags.Public Or BindingFlags.Static Or BindingFlags.NonPublic _
      Or BindingFlags.Instance)
        Dim username = GetUsername(
            Security.Principal.WindowsIdentity.GetCurrent().Name,
            CChar("\"),
            1
          )
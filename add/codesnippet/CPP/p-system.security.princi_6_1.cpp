      WindowsPrincipal^ wp = gcnew WindowsPrincipal( WindowsIdentity::GetCurrent() );
      String^ username = wp->Identity->Name;
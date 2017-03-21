      WindowsIdentity^ wi = WindowsIdentity::GetCurrent();
      WindowsPrincipal^ wp = gcnew WindowsPrincipal( wi );
 WindowsPrincipal wp = new WindowsPrincipal(WindowsIdentity.GetCurrent());
 String username = wp.Identity.Name;
 
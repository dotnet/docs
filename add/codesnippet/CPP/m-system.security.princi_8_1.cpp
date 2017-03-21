      WindowsImpersonationContext^ ImpersonationCtx = WindowsIdentity::Impersonate( userToken );
      
      //Do something under the context of the impersonated user.

      ImpersonationCtx->Undo();
      [PermissionSet(SecurityAction.Demand, Name="FullTrust")]
      public override void GetObjectData( SerializationInfo info, 
                                          StreamingContext context)
      {
         // Add your custom data if any here.
         base.GetObjectData(info, context);
      }
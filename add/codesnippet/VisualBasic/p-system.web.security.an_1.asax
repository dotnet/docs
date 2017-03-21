Public Sub AnonymousIdentification_Creating(sender As Object,  _
                                            args As AnonymousIdentificationEventArgs)
  args.AnonymousID = Samples.AspNet.Security.MyIdClass.GetAnonymousId()
  Samples.AspNet.Security.MyIdClass.LogAnonymousId(args.AnonymousId)
End Sub
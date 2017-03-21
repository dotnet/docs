      // Check whether the 'MyServerImpl' type is registered as
      // a remotely activated client type.
	  ActivatedClientTypeEntry^ myActivatedClientEntry = RemotingConfiguration::IsRemotelyActivatedClientType( MyServerImpl::typeid);
      Console::WriteLine( "The Object type is {0}", myActivatedClientEntry->ObjectType );
      Console::WriteLine( "The Application Url is {0}", myActivatedClientEntry->ApplicationUrl );
      
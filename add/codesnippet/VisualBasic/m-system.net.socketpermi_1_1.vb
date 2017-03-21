
	Dim socketPermission1 As New SocketPermission(PermissionState.Unrestricted)
	
        'Create a 'SocketPermission' object for two ip addresses.
        Dim socketPermission2 As New SocketPermission(PermissionState.None)
        Dim securityElement4 As SecurityElement = socketPermission2.ToXml()
        ''SocketPermission' object for 'Connect' permission
        Dim securityElement1 As New SecurityElement("ConnectAccess")
        'Format to specify ip address are <ip-address>#<port>#<transport-type>
        'First 'SocketPermission' ip-address is '192.168.144.238' for 'All' transport types and for 'All' ports for the ip-address.
        Dim securityElement2 As New SecurityElement("URI", "192.168.144.238#-1#3")
        'Second 'SocketPermission' ip-address is '192.168.144.240' for 'All' transport types and for 'All' ports for the ip-address.
        Dim securityElement3 As New SecurityElement("URI", "192.168.144.240#-1#3")
        securityElement1.AddChild(securityElement2)
        securityElement1.AddChild(securityElement3)
        securityElement4.AddChild(securityElement1)
        
        'Obtain a 'SocketPermission' object using 'FromXml' method.	
        socketPermission2.FromXml(securityElement4)
        
        'Create another 'SocketPermission' object with two ip addresses.
        'First 'SocketPermission' ip-address is '192.168.144.238' for 'All' transport types and for 'All' ports for the ip-address.
        Dim socketPermission3 As New SocketPermission(NetworkAccess.Connect, TransportType.All, "192.168.144.238", SocketPermission.AllPorts)
        
        'Second 'SocketPermission' ip-address is '192.168.144.239' for 'All' transport types and for 'All' ports for the ip-address.
        socketPermission3.AddPermission(NetworkAccess.Connect, TransportType.All, "192.168.144.239", SocketPermission.AllPorts)

        Console.WriteLine(ControlChars.Cr + "Checks the Socket permissions using IsUnrestricted method : ")
        If socketPermission1.IsUnrestricted() Then
            Console.WriteLine("Socket permission is unrestricted")
        Else
            Console.WriteLine("Socket permission is restricted")
        End If 
        Console.WriteLine()
        
        Console.WriteLine("Display result of ConnectList property : " + ControlChars.Cr)
        Dim enumerator As IEnumerator = socketPermission3.ConnectList
        While enumerator.MoveNext()
            Console.WriteLine("The hostname is       : {0}", CType(enumerator.Current, EndpointPermission).Hostname)
            Console.WriteLine("The port is           : {0}", CType(enumerator.Current, EndpointPermission).Port)
            Console.WriteLine("The Transport type is : {0}", CType(enumerator.Current, EndpointPermission).Transport)
        End While
        
        Console.WriteLine("")
        
        Console.WriteLine("Display Security Elements :" + ControlChars.Cr + " ")
        PrintSecurityElement(socketPermission2.ToXml(), 0)
        
        'Get a 'SocketPermission' object which is a union of two other 'SocketPermission' objects.
        socketPermission1 = CType(socketPermission3.Union(socketPermission2), SocketPermission)
        
        'Demand that the calling method have the socket permission.
        socketPermission1.Demand()
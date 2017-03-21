
        Dim socketPermission1 As New SocketPermission(PermissionState.Unrestricted)
        
        'Create a 'SocketPermission' object for two ip addresses.
        Dim socketPermission2 As New SocketPermission(PermissionState.None)
        Dim securityElement1 As SecurityElement = socketPermission2.ToXml()
        ''SocketPermission' object for 'Connect' permission
        Dim securityElement2 As New SecurityElement("ConnectAccess")
        'Format to specify ip address are <ip-address>#<port>#<transport-type>
        'First 'SocketPermission' ip-address is '192.168.144.238' for 'All' transport types and for 'All'
        ' ports for the ip-address.
        Dim securityElement3 As New SecurityElement("URI", "192.168.144.238#-1#3")
        'Second 'SocketPermission' ip-address is '192.168.144.240' for 'All' transport types and for 'All' ports for the ip-address.
        Dim securityElement4 As New SecurityElement("URI", "192.168.144.240#-1#3")
        securityElement2.AddChild(securityElement3)
        securityElement2.AddChild(securityElement4)
        securityElement1.AddChild(securityElement2)
        

        'Obtain a 'SocketPermission' object using 'FromXml' method.
        socketPermission2.FromXml(securityElement1)
        
        Console.WriteLine(ControlChars.Cr + "Displays the result of FromXml method : " + ControlChars.Cr)
        Console.WriteLine(socketPermission2.ToString())
        
        'Create another 'SocketPermission' object with two ip addresses.
        'First 'SocketPermission' ip-address is '192.168.144.238' for 'All' transport types and for 'All' ports for the ip-address.
        Dim socketPermission3 As New SocketPermission(NetworkAccess.Connect, TransportType.All, "192.168.144.238", SocketPermission.AllPorts)
        
        'Second 'SocketPermission' ip-address is '192.168.144.239' for 'All' transport types and for 'All' ports for the ip-address.
        socketPermission3.AddPermission(NetworkAccess.Connect, TransportType.All, "192.168.144.239", SocketPermission.AllPorts)
        
        Console.WriteLine("Displays the result of AddPermission method : " + ControlChars.Cr)
        Console.WriteLine(socketPermission3.ToString())
        
        'Find the intersection between two 'SocketPermission' objects.
        socketPermission1 = CType(socketPermission2.Intersect(socketPermission3), SocketPermission)
        
        Console.WriteLine("Displays the result of Intersect method :" + ControlChars.Cr + " ")
        Console.WriteLine(socketPermission1.ToString())
        'Demand that the calling method have the requsite socket permission.
        socketPermission1.Demand()
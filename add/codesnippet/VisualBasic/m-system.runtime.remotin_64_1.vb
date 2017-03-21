      ' Create an instance of ServicedComponentProxy
      Public Overrides Function CreateInstance(serverType As Type) As MarshalByRefObject
         Return MyBase.CreateInstance(serverType)
      End Function 'CreateInstance
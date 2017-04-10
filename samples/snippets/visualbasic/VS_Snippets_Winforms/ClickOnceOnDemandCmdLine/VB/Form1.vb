'<SNIPPET1>
Imports System
Imports System.Windows.Forms
Imports System.Deployment.Application
Imports System.Drawing
Imports System.Reflection
Imports System.Collections.Generic
Imports Microsoft.Samples.ClickOnceOnDemand


Namespace Microsoft.Samples.ClickOnceOnDemand
   <System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand, Unrestricted:=true)> _
   Class Form1
      Inherits Form

        ' Maintain a dictionary mapping DLL names to download file groups. This is trivial for this sample,
        ' but will be important in real-world applications where a feature is spread across multiple DLLs,
        ' and you want to download all DLLs for that feature in one shot. 
        Dim DllMapping as Dictionary(Of String, String) = new Dictionary(of String, String)()

      Public Sub New()
         ' Add button to form.
            Dim GetAssemblyButton As New Button()
            GetAssemblyButton.Location = New Point(100, 100)
            GetAssemblyButton.Text = "Get assembly on demand"
            AddHandler GetAssemblyButton.Click, AddressOf GetAssemblyButton_Click
      
            Me.Controls.Add(GetAssemblyButton)

            DllMapping("ClickOnceLibrary") = "ClickOnceLibrary"
            AddHandler AppDomain.CurrentDomain.AssemblyResolve, AddressOf CurrentDomain_AssemblyResolve
      End Sub
   
        <STAThread()> _
        Shared Sub Main()
            Application.EnableVisualStyles()
            Application.Run(New Form1())
        End Sub

        Private Function CurrentDomain_AssemblyResolve(ByVal sender As Object, ByVal args As ResolveEventArgs) As Assembly
            If ApplicationDeployment.IsNetworkDeployed Then
                Dim deploy As ApplicationDeployment = ApplicationDeployment.CurrentDeployment

                ' Get the DLL name from the Name argument.
                Dim nameParts() as String = args.Name.Split(",")
                Dim dllName as String = nameParts(0)
		Dim downloadGroupName as String = DllMapping(dllName)

                Try
                    deploy.DownloadFileGroup(downloadGroupName)
                Catch de As DeploymentException

                End Try

                ' Load the assembly.
                Dim newAssembly As Assembly = Nothing

                Try
                    newAssembly = Assembly.LoadFile(Application.StartupPath & "\\" & dllName & ".dll," & _  
			"Version=1.0.0.0, Culture=en, PublicKeyToken=03689116d3a4ae33")
                Catch ex As Exception
                    MessageBox.Show("Could not download assembly on demand.")
                End Try

                CurrentDomain_AssemblyResolve = newAssembly
            Else
                CurrentDomain_AssemblyResolve = Nothing
            End If
        End Function

        Private Sub GetAssemblyButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim ourClass As New DynamicClass()
            MessageBox.Show("DynamicClass string is: " + ourClass.Message)
        End Sub
    End Class
End Namespace
'</SNIPPET1>
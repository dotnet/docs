Imports System.IO
Imports System.Deployment.Application

Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        '<SNIPPET1>
        If (ApplicationDeployment.IsNetworkDeployed) Then
            Dim SR As StreamReader = Nothing

            Try
                SR = New StreamReader(ApplicationDeployment.CurrentDeployment.DataDirectory & "\CSV.txt")
                MessageBox.Show(SR.ReadToEnd())
            Catch Ex As Exception
                MessageBox.Show("Could not read file.")
            Finally
                SR.Close()
            End Try
        End If
        '</SNIPPET1>
    End Sub
End Class

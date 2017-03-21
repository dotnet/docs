' Create a method to disable SqlCacheDependency
' change notifications for the Northwind database.
Public Sub DisableDatabase_Click( _
 sender As Object, e As System.EventArgs)

   SqlCacheDependencyAdmin.DisableNotifications( _
   "Northwind")
   Response.Write("Northwind database disabled at " _
   & DateTime.Now.ToString())

   ' An HttpException is thrown if adequate permissions to
   ' modify the database are not granted.

End Sub
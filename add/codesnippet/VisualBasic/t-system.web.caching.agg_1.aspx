    ' When the page is loaded, use the 
    ' AggregateCacheDependency class to make 
    ' a cached item dependent on two files.
    
    Sub Page_Load(sender As Object, e As EventArgs)
       Dim Source As DataView
    
       Source = Cache("XMLDataSet")
    
       If Source Is Nothing
              Dim DS As New DataSet
              Dim FS As FileStream
              Dim Reader As StreamReader
              Dim txtDep As CacheDependency
              Dim xmlDep As CacheDependency
              Dim aggDep As AggregateCacheDependency
    
    
              FS = New FileStream(Server.MapPath("authors.xml"),FileMode.Open,FileAccess.Read)
              Reader = New StreamReader(FS)
              DS.ReadXml(Reader)
              FS.Close()
    
              Source = new DataView(ds.Tables(0))
             ' Create two CacheDependency objects, one to a
             ' text file and the other to an XML file. 
             ' Create a CacheDependency array with these 
             ' two objects as items in the array.
              txtDep = New CacheDependency(Server.MapPath("Storage.txt"))
              xmlDep = New CacheDependency(Server.MapPath("authors.xml"))
              Dim DepArray() As CacheDependency = {txtDep, xmlDep}

              ' Create an AggregateCacheDependency object and 
              ' use the Add method to add the array to it.   
              aggDep = New AggregateCacheDependency()
              aggDep.Add(DepArray)
    
              ' Call the GetUniqueId method to generate
              ' an ID for each dependency in the array.
              msg1.Text = aggDep.GetUniqueId()
              
              ' Add the new data set to the cache with 
              ' dependencies on both files in the array.
              Cache.Insert("XMLDataSet", Source, aggDep)
              If aggDep.HasChanged = True Then
                 chngMsg.Text = "The dependency changed at: " & DateTime.Now
    
              Else
                 chngMsg.Text = "The dependency changed last at: " & aggDep.UtcLastModified.ToString()
              End If

    
              cacheMsg1.Text = "Dataset created explicitly"
            Else
              cacheMsg1.Text = "Dataset retrieved from cache"
            End If
    
    
              MyLiteral.Text = Source.Table.TableName
              MyDataGrid.DataSource = Source
              MyDataGrid.DataBind()
          End Sub
  
 
          Public Sub btn_Click(sender As Object, e As EventArgs )
    
           If (MyTextBox.Text = String.Empty) Then
              msg2.Text ="You have not changed the text file."
           Else
              msg2.Text="You added " & MyTextBox.Text & "."
    
              ' Create an instance of the StreamWriter class
              ' to write text to a file.
              Dim sw As StreamWriter
              sw = File.CreateText(Server.MapPath("Storage.txt"))
    
              ' Add some text to the file.
              sw.Write("You entered:")
              sw.WriteLine(MyTextBox.Text)
    
              ' Write arbitrary objects to the file as needed.
              sw.Write("Text added at:")
              sw.WriteLine(DateTime.Now)
              sw.WriteLine("-------------------")
              sw.Close()
           End If
         End Sub
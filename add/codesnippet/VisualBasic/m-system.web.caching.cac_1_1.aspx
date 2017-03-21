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
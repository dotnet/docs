' <Snippet0>
Imports System
Imports System.ServiceModel.Syndication
Imports System.Collections.Generic
imports System.Collections.ObjectModel


Module Program

    Sub Main()
        Dim myFeed As New SyndicationFeed("My Test Feed", _
                                                     "This is a test feed", _
                                                     New Uri("http://FeedServer/Test"), "MyFeedId", DateTime.Now)
        Dim myItem As New SyndicationItem("Item One Title", _
                                                     "Item One Content", _
                                                     New Uri("http://FeedServer/Test/ItemOne"))
        myItem.Categories.Add(New SyndicationCategory("MyCategory"))
        Dim items As New Collection(Of SyndicationItem)()
        items.Add(myItem)
        myFeed.Items = items
    End Sub

End Module
' </Snippet0>
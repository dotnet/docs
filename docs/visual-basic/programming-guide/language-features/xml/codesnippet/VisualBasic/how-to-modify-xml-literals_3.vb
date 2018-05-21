    Dim vbBook = From book In catalog.<Catalog>.<Book> 
                 Where book.<Title>.Value = 
                   "Developing Applications with Visual Basic .NET"

    vbBook(0).AddFirst(<Publisher>Microsoft Press</Publisher>)

    vbBook(0).Add(<PublishDate>2005-2-14</PublishDate>)

    vbBook(0).AddAfterSelf(<Book id="bk999"></Book>)

    vbBook(0).AddBeforeSelf(<Book id="bk000"></Book>)
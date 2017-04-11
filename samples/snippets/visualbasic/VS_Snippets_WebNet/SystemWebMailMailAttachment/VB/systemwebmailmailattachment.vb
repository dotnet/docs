Imports System
Imports System.Web.Mail

Namespace MyNameSpace
Module Module1
   Public Sub Main()
      '<Snippet1>
      'This example shows how to programmatically add attachments 
      'to a mail lessage.

      Dim MyMail As MailMessage = New MailMessage()
      Dim iLoop1 As integer
  
      ' Concatenate a list of attachment files in a string.
      Dim sAttach As String = "C:\images\image1.jpg,C:\images\image2.jpg,C:\images\image3.jpg"
 
      ' Build an IList of mail attachments using the files named in the string.
      Dim delim As Char = ","
      Dim sSubstr As String
      For Each sSubstr in sAttach.Split(delim)
         Dim myAttachment As MailAttachment = New MailAttachment(sSubstr)
         myMail.Attachments.Add(myAttachment)
      Next
      '</Snippet1>
   End Sub
End Module
End Namespace
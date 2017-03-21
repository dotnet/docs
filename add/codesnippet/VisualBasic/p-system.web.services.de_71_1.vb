         ' Create an OutputBinding.
         Dim myOutputBinding As New OutputBinding()

         ' Create a MimeTextBinding.
         Dim myMimeTextBinding As New MimeTextBinding()

         ' Create a MimeTextMatch.
         Dim myMimeTextMatch As New MimeTextMatch()
         Dim myMimeTextMatchCollection As MimeTextMatchCollection

         ' Initialize properties of the MimeTextMatch.
         myMimeTextMatch.Name = "Title"
         myMimeTextMatch.Type = "*/*"
         myMimeTextMatch.Pattern = "'TITLE&gt;(.*?)&lt;"
         myMimeTextMatch.IgnoreCase = True

         ' Initialize a MimeTextMatchCollection.
         myMimeTextMatchCollection = myMimeTextBinding.Matches

         ' Add the MimeTextMatch to the MimeTextMatchCollection.
         myMimeTextMatchCollection.Add(myMimeTextMatch)
         myOutputBinding.Extensions.Add(myMimeTextBinding)

         ' Add the OutputBinding to the OperationBinding.
         myOperationBinding.Output = myOutputBinding
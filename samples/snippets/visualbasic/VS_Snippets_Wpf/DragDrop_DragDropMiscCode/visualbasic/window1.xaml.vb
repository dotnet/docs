Imports System.Text

Namespace DragDropMiscCode
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window
		Public Sub New()
			InitializeComponent()
			Dim utf8DataFormat As String = GetType(String).FullName

			ClipboardMethods()
		End Sub

		' Various ways to create a data object...
		Private Sub CreateDataObject()
            ' Create a new data object using simple constructor; data format is chosen automatically.
            With True
                ' <Snippet_DragDrop_CreateDataObject_Simple>
                Dim stringData As String = "Some string data to store..."
                Dim dataObject As New DataObject(stringData)
                ' </Snippet_DragDrop_CreateDataObject_Simple>
            End With

            With True
                ' <Snippet_DragDrop_CreateDataObject_Simple_Condensed>
                Dim dataObject As New DataObject("Some string data to store...")
                ' </Snippet_DragDrop_CreateDataObject_Simple_Condensed>
            End With

            ' Create a new data object using constructor, specifying data format via string (provided by DataFormats).
            With True
                ' <Snippet_DragDrop_CreateDataObject_TypeString>
                Dim stringData As String = "Some string data to store..."
                Dim dataFormat As String = DataFormats.UnicodeText
                Dim dataObject As New DataObject(dataFormat, stringData)
                ' </Snippet_DragDrop_CreateDataObject_TypeString>
            End With

            With True
                ' <Snippet_DragDrop_CreateDataObject_TypeString_Condensed>
                Dim dataObject As New DataObject(DataFormats.UnicodeText, "Some string data to store...")
                ' </Snippet_DragDrop_CreateDataObject_TypeString_Condensed>
            End With

            ' Create a new data object using constructor, specifying data format via type.
            With True
                ' <Snippet_DragDrop_CreateDataObject_Type>
                Dim stringData As String = "Some string data to store..."
                Dim dataFormat As Type = stringData.GetType()
                Dim dataObject As New DataObject(dataFormat, stringData)
                ' </Snippet_DragDrop_CreateDataObject_Type>
            End With

            With True
                ' <Snippet_DragDrop_CreateDataObject_Type_Condensed>
                Dim dataObject As New DataObject("".GetType(), "Some string data to store...")
                ' </Snippet_DragDrop_CreateDataObject_Type_Condensed>
            End With

            ' Create a new data object using constructor, no autoconvert.
            With True
                ' <Snippet_DragDrop_CreateDataObject_AutoConvert>
                Dim stringData As String = "Some string data to store..."
                Dim dataFormat As String = DataFormats.Text
                Dim autoConvert As Boolean = False
                Dim dataObject As New DataObject(dataFormat, stringData, autoConvert)
                ' </Snippet_DragDrop_CreateDataObject_AutoConvert>
            End With

            With True
                ' <Snippet_DragDrop_CreateDataObject_AutoConvert_Condensed>
                Dim dataObject As New DataObject(DataFormats.Text, "Some string data to store...", False)
                ' </Snippet_DragDrop_CreateDataObject_AutoConvert_Condensed>
            End With

		End Sub

		Private Sub StoreMultipleFormats()
			' Storing a few differnet text encodings in a data object...
				' <Snippet_DragDrop_StoreMultipleFormats>
				Dim dataObject As New DataObject()
				Dim sourceData As String = "Some string data to store..."

				' Encode the source string into Unicode byte arrays.
				Dim unicodeText() As Byte = Encoding.Unicode.GetBytes(sourceData) ' UTF-16
				Dim utf8Text() As Byte = Encoding.UTF8.GetBytes(sourceData)
				Dim utf32Text() As Byte = Encoding.UTF32.GetBytes(sourceData)

				' The DataFormats class does not provide data format fields for denoting
				' UTF-32 and UTF-8, which are seldom used in practice; the following strings 
				' will be used to identify these "custom" data formats.
				Dim utf32DataFormat As String = "UTF-32"
				Dim utf8DataFormat As String = "UTF-8"

				' Store the text in the data object, letting the data object choose
				' the data format (which will be DataFormats.Text in this case).
				dataObject.SetData(sourceData)
				' Store the Unicode text in the data object.  Text data can be automatically
				' converted to Unicode (UTF-16 / UCS-2) format on extraction from the data object; 
				' Therefore, explicitly converting the source text to Unicode is generally unnecessary, and
				' is done here as an exercise only.
				dataObject.SetData(DataFormats.UnicodeText, unicodeText)
				' Store the UTF-8 text in the data object...
				dataObject.SetData(utf8DataFormat, utf8Text)
				' Store the UTF-32 text in the data object...
				dataObject.SetData(utf32DataFormat, utf32Text)
				' </Snippet_DragDrop_StoreMultipleFormats>
		End Sub

		Private Sub QueryDataFormats()
            ' Querying for data formats with GetDataPresent...
            With True
                ' <Snippet_DragDrop_QueryDataFormats_String>
                Dim dataObject As New DataObject("Some string data to store...")

                ' Query for the presence of Text data in the data object, by a data format descriptor string.
                ' In this overload of GetDataPresent, the method will return true both for native data formats
                ' and when the data can automatically be converted to the specifed format.

                ' In this case, string data is present natively, so GetDataPresent returns "true".
                Dim textData As String = Nothing
                If dataObject.GetDataPresent(DataFormats.StringFormat) Then
                    textData = TryCast(dataObject.GetData(DataFormats.StringFormat), String)
                End If

                ' In this case, the Text data in the data object can be autoconverted to 
                ' Unicode text, so GetDataPresent returns "true".
                Dim unicodeData() As Byte = Nothing
                If dataObject.GetDataPresent(DataFormats.UnicodeText) Then
                    unicodeData = TryCast(dataObject.GetData(DataFormats.UnicodeText), Byte())
                End If
                ' </Snippet_DragDrop_QueryDataFormats_String>
            End With

            With True
                ' <Snippet_DragDrop_QueryDataFormats_Type>
                Dim dataObject As New DataObject("Some string data to store...")

                ' Query for the presence of String data in the data object, by type.  In this overload 
                ' of GetDataPresent, the method will return true both for native data formats
                ' and when the data can automatically be converted to the specifed format.

                ' In this case, the Text data present in the data object can be autoconverted
                ' to type string (also represented by DataFormats.String), so GetDataPresent returns "true".
                Dim stringData As String = Nothing
                If dataObject.GetDataPresent(GetType(String)) Then
                    stringData = TryCast(dataObject.GetData(DataFormats.Text), String)
                End If
                ' </Snippet_DragDrop_QueryDataFormats_Type>
            End With

            With True
                ' <Snippet_DragDrop_QueryDataFormats_Autoconvert>
                Dim dataObject As New DataObject("Some string data to store...")

                ' Query for the presence of Text data in the data object, by data format descriptor string,
                ' and specifying whether auto-convertible data formats are acceptable.  

                ' In this case, Text data is present natively, so GetDataPresent returns "true".
                Dim textData As String = Nothing
                If dataObject.GetDataPresent(DataFormats.Text, False) Then ' Auto-convert? 
                    textData = TryCast(dataObject.GetData(DataFormats.Text), String)
                End If

                ' In this case, the Text data in the data object can be autoconverted to 
                ' Unicode text, but it is not available natively, so GetDataPresent returns "false".
                Dim unicodeData() As Byte = Nothing
                If dataObject.GetDataPresent(DataFormats.UnicodeText, False) Then ' Auto-convert? 
                    unicodeData = TryCast(dataObject.GetData(DataFormats.UnicodeText), Byte())
                End If

                ' In this case, the Text data in the data object can be autoconverted to 
                ' Unicode text, so GetDataPresent returns "true".
                If dataObject.GetDataPresent(DataFormats.UnicodeText, True) Then ' Auto-convert? 
                    unicodeData = TryCast(dataObject.GetData(DataFormats.UnicodeText), Byte())
                End If
                ' </Snippet_DragDrop_QueryDataFormats_Autoconvert>
            End With

		End Sub

        Private Sub GetAllDataFormats()
            With True
                ' <Snippet_DragDrop_GetAllDataFormats>
                Dim dataObject As New DataObject("Some string data to store...")

                ' Get an array of strings, each string denoting a data format
                ' that is available in the data object.  This overload of GetDataFormats
                ' returns all available data formats, native and auto-convertible.
                Dim dataFormats() As String = dataObject.GetFormats()

                ' Get the number of data formats present in the data object, including both
                ' auto-convertible and native data formats.
                Dim numberOfDataFormats As Integer = dataFormats.Length

                ' To enumerate the resulting array of data formats, and take some action when
                ' a particular data format is found, use a code structure similar to the following.
                For Each dataFormat As String In dataFormats
                    If dataFormat = System.Windows.DataFormats.Text Then
                        ' Take some action if/when data in the Text data format is found.
                        Exit For
                    ElseIf dataFormat = System.Windows.DataFormats.StringFormat Then
                        ' Take some action if/when data in the string data format is found.
                        Exit For
                    End If
                Next dataFormat
                ' </Snippet_DragDrop_GetAllDataFormats>
            End With

            With True
                ' <Snippet_DragDrop_GetAllDataFormats_NativeOnly>
                Dim dataObject As New DataObject("Some string data to store...")

                ' Get an array of strings, each string denoting a data format
                ' that is available in the data object.  This overload of GetDataFormats
                ' accepts a Boolean parameter inidcating whether to include auto-convertible
                ' data formats, or only return native data formats.
                Dim dataFormats() As String = dataObject.GetFormats(False) ' Include auto-convertible? 

                ' Get the number of native data formats present in the data object.
                Dim numberOfDataFormats As Integer = dataFormats.Length

                ' To enumerate the resulting array of data formats, and take some action when
                ' a particular data format is found, use a code structure similar to the following.
                For Each dataFormat As String In dataFormats
                    If dataFormat = System.Windows.DataFormats.Text Then
                        ' Take some action if/when data in the Text data format is found.
                        Exit For
                    End If
                Next dataFormat
                ' </Snippet_DragDrop_GetAllDataFormats_NativeOnly>
            End With

        End Sub

        Private Sub GetSpecificDataFormat()

            With True
                ' <Snippet_DragDrop_GetSpecificDataFormat>
                Dim dataObject As New DataObject("Some string data to store...")

                Dim desiredFormat As String = DataFormats.UnicodeText
                Dim data() As Byte = Nothing

                ' Use the GetDataPresent method to check for the presence of a desired data format.
                ' This particular overload of GetDataPresent looks for both native and auto-convertible 
                ' data formats.
                If dataObject.GetDataPresent(desiredFormat) Then
                    ' If the desired data format is present, use one of the GetData methods to retrieve the
                    ' data from the data object.
                    data = TryCast(dataObject.GetData(desiredFormat), Byte())
                End If
                ' </Snippet_DragDrop_GetSpecificDataFormat>
            End With

            With True
                ' <Snippet_DragDrop_GetSpecificDataFormat_Native>
                Dim dataObject As New DataObject("Some string data to store...")

                Dim desiredFormat As String = DataFormats.UnicodeText
                Dim noAutoConvert As Boolean = False
                Dim data() As Byte = Nothing

                ' Use the GetDataPresent method to check for the presence of a desired data format.
                ' The autoconvert parameter is set to false to filter out auto-convertible data formats,
                ' returning true only if the specified data format is available natively.
                If dataObject.GetDataPresent(desiredFormat, noAutoConvert) Then
                    ' If the desired data format is present, use one of the GetData methods to retrieve the
                    ' data from the data object.
                    data = TryCast(dataObject.GetData(desiredFormat), Byte())
                End If
                ' </Snippet_DragDrop_GetSpecificDataFormat_Native>
            End With

        End Sub

		Private Sub ehDragEnter(ByVal sender As Object, ByVal args As DragEventArgs)
			' Code here will fire when the DragEnter event occurs.
		End Sub
		Private Sub ehDragLeave(ByVal sender As Object, ByVal args As DragEventArgs)
			' Code here will fire when the DragEnter event occurs.
		End Sub
		Private Sub ehDragOver(ByVal sender As Object, ByVal args As DragEventArgs)
			' Code here will fire when the DragEnter event occurs.
		End Sub
		Private Sub ehDrop(ByVal sender As Object, ByVal args As DragEventArgs)
			' Code here will fire when the DragEnter event occurs.
		End Sub
		Private Sub ehPreviewDragEnter(ByVal sender As Object, ByVal args As DragEventArgs)
			' Code here will fire when the DragEnter event occurs.
		End Sub
		Private Sub ehPreviewDragLeave(ByVal sender As Object, ByVal args As DragEventArgs)
			' Code here will fire when the DragEnter event occurs.
		End Sub
		Private Sub ehPreviewDragOver(ByVal sender As Object, ByVal args As DragEventArgs)
			' Code here will fire when the DragEnter event occurs.
		End Sub
		Private Sub ehPreviewDrop(ByVal sender As Object, ByVal args As DragEventArgs)
			' Code here will fire when the DragEnter event occurs.
		End Sub

		Private Sub ClipboardMethods()
            Dim persistentData As Boolean = False
            With True
                ' <Snippet_ContainsDataGetData>

                ' After this line executes, IsHTMLDataOnClipboard will be true if
                ' HTML data is available natively on the clipboard; if not, it 
                ' will be false.
                Dim IsHTMLDataOnClipboard As Boolean = Clipboard.ContainsData(DataFormats.Html)

                ' If there is HTML data on the clipboard, retrieve it.
                Dim htmlData As String
                If IsHTMLDataOnClipboard Then

                    htmlData = Clipboard.GetText(TextDataFormat.Html)

                End If

                ' </Snippet_ContainsDataGetData>
            End With

            With True
                ' <Snippet_SetData>
                ' For this example, the data to be placed on the clipboard is a simple
                ' string.
                Dim textData As String = "I want to put this string on the clipboard."

                ' After this call, the data (string) is placed on the clipboard and tagged
                ' with a data format of "Text".
                Clipboard.SetData(DataFormats.Text, CType(textData, Object))
                ' </Snippet_SetData>
            End With

            With True
                ' <Snippet_SetDataObjectIsCurrent>

                ' For this example, the data to be placed on the clipboard is a simple
                ' string.
                Dim textData As String = "I want to put this string on the clipboard."
                ' The example will enable auto-conversion of data for this data object.
                Dim autoConvert As Boolean = True

                ' Create a new data object, specifying the data format, data to encapsulate, and enabling
                ' auto-conversion services.
                Dim data As New DataObject(DataFormats.UnicodeText, CType(textData, Object), autoConvert)

                ' If the data to be copied is supposed to be persisted after the application ends, 
                ' then set the second parameter of SetDataObject to true.
                If persistentData Then
                    ' Place the persisted data on the clipboard.
                    Clipboard.SetDataObject(data, True)
                Else
                    ' Place the non-persisted data on the clipboard.
                    Clipboard.SetDataObject(data, False)
                End If

                ' If you keep a copy of the source data object, you can use the IsCurrent method to see if
                ' the data object is still on the clipboard.
                Dim isOriginalDataObject As Boolean = Clipboard.IsCurrent(data)
                ' </Snippet_SetDataObjectIsCurrent>
            End With
        End Sub

	End Class
End Namespace
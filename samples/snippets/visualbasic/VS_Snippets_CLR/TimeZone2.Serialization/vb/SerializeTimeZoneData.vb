' <Snippet2>
Imports System.Globalization
Imports System.IO
Imports System.Reflection
Imports System.Resources
' </Snippet2>

Module SerializeTimeZoneData
   Private Const resxName As String = "SerializedTimeZones.resx"

   Sub Main()
      If MsgBox("Serialize time zones?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
         SerializeTimeZones()
      End If
      If MsgBox("Deserialize time zones?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
         DeserializeTimeZones()
      End If
   End Sub

   ' <Snippet1>
   Private Sub SerializeTimeZones()
      Dim writeStream As TextWriter
      Dim resources As New Dictionary(Of String, String)
      ' Determine if .resx file exists
      If File.Exists(resxName) Then
         ' Open reader
         Dim readStream As TextReader = New StreamReader(resxName)
         Dim resReader As New ResXResourceReader(readStream)
         For Each item As DictionaryEntry In resReader
            If Not (CStr(item.Key) = "CentralStandardTime" Or _
                    CStr(item.Key) = "PalmerStandardTime") Then
               resources.Add(CStr(item.Key), CStr(item.Value))
            End If
         Next
         readStream.Close()
         ' Delete file, since write method creates duplicate xml headers
         File.Delete(resxName)
      End If

      ' Open stream to write to .resx file
      Try
         writeStream = New StreamWriter(resxName, True)
      Catch e As FileNotFoundException
         ' Handle failure to find file
         Console.WriteLine("{0}: The file {1} could not be found.", e.GetType().Name, resxName)
         Exit Sub
      End Try

      ' Get resource writer
      Dim resWriter As ResXResourceWriter = New ResXResourceWriter(writeStream)

      ' Add resources from existing file
      For Each item As KeyValuePair(Of String, String) In resources
         resWriter.AddResource(item.Key, item.Value)
      Next
      ' Serialize Central Standard Time
      Try
         Dim cst As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time")
         resWriter.AddResource(cst.Id.Replace(" ", String.Empty), cst.ToSerializedString())
      Catch
         Console.WriteLine("The Central Standard Time zone could not be found.")
      End Try

      ' Create time zone for Palmer, Antarctica
      '
      ' Define transition times to/from DST
      Dim startTransition As TimeZoneInfo.TransitionTime = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(#4:00:00 AM#, 10, 2, DayOfWeek.Sunday)
      Dim endTransition As TimeZoneInfo.TransitionTime = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(#3:00:00 AM#, 3, 2, DayOfWeek.Sunday)
      ' Define adjustment rule
      Dim delta As TimeSpan = New TimeSpan(1, 0, 0)
      Dim adjustment As TimeZoneInfo.AdjustmentRule = TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(#10/1/1999#, Date.MaxValue.Date, delta, startTransition, endTransition)
      ' Create array for adjustment rules
      Dim adjustments() As TimeZoneInfo.AdjustmentRule = {adjustment}
      ' Define other custom time zone arguments
      Dim DisplayName As String = "(GMT-04:00) Antarctica/Palmer Time"
      Dim standardName As String = "Palmer Standard Time"
      Dim daylightName As String = "Palmer Daylight Time"
      Dim offset As TimeSpan = New TimeSpan(-4, 0, 0)
      Dim palmer As TimeZoneInfo = TimeZoneInfo.CreateCustomTimeZone(standardName, offset, DisplayName, standardName, daylightName, adjustments)
      resWriter.AddResource(palmer.Id.Replace(" ", String.Empty), palmer.ToSerializedString())

      ' Save changes to .resx file 
      resWriter.Generate()
      resWriter.Close()
      writeStream.Close()
   End Sub
   ' </Snippet1>

   ' <Snippet3>
   Private Sub DeserializeTimeZones()
      Dim cst, palmer As TimeZoneInfo
      Dim timeZoneString As String
      Dim resMgr As ResourceManager = New ResourceManager("SerializeTimeZoneData.SerializedTimeZones",
                                      GetType(SerializeTimeZoneData).Assembly)

      ' Attempt to retrieve time zone from system
      Try
         cst = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time")
      Catch ex As TimeZoneNotFoundException
         ' Time zone not in system; retrieve from resource
         timeZoneString = resMgr.GetString("CentralStandardTime")
         If Not String.IsNullOrEmpty(timeZoneString) Then
            cst = TimeZoneInfo.FromSerializedString(timeZoneString)
         Else
            MsgBox("Unable to create Central Standard Time Zone. Application must exit.")
            Exit Sub
         End If
      End Try
      ' Retrieve custom time zone
      Try
         timeZoneString = resMgr.GetString("PalmerStandardTime")
         palmer = TimeZoneInfo.FromSerializedString(timeZoneString)
      Catch ex As Exception
         MsgBox(ex.GetType().Name & ": Unable to create Palmer Standard Time Zone. Application must exit.")
         Exit Sub
      End Try
   End Sub
   ' </Snippet3>
End Module

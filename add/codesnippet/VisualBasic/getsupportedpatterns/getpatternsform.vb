Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Windows.Automation
Imports System.Diagnostics

Namespace GetSupportedPatterns
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub btnBegin_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBegin.Click
			ListPatterns()
		End Sub

		Private Sub btnProps_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnProps.Click
			ListRequiredProperties()
		End Sub

		''' <summary>
		''' Outputs the patterns supported, and never supported, by all control types.
		''' Control types are obtained through reflection.
		''' </summary>
		Private Sub oldListPatterns()
			Dim patternsNeverSupported() As AutomationPattern
			Dim patternsSupported()() As AutomationPattern

			Dim controlTypeInstance As ControlType = ControlType.Button ' Any instance will do.
			Dim type As Type = GetType(ControlType)
			Dim arrayInfo() As System.Reflection.FieldInfo = type.GetFields()
			For Each info As System.Reflection.FieldInfo In arrayInfo
				If info.IsStatic Then
					Dim controlType As ControlType = TryCast(info.GetValue(controlTypeInstance), ControlType)
					Debug.WriteLine(vbLf & "********************")
					Debug.WriteLine(controlType.ProgrammaticName)
					Debug.WriteLine("Never supports:")
					patternsNeverSupported = controlType.GetNeverSupportedPatterns()
					If patternsNeverSupported.GetLength(0) = 0 Then
						Debug.WriteLine("(None)")
					Else
						For Each pattern As AutomationPattern In patternsNeverSupported
							Debug.WriteLine(pattern.ProgrammaticName)
						Next pattern
					End If
					Debug.WriteLine(vbLf & "Requires one of the following sets:")
					patternsSupported = controlType.GetRequiredPatternSets()
					If patternsSupported.GetLength(0) = 0 Then
						Debug.WriteLine("(None)")
					Else
						For Each patternSet As AutomationPattern() In patternsSupported
							Debug.WriteLine("Pattern set:")
							For Each requiredPattern As AutomationPattern In patternSet
								Debug.WriteLine(requiredPattern.ProgrammaticName)
							Next requiredPattern
							Debug.WriteLine("--------------------")
						Next patternSet
					End If
				End If
			Next info
		End Sub

		' <Snippet101>
		''' <summary>
		''' Obtains information about patterns supported by control types.
		''' Control types are obtained by reflection.
		''' </summary>
		Private Sub ListPatterns()
			' Any instance of a ControlType will do since we just want to get the type.
			Dim controlTypeInstance As ControlType = ControlType.Button
			Dim type As Type = GetType(ControlType)
			Dim fields() As System.Reflection.FieldInfo = type.GetFields()
			For Each field As System.Reflection.FieldInfo In fields
				If field.IsStatic Then
					Dim controlType As ControlType = TryCast(field.GetValue(controlTypeInstance), ControlType)
					Console.WriteLine(vbLf & "******************** {0} never supports:", controlType.ProgrammaticName)
					Dim neverSupportedPatterns() As AutomationPattern = controlType.GetNeverSupportedPatterns()
					If neverSupportedPatterns.Length = 0 Then
						Console.WriteLine("(None)")
					Else
						For Each pattern As AutomationPattern In neverSupportedPatterns
							Console.WriteLine(pattern.ProgrammaticName)
						Next pattern
					End If

					Console.WriteLine(vbLf & "******************** {0} requires:", controlType.ProgrammaticName)
					Dim requiredPatternSets()() As AutomationPattern = controlType.GetRequiredPatternSets()
					If requiredPatternSets.Length = 0 Then
						Console.WriteLine("(None)")
					Else
						For Each patterns As AutomationPattern() In requiredPatternSets
							Console.WriteLine("Pattern set:")
							For Each pattern As AutomationPattern In patterns
								Console.WriteLine(pattern.ProgrammaticName)
							Next pattern
							Console.WriteLine("--------------------")
						Next patterns
					End If
				End If
			Next field
		End Sub
		' </Snippet101>

 ' NOTHING GETS RETURNED FROM THE FOLLOWING       
		' <Snippet102>
		Private Sub ListRequiredProperties()
			Dim propertiesRequired() As AutomationProperty

			' Get any ControlType instance.
			Dim controlTypeInstance As ControlType = ControlType.Button
			Dim type As Type = GetType(ControlType)
			Dim fields() As System.Reflection.FieldInfo = type.GetFields()
			For Each field As System.Reflection.FieldInfo In fields
				If field.IsStatic Then
					Dim controlType As ControlType = TryCast(field.GetValue(controlTypeInstance), ControlType)
					Debug.WriteLine(vbLf & "********************")
					Debug.WriteLine(controlType.ProgrammaticName)
					Debug.WriteLine("Required properties:")
					propertiesRequired = controlType.GetRequiredProperties()
					If propertiesRequired.GetLength(0) = 0 Then
						Debug.WriteLine("(None)")
					Else
						For Each prop As AutomationProperty In propertiesRequired
						Debug.WriteLine(prop.ProgrammaticName)
						Next prop
					End If
				End If
			Next field
' </Snippet102>
		End Sub

	End Class









End Namespace
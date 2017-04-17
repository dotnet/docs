 '*****************************************************************************
' *
' * File: ElementStore.cs
' *
' * Description: Storage class for record and playback.
' * 
' * See FindByAutomationID.xaml.cs for a full description of this sample.
' *   
' * 
' *  This file is part of the Microsoft WinfFX SDK Code Samples.
' * 
' *  Copyright (C) Microsoft Corporation.  All rights reserved.
' * 
' * This source code is intended only as a supplement to Microsoft
' * Development Tools and/or on-line documentation.  See these other
' * materials for detailed information regarding Microsoft code samples.
' * 
' * THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
' * KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
' * IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
' * PARTICULAR PURPOSE.
' * 
' ****************************************************************************

Imports System.Windows.Automation
Imports System



Public Class ElementStore

    ''' <summary>
    ''' Stores and retrieves the AutomationElementInformation.AutomationID 
    ''' of the current automation element.
    ''' </summary>    
    Public Property AutomationID() As String
        Get
            Return currentAutomationID
        End Get
        Set(ByVal value As String)
            currentAutomationID = value
        End Set
    End Property
    Private currentAutomationID As String


    ''' <summary>
    ''' Stores and retrieves the AutomationElementInformation.Name 
    ''' of the current automation element.
    ''' </summary>
    Public Property Name() As String
        Get
            Return currentControlName
        End Get
        Set(ByVal value As String)
            currentControlName = value
        End Set
    End Property
    Private currentControlName As String

    ''' <summary>
    ''' Stores and retrieves the AutomationElementInformation.ClassName 
    ''' of the current automation element.
    ''' </summary>
    Public Property ClassName() As String
        Get
            Return currentClassName
        End Get
        Set(ByVal value As String)
            currentClassName = value
        End Set
    End Property
    Private currentClassName As String

    ''' <summary>
    ''' Stores and retrieves the 
    ''' AutomationElementInformation.ControlType.ProgrammaticName 
    ''' of the current automation element.
    ''' </summary>
    Public Property ControlType() As String
        Get
            Return currentControlType
        End Get
        Set(ByVal value As String)
            currentControlType = value
        End Set
    End Property
    Private currentControlType As String

    ''' <summary>
    ''' Stores and retrieves the string name equivalent of the event ID 
    ''' the current automation element is reporting.
    ''' </summary>
    Public Property EventID() As String
        Get
            Return currentEventID
        End Get
        Set(ByVal value As String)
            currentEventID = value
        End Set
    End Property
    Private currentEventID As String

    ''' <summary>
    ''' Stores and retrieves the time of an event.
    ''' </summary>
    Public Property EventTime() As DateTime
        Get
            Return currentEventTime
        End Get
        Set(ByVal value As DateTime)
            currentEventTime = value
        End Set
    End Property
    Private currentEventTime As DateTime

    ''' <summary>
    ''' Stores and retrieves the an array of supported Automation Patterns 
    ''' for the current automation element.
    ''' </summary>

    Public Property SupportedPatterns() As AutomationPattern()
        Get
            Return currentSupportedPatterns
        End Get
        Set(ByVal value As AutomationPattern())
            currentSupportedPatterns = value
        End Set
    End Property
    Private currentSupportedPatterns() As AutomationPattern
End Class 'ElementStore
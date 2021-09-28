 '******************************************************************************
' * File: ClientFormDesigner.cs
' * 
' * Description: Definitions of form elements.
' *
' * See ClientForm.cs for a full description of the sample.
' *      
' * 
' *  This file is part of the Microsoft Windows SDK Code Samples.
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
' *****************************************************************************

Partial Class ClientForm
    Inherits Form

    ''' <summary>
    ''' Required designer variable.
    ''' </summary>
    Private components As System.ComponentModel.IContainer = Nothing


    ''' <summary>
    ''' Clean up any resources being used.
    ''' </summary>
    ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso Not (components Is Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)

    End Sub

#Region "Windows Form Designer generated code"

    ''' <summary>
    ''' Required method for Designer support - do not modify
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.tbInterval = New System.Windows.Forms.TrackBar()
        Me.label1 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.colorDialog1 = New System.Windows.Forms.ColorDialog()
        CType(Me.tbInterval, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        ' 
        ' btnExit
        ' 
        Me.btnExit.Location = New System.Drawing.Point(140, 29)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(53, 23)
        Me.btnExit.TabIndex = 2
        Me.btnExit.Text = "E&xit"
        Me.btnExit.UseVisualStyleBackColor = True
        ' 
        ' tbInterval
        ' 
        Me.tbInterval.LargeChange = 50
        Me.tbInterval.Location = New System.Drawing.Point(18, 29)
        Me.tbInterval.Maximum = 500
        Me.tbInterval.Name = "tbInterval"
        Me.tbInterval.Size = New System.Drawing.Size(104, 45)
        Me.tbInterval.SmallChange = 10
        Me.tbInterval.TabIndex = 1
        Me.tbInterval.TickFrequency = 50
        Me.tbInterval.Value = 100
        ' 
        ' label1
        ' 
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(24, 8)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(92, 13)
        Me.label1.TabIndex = 0
        Me.label1.Text = "&Timer interval (ms)"
        ' 
        ' label2
        ' 
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(24, 61)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(13, 13)
        Me.label2.TabIndex = 3
        Me.label2.Text = "0"
        ' 
        ' label3
        ' 
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(97, 61)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(25, 13)
        Me.label3.TabIndex = 4
        Me.label3.Text = "500"
        ' 
        ' ClientForm
        ' 
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(204, 83)
        Me.Controls.Add(label3)
        Me.Controls.Add(label2)
        Me.Controls.Add(label1)
        Me.Controls.Add(tbInterval)
        Me.Controls.Add(btnExit)
        Me.Name = "ClientForm"
        Me.Text = "Highlight Sample"
        Me.TopMost = True
        CType(Me.tbInterval, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private WithEvents btnExit As System.Windows.Forms.Button
    Private WithEvents tbInterval As System.Windows.Forms.TrackBar
    Private label1 As System.Windows.Forms.Label
    Private label2 As System.Windows.Forms.Label
    Private label3 As System.Windows.Forms.Label
    Private colorDialog1 As System.Windows.Forms.ColorDialog
End Class

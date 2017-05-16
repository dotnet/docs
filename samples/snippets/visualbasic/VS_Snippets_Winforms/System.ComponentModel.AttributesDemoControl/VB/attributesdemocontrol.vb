' <snippet1>
' <snippet2>
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Diagnostics
Imports System.Drawing
Imports System.Data
Imports System.Reflection
Imports System.Text
Imports System.Windows.Forms
' </snippet2>

' This sample demonstrates the use of various attributes for
' authoring a control. 
Namespace AttributesDemoControlLibrary

    ' This is the event handler delegate for the ThresholdExceeded event.
    Delegate Sub ThresholdExceededEventHandler(ByVal e As ThresholdExceededEventArgs)

    ' <snippet3>
    ' <snippet20>
    ' This control demonstrates a simple logging capability. 
    <ComplexBindingProperties("DataSource", "DataMember"), _
    DefaultBindingProperty("TitleText"), _
    DefaultEvent("ThresholdExceeded"), _
    DefaultProperty("Threshold"), _
    HelpKeywordAttribute(GetType(UserControl)), _
    ToolboxItem("System.Windows.Forms.Design.AutoSizeToolboxItem,System.Design")> _
    Public Class AttributesDemoControl
        Inherits UserControl
        ' </snippet20>

        ' This backs the Threshold property.
        Private thresholdValue As Object

        ' The default fore color value for DataGridView cells that
        ' contain values that exceed the threshold.
        Private Shared defaultAlertForeColorValue As Color = Color.White

        ' The default back color value for DataGridView cells that
        ' contain values that exceed the threshold.
        Private Shared defaultAlertBackColorValue As Color = Color.Red

        ' The ambient color value.
        Private Shared ambientColorValue As Color = Color.Empty

        ' The fore color value for DataGridView cells that
        ' contain values that exceed the threshold.
        Private alertForeColorValue As Color = defaultAlertForeColorValue

        ' The back color value for DataGridView cells that
        ' contain values that exceed the threshold.
        Private alertBackColorValue As Color = defaultAlertBackColorValue

        ' Child controls that comprise this UserControl.
        Private tableLayoutPanel1 As TableLayoutPanel
        Private WithEvents dataGridView1 As DataGridView
        Private label1 As Label

        ' Required for designer support.
        Private components As System.ComponentModel.IContainer = Nothing

        ' Default constructor.
        Public Sub New()
            InitializeComponent()
        End Sub
        ' <snippet21>

        <Category("Appearance"), _
        Description("The title of the log data."), _
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Localizable(True), _
        HelpKeywordAttribute("AttributesDemoControlLibrary.AttributesDemoControl.TitleText")> _
        Public Property TitleText() As String
            Get
                Return Me.label1.Text
            End Get

            Set(ByVal value As String)
                Me.label1.Text = value
            End Set
        End Property
        ' </snippet21>

        ' <snippet22>
        ' The inherited Text property is hidden at design time and 
        ' raises an exception at run time. This enforces a requirement
        ' that client code uses the TitleText property instead.
        <Browsable(False), _
        EditorBrowsable(EditorBrowsableState.Never), _
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
        Public Overrides Property Text() As String
            Get
                Throw New NotSupportedException()
            End Get
            Set(ByVal value As String)
                Throw New NotSupportedException()
            End Set
        End Property
        ' </snippet22>

        ' <snippet23>
        <AmbientValue(GetType(Color), "Empty"), _
        Category("Appearance"), _
        DefaultValue(GetType(Color), "White"), _
        Description("The color used for painting alert text.")> _
        Public Property AlertForeColor() As Color
            Get
                If Me.alertForeColorValue = Color.Empty AndAlso (Me.Parent IsNot Nothing) Then
                    Return Parent.ForeColor
                End If

                Return Me.alertForeColorValue
            End Get

            Set(ByVal value As Color)
                Me.alertForeColorValue = value
            End Set
        End Property

        ' This method is used by designers to enable resetting the
        ' property to its default value.
        Public Sub ResetAlertForeColor()
            Me.AlertForeColor = AttributesDemoControl.defaultAlertForeColorValue
        End Sub

        ' This method indicates to designers whether the property
        ' value is different from the ambient value, in which case
        ' the designer should persist the value.
        Private Function ShouldSerializeAlertForeColor() As Boolean
            Return Me.alertForeColorValue <> AttributesDemoControl.ambientColorValue
        End Function
        ' </snippet23>

        ' <snippet24>
        <AmbientValue(GetType(Color), "Empty"), _
        Category("Appearance"), _
        DefaultValue(GetType(Color), "Red"), _
        Description("The background color for painting alert text.")> _
        Public Property AlertBackColor() As Color
            Get
                If Me.alertBackColorValue = Color.Empty AndAlso (Me.Parent IsNot Nothing) Then
                    Return Parent.BackColor
                End If

                Return Me.alertBackColorValue
            End Get

            Set(ByVal value As Color)
                Me.alertBackColorValue = value
            End Set
        End Property

        ' This method is used by designers to enable resetting the
        ' property to its default value.
        Public Sub ResetAlertBackColor()
            Me.AlertBackColor = AttributesDemoControl.defaultAlertBackColorValue
        End Sub

        ' This method indicates to designers whether the property
        ' value is different from the ambient value, in which case
        ' the designer should persist the value.
        Private Function ShouldSerializeAlertBackColor() As Boolean
            Return Me.alertBackColorValue <> AttributesDemoControl.ambientColorValue
        End Function 'ShouldSerializeAlertBackColor
        ' </snippet24>

        ' <snippet25>
        <Category("Data"), _
        Description("Indicates the source of data for the control."), _
        RefreshProperties(RefreshProperties.Repaint), _
        AttributeProvider(GetType(IListSource))> _
        Public Property DataSource() As Object
            Get
                Return Me.dataGridView1.DataSource
            End Get

            Set(ByVal value As Object)
                Me.dataGridView1.DataSource = value
            End Set
        End Property
        ' </snippet25>

        ' <snippet26>
        <Category("Data"), _
        Description("Indicates a sub-list of the data source to show in the control.")> _
        Public Property DataMember() As String
            Get
                Return Me.dataGridView1.DataMember
            End Get

            Set(ByVal value As String)
                Me.dataGridView1.DataMember = value
            End Set
        End Property
        ' </snippet26>

        ' <snippet27>
        ' This property would normally have its BrowsableAttribute 
        ' set to false, but this code demonstrates using 
        ' ReadOnlyAttribute, so BrowsableAttribute is true to show 
        ' it in any attached PropertyGrid control.
        <Browsable(True), _
        Category("Behavior"), _
        Description("The timestamp of the latest entry."), _
        ReadOnlyAttribute(True)> _
        Public Property CurrentLogTime() As DateTime
            Get
                Dim lastRowIndex As Integer = _
                Me.dataGridView1.Rows.GetLastRow(DataGridViewElementStates.Visible)

                If lastRowIndex > -1 Then
                    Dim lastRow As DataGridViewRow = Me.dataGridView1.Rows(lastRowIndex)
                    Dim lastCell As DataGridViewCell = lastRow.Cells("EntryTime")
                    Return CType(lastCell.Value, DateTime)
                Else
                    Return DateTime.MinValue
                End If
            End Get

            Set(ByVal value As DateTime)
            End Set
        End Property
        ' </snippet27>

        ' <snippet28>
        <Category("Behavior"), _
        Description("The value above which the ThresholdExceeded event will be raised.")> _
        Public Property Threshold() As Object
            Get
                Return Me.thresholdValue
            End Get

            Set(ByVal value As Object)
                Me.thresholdValue = value
            End Set
        End Property
        ' </snippet28>

        ' <snippet29>
        ' This property exists only to demonstrate the 
        ' PasswordPropertyText attribute. When this control 
        ' is attached to a PropertyGrid control, the returned 
        ' string will be displayed with obscuring characters
        ' such as asterisks. This property has no other effect.
        <Category("Security"), _
        Description("Demonstrates PasswordPropertyTextAttribute."), _
        PasswordPropertyText(True)> _
        Public ReadOnly Property Password() As String
            Get
                Return "This is a demo password."
            End Get
        End Property
        ' </snippet29>

        ' <snippet30>
        ' This property exists only to demonstrate the 
        ' DisplayName attribute. When this control 
        ' is attached to a PropertyGrid control, the
        ' property will be appear as "RenamedProperty"
        ' instead of "MisnamedProperty".
        <Description("Demonstrates DisplayNameAttribute."), _
        DisplayName("RenamedProperty")> _
        Public ReadOnly Property MisnamedProperty() As Boolean
            Get
                Return True
            End Get
        End Property
        ' </snippet30>

        ' This is the declaration for the ThresholdExceeded event.
        'Public Event ThresholdExceeded As ThresholdExceededEventHandler
        Public Event ThresholdExceeded(ByVal e As ThresholdExceededEventArgs)

#Region "Implementation"

        ' <snippet31>
        ' This is the event handler for the DataGridView control's 
        ' CellFormatting event. Handling this event allows the 
        ' AttributesDemoControl to examine the incoming log entries
        ' from the data source as they arrive.
        '
        ' If the cell for which this event is raised holds the
        ' log entry's timestamp, the cell value is formatted with 
        ' the full date/time pattern. 
        ' 
        ' Otherwise, the cell's value is assumed to hold the log 
        ' entry value. If the value exceeds the threshold value, 
        ' the cell is painted with the colors specified by the
        ' AlertForeColor and AlertBackColor properties, after which
        ' the ThresholdExceeded is raised. For this comparison to 
        ' succeed, the log entry's type must implement the IComparable 
        ' interface.
        Private Sub dataGridView1_CellFormatting( _
        ByVal sender As Object, _
        ByVal e As DataGridViewCellFormattingEventArgs) _
        Handles dataGridView1.CellFormatting
            Try
                If (e.Value IsNot Nothing) Then
                    If TypeOf e.Value Is DateTime Then
                        ' Display the log entry time with the 
                        ' full date/time pattern (long time).
                        e.CellStyle.Format = "F"
                    Else
                        ' Scroll to the most recent entry.
                        Dim row As DataGridViewRow = Me.dataGridView1.Rows(e.RowIndex)
                        Dim cell As DataGridViewCell = row.Cells(e.ColumnIndex)
                        Me.dataGridView1.FirstDisplayedCell = cell

                        If (Me.thresholdValue IsNot Nothing) Then
                            ' Get the type of the log entry.
                            Dim val As Object = e.Value
                            Dim paramType As Type = val.GetType()

                            ' Compare the log entry value to the threshold value.
                            ' Use reflection to call the CompareTo method on the
                            ' template parameter's type. 
                            Dim compareVal As Integer = _
                            Fix(paramType.InvokeMember("CompareTo", _
                            BindingFlags.Default Or BindingFlags.InvokeMethod, _
                            Nothing, _
                            e.Value, _
                            New Object() {Me.thresholdValue}, _
                            System.Globalization.CultureInfo.InvariantCulture))

                            ' If the log entry value exceeds the threshold value,
                            ' set the cell's fore color and back color properties
                            ' and raise the ThresholdExceeded event.
                            If compareVal > 0 Then
                                e.CellStyle.BackColor = Me.alertBackColorValue
                                e.CellStyle.ForeColor = Me.alertForeColorValue

                                Dim teea As New ThresholdExceededEventArgs(Me.thresholdValue, e.Value)
                                RaiseEvent ThresholdExceeded(teea)
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
                Trace.WriteLine(ex.Message)
            End Try
        End Sub
        ' </snippet31>

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub


        Private Sub InitializeComponent()
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
            Me.tableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
            Me.dataGridView1 = New System.Windows.Forms.DataGridView
            Me.label1 = New System.Windows.Forms.Label
            Me.tableLayoutPanel1.SuspendLayout()
            CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'tableLayoutPanel1
            '
            Me.tableLayoutPanel1.AutoSize = True
            Me.tableLayoutPanel1.ColumnCount = 1
            Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
            Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
            Me.tableLayoutPanel1.Controls.Add(Me.dataGridView1, 0, 1)
            Me.tableLayoutPanel1.Controls.Add(Me.label1, 0, 0)
            Me.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.tableLayoutPanel1.Location = New System.Drawing.Point(10, 10)
            Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
            Me.tableLayoutPanel1.Padding = New System.Windows.Forms.Padding(10)
            Me.tableLayoutPanel1.RowCount = 2
            Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
            Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.0!))
            Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
            Me.tableLayoutPanel1.Size = New System.Drawing.Size(425, 424)
            Me.tableLayoutPanel1.TabIndex = 0
            '
            'dataGridView1
            '
            Me.dataGridView1.AllowUserToAddRows = False
            Me.dataGridView1.AllowUserToDeleteRows = False
            Me.dataGridView1.AllowUserToOrderColumns = True
            Me.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
            DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
            DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.dataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
            Me.dataGridView1.ColumnHeadersHeight = 4
            Me.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dataGridView1.Location = New System.Drawing.Point(13, 57)
            Me.dataGridView1.Name = "dataGridView1"
            Me.dataGridView1.ReadOnly = True
            Me.dataGridView1.RowHeadersVisible = False
            Me.dataGridView1.Size = New System.Drawing.Size(399, 354)
            Me.dataGridView1.TabIndex = 1
            '
            'label1
            '
            Me.label1.AutoSize = True
            Me.label1.BackColor = System.Drawing.SystemColors.Control
            Me.label1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.label1.Location = New System.Drawing.Point(13, 13)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(399, 38)
            Me.label1.TabIndex = 2
            Me.label1.Text = "label1"
            Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'AttributesDemoControl
            '
            Me.Controls.Add(Me.tableLayoutPanel1)
            Me.Name = "AttributesDemoControl"
            Me.Padding = New System.Windows.Forms.Padding(10)
            Me.Size = New System.Drawing.Size(445, 444)
            Me.tableLayoutPanel1.ResumeLayout(False)
            Me.tableLayoutPanel1.PerformLayout()
            CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub 'InitializeComponent 

#End Region

    End Class
    ' </snippet3>

    ' <snippet4>
    ' This is the EventArgs class for the ThresholdExceeded event.
    Public Class ThresholdExceededEventArgs
        Inherits EventArgs
        Private thresholdVal As Object = Nothing
        Private exceedingVal As Object = Nothing

        Public Sub New(ByVal thresholdValue As Object, ByVal exceedingValue As Object)
            Me.thresholdVal = thresholdValue
            Me.exceedingVal = exceedingValue
        End Sub

        Public ReadOnly Property ThresholdValue() As Object
            Get
                Return Me.thresholdVal
            End Get
        End Property

        Public ReadOnly Property ExceedingValue() As Object
            Get
                Return Me.exceedingVal
            End Get
        End Property
    End Class
    ' </snippet4>

    ' <snippet5>
    ' This class encapsulates a log entry. It is a parameterized 
    ' type (also known as a template class). The parameter type T
    ' defines the type of data being logged. For threshold detection
    ' to work, this type must implement the IComparable interface.
    <TypeConverter("LogEntryTypeConverter")> _
    Public Class LogEntry(Of T As IComparable)

        Private entryValue As T

        Private entryTimeValue As DateTime


        Public Sub New(ByVal value As T, ByVal time As DateTime)
            Me.entryValue = value
            Me.entryTimeValue = time
        End Sub


        Public ReadOnly Property Entry() As T
            Get
                Return Me.entryValue
            End Get
        End Property


        Public ReadOnly Property EntryTime() As DateTime
            Get
                Return Me.entryTimeValue
            End Get
        End Property

        ' <snippet6>
        ' This is the TypeConverter for the LogEntry class.  
        Public Class LogEntryTypeConverter
            Inherits TypeConverter

            ' <snippet7>
            Public Overrides Function CanConvertFrom( _
            ByVal context As ITypeDescriptorContext, _
            ByVal sourceType As Type) As Boolean
                If sourceType Is GetType(String) Then
                    Return True
                End If

                Return MyBase.CanConvertFrom(context, sourceType)
            End Function
            ' </snippet7>

            ' <snippet8>
            Public Overrides Function ConvertFrom( _
            ByVal context As ITypeDescriptorContext, _
            ByVal culture As System.Globalization.CultureInfo, _
            ByVal value As Object) As Object
                If TypeOf value Is String Then
                    Dim v As String() = CStr(value).Split(New Char() {"|"c})

                    Dim paramType As Type = GetType(T)
                    Dim entryValue As T = CType(paramType.InvokeMember("Parse", BindingFlags.Static Or BindingFlags.Public Or BindingFlags.InvokeMethod, Nothing, Nothing, New String() {v(0)}, culture), T)

                    Return New LogEntry(Of T)(entryValue, DateTime.Parse(v(2))) '

                End If

                Return MyBase.ConvertFrom(context, culture, value)
            End Function
            ' </snippet8>

            ' <snippet9>
            Public Overrides Function ConvertTo(ByVal context As ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object, ByVal destinationType As Type) As Object
                If destinationType Is GetType(String) Then

                    Dim le As LogEntry(Of T) = CType(value, LogEntry(Of T))

                    Dim stringRepresentation As String = String.Format("{0} | {1}", le.Entry, le.EntryTime)

                    Return stringRepresentation
                End If

                Return MyBase.ConvertTo(context, culture, value, destinationType)
            End Function
        End Class
        ' </snippet9>
    End Class
    ' </snippet6>
    ' </snippet5>

End Namespace
' </snippet1>
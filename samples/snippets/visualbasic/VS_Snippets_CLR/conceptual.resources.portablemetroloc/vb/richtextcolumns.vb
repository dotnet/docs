Namespace Common

    ''' <summary>
    ''' Wrapper for <see cref="RichTextBlock"/> that creates as many additional overflow
    ''' columns as needed to fit the available content.
    ''' </summary>
    ''' <example>
    ''' The following creates a collection of 400-pixel wide columns spaced 50 pixels apart
    ''' to contain arbitrary data-bound content:
    ''' <code>
    ''' <RichTextColumns>
    '''     <RichTextColumns.ColumnTemplate>
    '''         <DataTemplate>
    '''             <RichTextBlockOverflow Width="400" Margin="50,0,0,0"/>
    '''         </DataTemplate>
    '''     </RichTextColumns.ColumnTemplate>
    '''     
    '''     <RichTextBlock Width="400">
    '''         <Paragraph>
    '''             <Run Text="{Binding Content}"/>
    '''         </Paragraph>
    '''     </RichTextBlock>
    ''' </RichTextColumns>
    ''' </code>
    ''' </example>
    ''' <remarks>Typically used in a horizontally scrolling region where an unbounded amount of
    ''' space allows for all needed columns to be created.  When used in a vertically scrolling
    ''' space there will never be any additional columns.</remarks>
    <Windows.UI.Xaml.Markup.ContentProperty(Name:="RichTextContent")>
    Public NotInheritable Class RichTextColumns
        Inherits Panel

        ''' <summary>
        ''' Identifies the <see cref="RichTextContent"/> dependency property.
        ''' </summary>
        Public Shared ReadOnly RichTextContentProperty As DependencyProperty =
            DependencyProperty.Register("RichTextContent", GetType(RichTextBlock),
            GetType(RichTextColumns), New PropertyMetadata(Nothing, AddressOf ResetOverflowLayout))

        ''' <summary>
        ''' Identifies the <see cref="ColumnTemplate"/> dependency property.
        ''' </summary>
        Public Shared ReadOnly ColumnTemplateProperty As DependencyProperty =
            DependencyProperty.Register("ColumnTemplate", GetType(DataTemplate),
            GetType(RichTextColumns), New PropertyMetadata(Nothing, AddressOf ResetOverflowLayout))

        ''' <summary>
        ''' Initializes a new instance of the <see cref="RichTextColumns"/> class.
        ''' </summary>
        Public Sub New()
            Me.HorizontalAlignment = HorizontalAlignment.Left
        End Sub

        ''' <summary>
        ''' Gets or sets the initial rich text content to be used as the first column.
        ''' </summary>
        Public Property RichTextContent As RichTextBlock
            Get
                Return DirectCast(GetValue(RichTextContentProperty), RichTextBlock)
            End Get
            Set(value As RichTextBlock)
                SetValue(RichTextContentProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the template used to create additional
        ''' <see cref="RichTextBlockOverflow"/> instances.
        ''' </summary>
        Public Property ColumnTemplate As DataTemplate
            Get
                Return DirectCast(GetValue(ColumnTemplateProperty), DataTemplate)
            End Get
            Set(value As DataTemplate)
                SetValue(ColumnTemplateProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Invoked when the content or overflow template is changed to recreate the column layout.
        ''' </summary>
        ''' <param name="d">Instance of <see cref="RichTextColumns"/> where the change
        ''' occurred.</param>
        ''' <param name="e">Event data describing the specific change.</param>
        Public Shared Sub ResetOverflowLayout(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
            Dim target = TryCast(d, RichTextColumns)
            If target IsNot Nothing Then
                ' When dramatic changes occur, rebuild layout from scratch
                target._overflowColumns = Nothing
                target.Children.Clear()
                target.InvalidateMeasure()
            End If
        End Sub

        ''' <summary>
        ''' Lists overflow columns already created.  Must maintain a 1:1 relationship with
        ''' instances in the <see cref="Chidren"/> collection following the initial RichTextBlock
        ''' child.
        ''' </summary>
        Private _overflowColumns As List(Of RichTextBlockOverflow) = Nothing

        ''' <summary>
        ''' Determines whether additional overflow columns are needed and if existing columns can
        ''' be removed.
        ''' </summary>
        ''' <param name="availableSize">The size of the space available, used to constrain the
        ''' number of additional columns that can be created.</param>
        ''' <returns>The resulting size of the original content plus any extra columns.</returns>
        Protected Overrides Function MeasureOverride(availableSize As Size) As Size
            If Me.RichTextContent Is Nothing Then Return New Size(0, 0)

            ' Make sure the RichTextBlock is a child, using the lack of
            ' a list of additional columns as a sign that this hasn't been
            ' done yet
            If Me._overflowColumns Is Nothing Then
                Me.Children.Add(Me.RichTextContent)
                Me._overflowColumns = New List(Of RichTextBlockOverflow)()
            End If

            ' Start by measuring the original RichTextBlock content
            Me.RichTextContent.Measure(availableSize)
            Dim maxWidth = Me.RichTextContent.DesiredSize.Width
            Dim maxHeight = Me.RichTextContent.DesiredSize.Height
            Dim hasOverflow = Me.RichTextContent.HasOverflowContent

            ' Make sure there are enough overflow columns
            Dim overflowIndex = 0
            While hasOverflow AndAlso maxWidth < availableSize.Width AndAlso Me.ColumnTemplate IsNot Nothing

                ' Use existing overflow columns until we run out, then create
                ' more from the supplied template
                Dim overflow As RichTextBlockOverflow
                If Me._overflowColumns.Count > overflowIndex Then
                    overflow = Me._overflowColumns(overflowIndex)
                Else
                    overflow = DirectCast(Me.ColumnTemplate.LoadContent(), RichTextBlockOverflow)
                    Me._overflowColumns.Add(overflow)
                    Me.Children.Add(overflow)
                    If overflowIndex = 0 Then
                        Me.RichTextContent.OverflowContentTarget = overflow
                    Else
                        Me._overflowColumns(overflowIndex - 1).OverflowContentTarget = overflow
                    End If
                End If

                ' Measure the new column and prepare to repeat as necessary
                overflow.Measure(New Size(availableSize.Width - maxWidth, availableSize.Height))
                maxWidth += overflow.DesiredSize.Width
                maxHeight = Math.Max(maxHeight, overflow.DesiredSize.Height)
                hasOverflow = overflow.HasOverflowContent
                overflowIndex += 1
            End While

            ' Disconnect extra columns from the overflow chain, remove them from our private list
            ' of columns, and remove them as children
            If Me._overflowColumns.Count > overflowIndex Then
                If overflowIndex = 0 Then
                    Me.RichTextContent.OverflowContentTarget = Nothing
                Else
                    Me._overflowColumns(overflowIndex - 1).OverflowContentTarget = Nothing
                End If

                While Me._overflowColumns.Count > overflowIndex
                    Me._overflowColumns.RemoveAt(overflowIndex)
                    Me.Children.RemoveAt(overflowIndex + 1)
                End While
            End If

            ' Report final determined size
            Return New Size(maxWidth, maxHeight)
        End Function

        ''' <summary>
        ''' Arranges the original content and all extra columns.
        ''' </summary>
        ''' <param name="finalSize">Defines the size of the area the children must be arranged
        ''' within.</param>
        ''' <returns>The size of the area the children actually required.</returns>
        Protected Overrides Function ArrangeOverride(finalSize As Size) As Size
            Dim maxWidth As Double = 0
            Dim maxHeight As Double = 0
            For Each child In Children
                child.Arrange(New Rect(maxWidth, 0, child.DesiredSize.Width, finalSize.Height))
                maxWidth += child.DesiredSize.Width
                maxHeight = Math.Max(maxHeight, child.DesiredSize.Height)
            Next
            Return New Size(maxWidth, maxHeight)
        End Function

    End Class

End Namespace

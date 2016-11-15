    ''' <param name="id">The ID of the record to update.</param>
    ''' <remarks>Updates the record <paramref name="id"/>.
    ''' <para>Use <see cref="DoesRecordExist"/> to verify that
    ''' the record exists before calling this method.</para>
    ''' </remarks>
    Public Sub UpdateRecord(ByVal id As Integer)
        ' Code goes here.
    End Sub
    ''' <param name="id">The ID of the record to check.</param>
    ''' <returns><c>True</c> if <paramref name="id"/> exists,
    ''' <c>False</c> otherwise.</returns>
    ''' <remarks><seealso cref="UpdateRecord"/></remarks>
    Public Function DoesRecordExist(ByVal id As Integer) As Boolean
        ' Code goes here.
    End Function
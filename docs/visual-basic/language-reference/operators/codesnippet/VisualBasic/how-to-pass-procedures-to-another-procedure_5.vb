    Protected Sub Test()
        DelegateTest(5, AddressOf AddNumbers, 3)
        DelegateTest(9, AddressOf SubtractNumbers, 3)
    End Sub
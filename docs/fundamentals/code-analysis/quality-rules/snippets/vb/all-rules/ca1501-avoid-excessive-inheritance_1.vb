Imports System

Namespace ca1501

    Class BaseClass
    End Class

    Class FirstDerivedClass
        Inherits BaseClass
    End Class

    Class SecondDerivedClass
        Inherits FirstDerivedClass
    End Class

    Class ThirdDerivedClass
        Inherits SecondDerivedClass
    End Class

    Class FourthDerivedClass
        Inherits ThirdDerivedClass
    End Class

    ' This class violates the rule.
    Class FifthDerivedClass
        Inherits FourthDerivedClass
    End Class

End Namespace

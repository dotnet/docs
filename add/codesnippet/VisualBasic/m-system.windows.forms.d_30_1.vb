        Public Sub New(ByVal behaviorSvc As _
            System.Windows.Forms.Design.Behavior.BehaviorService, _
            ByVal control As Control)

            MyBase.New(New MyBehavior())
            Me.behaviorSvc = behaviorSvc
            Me.control = control
        End Sub
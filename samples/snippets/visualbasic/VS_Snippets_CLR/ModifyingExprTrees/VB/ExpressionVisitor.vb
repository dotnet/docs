Imports System.Linq.Expressions
Imports System.Collections.ObjectModel

' <Snippet1>
Public MustInherit Class ExpressionVisitor

    Protected Sub New()
    End Sub

    Protected Overridable Function Visit(ByVal exp As Expression) As Expression
        If exp Is Nothing Then
            Return exp
        End If

        Select Case exp.NodeType
            Case ExpressionType.Negate, _
                 ExpressionType.NegateChecked, _
                 ExpressionType.Not, _
                 ExpressionType.Convert, _
                 ExpressionType.ConvertChecked, _
                 ExpressionType.ArrayLength, _
                 ExpressionType.Quote, _
                 ExpressionType.TypeAs
                Return Me.VisitUnary(CType(exp, UnaryExpression))
            Case ExpressionType.Add, _
                 ExpressionType.AddChecked, _
                 ExpressionType.Subtract, _
                 ExpressionType.SubtractChecked, _
                 ExpressionType.Multiply, _
                 ExpressionType.MultiplyChecked, _
                 ExpressionType.Divide, _
                 ExpressionType.Modulo, _
                 ExpressionType.And, _
                 ExpressionType.AndAlso, _
                 ExpressionType.Or, _
                 ExpressionType.OrElse, _
                 ExpressionType.LessThan, _
                 ExpressionType.LessThanOrEqual, _
                 ExpressionType.GreaterThan, _
                 ExpressionType.GreaterThanOrEqual, _
                 ExpressionType.Equal, _
                 ExpressionType.NotEqual, _
                 ExpressionType.Coalesce, _
                 ExpressionType.ArrayIndex, _
                 ExpressionType.RightShift, _
                 ExpressionType.LeftShift, _
                 ExpressionType.ExclusiveOr
                Return Me.VisitBinary(CType(exp, BinaryExpression))
            Case ExpressionType.TypeIs
                Return Me.VisitTypeIs(CType(exp, TypeBinaryExpression))
            Case ExpressionType.Conditional
                Return Me.VisitConditional(CType(exp, ConditionalExpression))
            Case ExpressionType.Constant
                Return Me.VisitConstant(CType(exp, ConstantExpression))
            Case ExpressionType.Parameter
                Return Me.VisitParameter(CType(exp, ParameterExpression))
            Case ExpressionType.MemberAccess
                Return Me.VisitMemberAccess(CType(exp, MemberExpression))
            Case ExpressionType.Call
                Return Me.VisitMethodCall(CType(exp, MethodCallExpression))
            Case ExpressionType.Lambda
                Return Me.VisitLambda(CType(exp, LambdaExpression))
            Case ExpressionType.New
                Return Me.VisitNew(CType(exp, NewExpression))
            Case ExpressionType.NewArrayInit, _
                 ExpressionType.NewArrayBounds
                Return Me.VisitNewArray(CType(exp, NewArrayExpression))
            Case ExpressionType.Invoke
                Return Me.VisitInvocation(CType(exp, InvocationExpression))
            Case ExpressionType.MemberInit
                Return Me.VisitMemberInit(CType(exp, MemberInitExpression))
            Case ExpressionType.ListInit
                Return Me.VisitListInit(CType(exp, ListInitExpression))
            Case Else
                Throw New Exception("Unhandled expression type: '" & exp.NodeType & "'")
        End Select
    End Function

    Protected Overridable Function VisitBinding(ByVal binding As MemberBinding) As MemberBinding
        Select Case binding.BindingType
            Case MemberBindingType.Assignment
                Return Me.VisitMemberAssignment(CType(binding, MemberAssignment))
            Case MemberBindingType.MemberBinding
                Return Me.VisitMemberMemberBinding(CType(binding, MemberMemberBinding))
            Case MemberBindingType.ListBinding
                Return Me.VisitMemberListBinding(CType(binding, MemberListBinding))
            Case Else
                Throw New Exception("Unhandled binding type '" & binding.BindingType & "'")
        End Select
    End Function

    Protected Overridable Function VisitElementInitializer(ByVal initializer As ElementInit) _
        As ElementInit

        Dim arguments = Me.VisitExpressionList(initializer.Arguments)

        If arguments IsNot initializer.Arguments Then
            Return Expression.ElementInit(initializer.AddMethod, arguments)
        End If

        Return initializer
    End Function

    Protected Overridable Function VisitUnary(ByVal u As UnaryExpression) As Expression
        Dim operand = Me.Visit(u.Operand)

        If operand IsNot u.Operand Then
            Return Expression.MakeUnary(u.NodeType, operand, u.Type, u.Method)
        End If

        Return u
    End Function

    Protected Overridable Function VisitBinary(ByVal b As BinaryExpression) As Expression
        Dim left = Me.Visit(b.Left)
        Dim right = Me.Visit(b.Right)
        Dim conversion = Me.Visit(b.Conversion)

        If left IsNot b.Left Or right IsNot b.Right Or conversion IsNot b.Conversion Then

            If b.NodeType = ExpressionType.Coalesce And b.Conversion IsNot Nothing Then
                Return Expression.Coalesce(left, right, _
                                           TryCast(conversion, LambdaExpression))
            Else
                Return Expression.MakeBinary(b.NodeType, left, right, _
                                             b.IsLiftedToNull, b.Method)
            End If
        End If

        Return b
    End Function

    Protected Overridable Function VisitTypeIs(ByVal b As TypeBinaryExpression) As Expression
        Dim expr = Me.Visit(b.Expression)

        If expr IsNot b.Expression Then
            Return Expression.TypeIs(expr, b.TypeOperand)
        End If

        Return b
    End Function

    Protected Overridable Function VisitConstant(ByVal c As ConstantExpression) As Expression
        Return c
    End Function

    Protected Overridable Function VisitConditional(ByVal c As ConditionalExpression) As Expression
        Dim test = Me.Visit(c.Test)
        Dim ifTrue = Me.Visit(c.IfTrue)
        Dim ifFalse = Me.Visit(c.IfFalse)

        If test IsNot c.Test Or ifTrue IsNot c.IfTrue Or ifFalse IsNot c.IfFalse Then
            Return Expression.Condition(test, ifTrue, ifFalse)
        End If

        Return c
    End Function

    Protected Overridable Function VisitParameter(ByVal p As ParameterExpression) As Expression
        Return p
    End Function

    Protected Overridable Function VisitMemberAccess(ByVal m As MemberExpression) As Expression
        Dim exp = Me.Visit(m.Expression)

        If exp IsNot m.Expression Then
            Return Expression.MakeMemberAccess(exp, m.Member)
        End If

        Return m
    End Function

    Protected Overridable Function VisitMethodCall(ByVal m As MethodCallExpression) As Expression
        Dim obj = Me.Visit(m.Object)
        Dim args = Me.VisitExpressionList(m.Arguments)

        If obj IsNot m.Object Or args IsNot m.Arguments Then
            Return Expression.Call(obj, m.Method, args)
        End If

        Return m
    End Function

    Protected Overridable Function VisitExpressionList( _
        ByVal original As ReadOnlyCollection(Of Expression)) As ReadOnlyCollection(Of Expression)

        Dim list As List(Of Expression) = Nothing
        Dim n = original.Count

        For i = 0 To n - 1
            Dim p = Me.Visit(original(i))

            If list IsNot Nothing Then
                list.Add(p)
            ElseIf p IsNot original(i) Then
                list = New List(Of Expression)(n)

                For j = 0 To i - 1
                    list.Add(original(j))
                Next j
                list.Add(p)
            End If
        Next i

        If list IsNot Nothing Then
            Return list.AsReadOnly()
        End If

        Return original
    End Function

    Protected Overridable Function VisitMemberAssignment(ByVal assignment As MemberAssignment) _
        As MemberAssignment

        Dim e = Me.Visit(assignment.Expression)

        If e IsNot assignment.Expression Then
            Return Expression.Bind(assignment.Member, e)
        End If

        Return assignment
    End Function

    Protected Overridable Function VisitMemberMemberBinding(ByVal binding As MemberMemberBinding) _
        As MemberMemberBinding

        Dim bindings = Me.VisitBindingList(binding.Bindings)

        If bindings IsNot binding.Bindings Then
            Return Expression.MemberBind(binding.Member, bindings)
        End If

        Return binding
    End Function

    Protected Overridable Function VisitMemberListBinding(ByVal binding As MemberListBinding) _
        As MemberListBinding

        Dim initializers = Me.VisitElementInitializerList(binding.Initializers)

        If initializers IsNot binding.Initializers Then
            Return Expression.ListBind(binding.Member, initializers)
        End If

        Return binding
    End Function

    Protected Overridable Function VisitBindingList( _
        ByVal original As ReadOnlyCollection(Of MemberBinding)) As IEnumerable(Of MemberBinding)

        Dim list As List(Of MemberBinding) = Nothing
        Dim n = original.Count

        For i = 0 To n - 1
            Dim b = Me.VisitBinding(original(i))

            If list IsNot Nothing Then
                list.Add(b)
            ElseIf b IsNot original(i) Then
                list = New List(Of MemberBinding)(n)
                For j = 0 To i - 1
                    list.Add(original(j))
                Next j
                list.Add(b)
            End If

        Next i

        If list IsNot Nothing Then
            Return list
        End If

        Return original
    End Function

    Protected Overridable Function VisitElementInitializerList( _
        ByVal original As ReadOnlyCollection(Of ElementInit)) As IEnumerable(Of ElementInit)

        Dim list As List(Of ElementInit) = Nothing
        Dim n = original.Count

        For i = 0 To n - 1
            Dim init = Me.VisitElementInitializer(original(i))
            If list IsNot Nothing Then
                list.Add(init)
            ElseIf init IsNot original(i) Then
                list = New List(Of ElementInit)(n)
                For j = 0 To i - 1
                    list.Add(original(j))
                Next j
                list.Add(init)
            End If
        Next i

        If list IsNot Nothing Then
            Return list
        End If

        Return original
    End Function

    Protected Overridable Function VisitLambda(ByVal lambda As LambdaExpression) As Expression
        Dim body = Me.Visit(lambda.Body)

        If body IsNot lambda.Body Then
            Return Expression.Lambda(lambda.Type, body, lambda.Parameters)
        End If
        Return lambda
    End Function

    Protected Overridable Function VisitNew(ByVal nex As NewExpression) As NewExpression
        Dim args = Me.VisitExpressionList(nex.Arguments)

        If args IsNot nex.Arguments Then
            If nex.Members IsNot Nothing Then
                Return Expression.[New](nex.Constructor, args, nex.Members)
            Else
                Return Expression.[New](nex.Constructor, args)
            End If
        End If

        Return nex
    End Function

    Protected Overridable Function VisitMemberInit(ByVal init As MemberInitExpression) As Expression
        Dim n = Me.VisitNew(init.NewExpression)
        Dim bindings = Me.VisitBindingList(init.Bindings)

        If n IsNot init.NewExpression Or bindings IsNot init.Bindings Then
            Return Expression.MemberInit(n, bindings)
        End If

        Return init
    End Function

    Protected Overridable Function VisitListInit(ByVal init As ListInitExpression) As Expression
        Dim n = Me.VisitNew(init.NewExpression)
        Dim initializers = Me.VisitElementInitializerList(init.Initializers)

        If n IsNot init.NewExpression Or initializers IsNot init.Initializers Then
            Return Expression.ListInit(n, initializers)
        End If

        Return init
    End Function

    Protected Overridable Function VisitNewArray(ByVal na As NewArrayExpression) As Expression
        Dim exprs = Me.VisitExpressionList(na.Expressions)
        If exprs IsNot na.Expressions Then
            If na.NodeType = ExpressionType.NewArrayInit Then
                Return Expression.NewArrayInit(na.Type.GetElementType(), exprs)
            Else
                Return Expression.NewArrayBounds(na.Type.GetElementType(), exprs)
            End If
        End If

        Return na
    End Function

    Protected Overridable Function VisitInvocation(ByVal iv As InvocationExpression) As Expression
        Dim args = Me.VisitExpressionList(iv.Arguments)
        Dim expr = Me.Visit(iv.Expression)

        If args IsNot iv.Arguments Or expr IsNot iv.Expression Then
            Return Expression.Invoke(expr, args)
        End If

        Return iv
    End Function
End Class
' </Snippet1>
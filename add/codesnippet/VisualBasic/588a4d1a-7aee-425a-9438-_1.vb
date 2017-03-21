        ' Create a new ExpressionBuilder reference.
        Dim myExpressionBuilder As ExpressionBuilder = _
          New ExpressionBuilder("myCustomExpression", "MyCustomExpressionBuilder")
        ' Add an ExpressionBuilder to the configuration.
        configSection.ExpressionBuilders.Add(myExpressionBuilder)
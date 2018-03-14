
Imports System
Imports System.Text
Imports System.Configuration
Imports System.Web.Configuration


' Accesses the System.Web.Configuration.AuthorizationSection
' members selected by the user.

Class UsingAuthorizationSection
   
   
   Public Shared Sub Main()
      
      ' <Snippet1>
      ' Get the Web application configuration.
        Dim configuration As System.Configuration.Configuration = _
        WebConfigurationManager.OpenWebConfiguration( _
        "/aspnetTest")
      ' </Snippet1>
      ' <Snippet2>
      ' Get the section.
        Dim authorizationSection _
        As AuthorizationSection = _
        CType(configuration.GetSection( _
        "system.web/authorization"), AuthorizationSection)
      ' </Snippet2>
      ' <Snippet3>
      ' Get the authorization rule collection.
        Dim authorizationRuleCollection _
        As AuthorizationRuleCollection = _
        authorizationSection.Rules
      ' </Snippet3>
      ' <Snippet4>
      ' Create an authorization rule object.
        Dim action As AuthorizationRuleAction = _
        AuthorizationRuleAction.Deny
        Dim authorizationRule = _
        New System.Web.Configuration.AuthorizationRule(action)
      ' </Snippet4>
      
      ' <Snippet5>
      ' Create a new 'AuthorizationSection' object.
        Dim newauthorizationSection = _
        New System.Web.Configuration.AuthorizationSection()
      
      ' </Snippet5>
      
      ' <Snippet6>
      ' Using the AuthorizationRuleCollection Add method.
      ' Set the action property.
        authorizationRule.Action = _
        AuthorizationRuleAction.Allow
      ' Define the new rule to add to the collection.
      authorizationRule.Users.Add("userName")
      authorizationRule.Roles.Add("admin")
      authorizationRule.Verbs.Add("POST")
      
      ' Add the new rule to the collection.
      authorizationSection.Rules.Add(authorizationRule)
      ' </Snippet6>
      ' <Snippet7>
      ' Using the AuthorizationRuleCollection Clear method.
      authorizationSection.Rules.Clear()
      ' </Snippet7>
      ' <Snippet8>
      ' Using the AuthorizationRuleCollection RemoveAt method.
      authorizationRuleCollection.RemoveAt(0)
      ' </Snippet8>
      ' <Snippet9>
      ' Get the rule collection index.
        Dim ruleIndex As System.Int32 = _
        authorizationSection.Rules.IndexOf(authorizationRule)
      ' </Snippet9>
      ' <Snippet10>
      ' Remove the rule from the collection.
      authorizationSection.Rules.Remove(authorizationRule)
      
      ' </Snippet10>
      ' <Snippet11>
      ' Using the AuthorizationRuleCollection Set method.
      ' Define the rule to add to the collection.
      ' Define the collection index.
      Dim rIndex As System.Int32 = 0
      
      ' Set the rule in the collection.
        authorizationRuleCollection.Set(rIndex, _
        authorizationRule)
      ' </Snippet11>
      
      ' <Snippet12>
      ' Show how to access the Rules elements.
      Dim rules As New StringBuilder()
      Dim i As System.Int32
      For i = 0 To (authorizationSection.Rules.Count - 1) - 1
            rules.Append(("Action: " + _
            authorizationSection.Rules(i).Action.ToString()))
         
         ' Get the Verbs.
            Dim verbsCount As System.Int32 = _
            authorizationSection.Rules(i).Verbs.Count
         Dim v As System.Int32
         For v = 0 To verbsCount - 1
            rules.AppendLine(authorizationSection.Rules(i).Verbs(v))
         Next v
         
         ' Get the Roles.
            Dim rolesCount As System.Int32 = _
            authorizationSection.Rules(i).Roles.Count
         Dim r As System.Int32
         For r = 0 To rolesCount - 1
            rules.AppendLine(authorizationSection.Rules(i).Roles(r))
         Next r 
         ' Get the Users.
            Dim usersCount As System.Int32 = _
            authorizationSection.Rules(i).Users.Count
         Dim u As System.Int32
         For u = 0 To usersCount - 1
            rules.AppendLine(authorizationSection.Rules(i).Users(u))
         Next u
      Next i 
      ' </Snippet12>
      ' <Snippet13>
      ' Using the AuthorizationRuleCollection Get method.
        Dim authRule As AuthorizationRule = _
        authorizationRuleCollection.Get(0)
        ' </Snippet13>

   End Sub 'Main
End Class 'UsingAuthorizationSection 





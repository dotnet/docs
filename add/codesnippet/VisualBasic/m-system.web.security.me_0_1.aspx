Dim users As MembershipUserCollection = Membership.GetAllUsers()

' Code to modify MembershipUserCollection here.

users.Clear()
users = Membership.GetAllUsers()
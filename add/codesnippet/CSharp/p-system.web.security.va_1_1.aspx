  public void Page_Load()
  {
    Membership.ValidatingPassword +=
      new MembershipValidatePasswordEventHandler(OnValidatePassword);
  }

  public void OnValidatePassword(object sender,
                                ValidatePasswordEventArgs args)
  {
    System.Text.RegularExpressions.Regex r =
      new System.Text.RegularExpressions.Regex(@"(?=.{6,})(?=(.*\d){1,})(?=(.*\W){1,})");


    if (!r.IsMatch(args.Password))
    {
      args.FailureInformation =
        new HttpException("Password must be at least 6 characters long and " +
                          "contain at least one number and one special character.");
      args.Cancel = true;
    }
  }
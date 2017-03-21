    [Personalizable(), WebBrowsable(), WebDisplayName("Job Type"), 
      WebDescription("Select the category that corresponds to your job.")]
    public JobTypeName UserJobType
    {
      get
      {
        object o = ViewState["UserJobType"];
        if (o != null)
          return (JobTypeName)o;
        else
          return _userJobType;
      }

      set { _userJobType = (JobTypeName)value; }
    }
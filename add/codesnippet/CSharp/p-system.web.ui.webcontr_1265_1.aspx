        if (sourcePriority.SelectedValue == "Normal")
        {
            md.Priority = MailPriority.Normal;
        }
        else if (sourcePriority.SelectedValue == "High")
        {
            md.Priority = MailPriority.High;
        }
        else if (sourcePriority.SelectedValue == "Low")
        {
            md.Priority = MailPriority.Low;
        }
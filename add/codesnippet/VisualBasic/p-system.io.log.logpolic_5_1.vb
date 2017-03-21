			' SET LOG POLICY

			Dim policy As LogPolicy = sequence.LogStore.Policy

			' Set AutoGrow policy. This enables the log to automatically grow
			' when the existing extents are full. New extents are added until
			' we reach the MaximumExtentCount extents.
			' AutoGrow policy is supported only in Windows Vista and not available in R2.

			'policy.AutoGrow = true;

			' Set the Growth Rate in terms of extents. This policy specifies
			' "how much" the log should grow. 
			policy.GrowthRate = New PolicyUnit(2, PolicyUnitType.Extents)

			' Set the AutoShrink policy. This enables the log to automatically
			' shrink if the available free space exceeds the shrink percentage. 
			' AutoGrow/shrink policy is supported only in Windows Vista and not available in R2.

			'policy.AutoShrinkPercentage = new PolicyUnit(30, PolicyUnitType.Percentage);

			' Set the PinnedTailThreshold policy.
			' A tail pinned event is triggered when there is no
			' log space available and log space may be freed by advancing the base.
			' The user must handle the tail pinned event by advancing the base of the log. 
			' If the user is not able to move the base of the log, the user should report with exception in
			' the tail pinned handler.
			' PinnedTailThreashold policy dictates the amount of space that the TailPinned event requests 
			' for advancing the base of the log. The amount of space can be in percentage or in terms of bytes 
			' which is rounded off to the nearest containers in CLFS. The default is 35 percent.


			policy.PinnedTailThreshold = New PolicyUnit(10, PolicyUnitType.Percentage)

			' Set the maximum extents the log can have.
			policy.MaximumExtentCount = 6

			' Set the minimum extents the log can have.
			policy.MinimumExtentCount = 2

			' Set the prefix for new containers that are added. 
			' when AutoGrow is enabled.
			'policy.NewExtentPrefix = "MyLogPrefix";

			' Set the suffix number for new containers that are added.
			' when AutoGrow is enabled. 
			policy.NextExtentSuffix = 3

			' Commit the log policy.
			policy.Commit()

			' Refresh updates the IO.Log policy properties with current log policy 
			' set in the log. 
			policy.Refresh()

			' LOG POLICY END
			' 
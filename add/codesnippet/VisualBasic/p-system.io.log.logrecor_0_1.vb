			' SET RETRY APPEND

			' IO.Log provides a mechanism similar to AutoGrow.
			' If the existing log is full and an append fails, setting RetryAppend
			' invokes the CLFS policy engine to add new extents and re-tries
			' record appends. If MaximumExtent count has been reached, 
			' a SequenceFullException is thrown. 
			' 

			sequence.RetryAppend = True

			' RETRY APPEND END
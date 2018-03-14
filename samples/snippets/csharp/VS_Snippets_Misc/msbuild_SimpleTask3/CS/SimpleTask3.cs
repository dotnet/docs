//<Snippet1>
using System;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace SimpleTask3
{
	public class SimpleTask3 : Task
	{
		private string myProperty;

		// The [Required] attribute indicates a required property.
		// If a project file invokes this task without passing a value
		// to this property, the build will fail immediately.
		[Required]
		public string MyProperty
		{
			get
			{
				return myProperty;
			}
			set
			{
				myProperty = value;
			}
		}

		public override bool Execute()
		{
			// Log a high-importance comment
			Log.LogMessage(MessageImportance.High,
				"The task was passed \"" + myProperty + "\".");
			return true;
		}
	}
}
//</Snippet1>
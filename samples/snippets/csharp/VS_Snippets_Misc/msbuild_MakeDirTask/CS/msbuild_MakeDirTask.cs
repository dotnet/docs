//<Snippet1>
using System;
using System.IO;
using System.Security;
using System.Collections;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace Microsoft.Build.Tasks
{
	/*
	 * Class: MakeDir
	 *
	 * An MSBuild task that creates one or more directories.
	 *
	 */
	public class MakeDir : Task
	{
	    // The Required attribute indicates the following to MSBuild:
	    //	     - if the parameter is a scalar type, and it is not supplied, fail the build immediately
	    //	     - if the parameter is an array type, and it is not supplied, pass in an empty array
	    // In this case the parameter is an array type, so if a project fails to pass in a value for the 
            // Directories parameter, the task will get invoked, but this implementation will do nothing,
            // because the array will be empty.
		[Required]
            // Directories to create.
		public ITaskItem[] Directories
		{
			get
			{
				return directories;
			}

			set
			{
				directories = value;
			}
		}

		// The Output attribute indicates to MSBuild that the value of this property can be gathered after the
		// task has returned from Execute(), if the project has an <Output> tag under this task's element for 
		// this property.
		[Output]
		// A project may need the subset of the inputs that were actually created, so make that available here.
		public ITaskItem[] DirectoriesCreated
		{
			get
			{
				return directoriesCreated;
			}
		}

		private ITaskItem[] directories;
		private ITaskItem[] directoriesCreated;

		/// <summary>
		/// Execute is part of the Microsoft.Build.Framework.ITask interface.
		/// When it's called, any input parameters have already been set on the task's properties.
		/// It returns true or false to indicate success or failure.
		/// </summary>
		public override bool Execute()
		{
			ArrayList items = new ArrayList();
			foreach (ITaskItem directory in Directories)
			{
				// ItemSpec holds the filename or path of an Item
				if (directory.ItemSpec.Length > 0)
				{
					try
					{
						// Only log a message if we actually need to create the folder
						if (!Directory.Exists(directory.ItemSpec))
						{
							Log.LogMessage(MessageImportance.Normal, "Creating directory " + directory.ItemSpec);
							Directory.CreateDirectory(directory.ItemSpec);
						}

						// Add to the list of created directories
						items.Add(directory);
					}
					// If a directory fails to get created, log an error, but proceed with the remaining 
					// directories.
					catch (Exception ex)
					{
						if (ex is IOException
							|| ex is UnauthorizedAccessException
							|| ex is PathTooLongException
							|| ex is DirectoryNotFoundException
							|| ex is SecurityException)
						{
							Log.LogError("Error trying to create directory " + directory.ItemSpec + ". " + ex.Message);
						}
						else
						{
							throw;
						}
					}
				}
			}

			// Populate the "DirectoriesCreated" output items.
			directoriesCreated = (ITaskItem[])items.ToArray(typeof(ITaskItem));

			// Log.HasLoggedErrors is true if the task logged any errors -- even if they were logged 
			// from a task's constructor or property setter. As long as this task is written to always log an error
			// when it fails, we can reliably return HasLoggedErrors.
			return !Log.HasLoggedErrors;
		}
	}
}
//</Snippet1>
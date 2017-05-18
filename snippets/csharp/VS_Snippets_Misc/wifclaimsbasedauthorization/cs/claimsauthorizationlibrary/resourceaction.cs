//-----------------------------------------------------------------------------
//
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//
//
//-----------------------------------------------------------------------------
//<Snippet1>

using System;

namespace ClaimsAuthorizationLibrary
{
    /// <summary>
    /// Class to encapsulate resource/action pair
    /// </summary>
    public class ResourceAction
    {
        public string Resource;
        public string Action;

        /// <summary>
        /// Checks if the current instance is equal to the given object by comparing the resource and action values
        /// </summary>
        /// <param name="obj">object to compare to</param>
        /// <returns>True if equal, else false.</returns>
        public override bool Equals(object obj)
        {
            ResourceAction ra = obj as ResourceAction;
            if (ra != null)
            {
                return ((string.Compare(ra.Resource, Resource, true) == 0) && (string.Compare(ra.Action, Action, true) == 0));
            }

            return base.Equals(obj);
        }

        /// <summary>
        /// Gets the hash code.
        /// </summary>
        /// <returns>The hash code.</returns>
        public override int GetHashCode()
        {
            return (Resource + Action).ToLower().GetHashCode();
        }

        /// <summary>
        /// Creates an instance of ResourceAction class.
        /// </summary>
        /// <param name="resource">The resource name.</param>
        /// <param name="action">The action.</param>
        /// <exception cref="ArgumentNullException">when <paramref name="resource"/> is null</exception>
        public ResourceAction(string resource, string action)
        {
            if (string.IsNullOrEmpty(resource))
            {
                throw new ArgumentNullException("resource");
            }

            Resource = resource;
            Action = action;
        }
    }
}
//</Snippet1>

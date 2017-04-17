// <Snippet1> 
using System;
using System.Resources;
using MyCompany.Employees;

[assembly: NeutralResourcesLanguage("en-US")]

namespace MyCompany.Employees
{
   public class UILibrary
   {
      private const int nFields = 4;

      public static string GetTitle()
      {
         string retval = LibResources.Born; 
         if (String.IsNullOrEmpty(retval))
            retval = "";

         return retval;
      }

      public static string[] GetFieldNames()
      {
         string[] fieldnames = new string[nFields];
         fieldnames[0] = LibResources.Name;
         fieldnames[1] = LibResources.ID;
         fieldnames[2] = LibResources.Born;
         fieldnames[3] = LibResources.Hired;
         return fieldnames;
      }

      public static int[] GetFieldLengths()
      {
         int[] fieldLengths = new int[nFields];
         fieldLengths[0] = Int32.Parse(LibResources.NameLength);
         fieldLengths[1] = Int32.Parse(LibResources.IDLength);
         fieldLengths[2] = Int32.Parse(LibResources.BornLength);
         fieldLengths[3] = Int32.Parse(LibResources.HiredLength);
         return fieldLengths;
      }
   }
}
// </Snippet1>

namespace MyCompany.Employees 
{
   public class LibResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal LibResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MyCompany.Employees.LibResources", typeof(LibResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Birthdate.
        /// </summary>
        public static string Born {
            get {
                return ResourceManager.GetString("Born", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 12.
        /// </summary>
        public static string BornLength {
            get {
                return ResourceManager.GetString("BornLength", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Hire Date.
        /// </summary>
        public static string Hired {
            get {
                return ResourceManager.GetString("Hired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 12.
        /// </summary>
        public static string HiredLength {
            get {
                return ResourceManager.GetString("HiredLength", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ID.
        /// </summary>
        public static string ID {
            get {
                return ResourceManager.GetString("ID", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 12.
        /// </summary>
        public static string IDLength {
            get {
                return ResourceManager.GetString("IDLength", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Name.
        /// </summary>
        public static string Name {
            get {
                return ResourceManager.GetString("Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 25.
        /// </summary>
        public static string NameLength {
            get {
                return ResourceManager.GetString("NameLength", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Employee Database.
        /// </summary>
        public static string Title {
            get {
                return ResourceManager.GetString("Title", resourceCulture);
            }
        }
    }
}
 
   


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace new_in_7
{
    public class ConfigResource
    {
        
    }

    public class ApplicationOptions
    {
        private string name;

        #region 38_ThrowInInitialization
        private ConfigResource loadedConfig = LoadConfigResourceOrDefault() ?? 
            throw new InvalidOperationException("Could not load config");
        #endregion

        #region 39_ThrowInConstructor
        public ApplicationOptions()
        {
            loadedConfig = LoadConfigResourceOrDefault();
            if (loadedConfig == null)
                throw new InvalidOperationException("Could not load config");

        }
        #endregion


        private static ConfigResource LoadConfigResourceOrDefault()
        {
            return new ConfigResource();
        }

        #region 37_Throw_ExpressionExample
        public string Name
        {
            get => name;
            set => name = value ?? 
                throw new ArgumentNullException(paramName: nameof(value), message: "New name must not be null");
        }
        #endregion


    }
}

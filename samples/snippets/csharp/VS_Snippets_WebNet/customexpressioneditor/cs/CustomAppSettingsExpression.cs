// <Snippet1>
using System;
using System.Collections;
using System.Collections.Specialized;
using System.CodeDom;
using System.Configuration;
using System.Web.UI.Design;
using System.Web.Compilation;

namespace ExpressionEditorSamples.CS
{
    [ExpressionPrefix("CustomAppSettings")]
    [ExpressionEditor(typeof(ExpressionEditorSamples.CS.CustomAppSettingsEditor))]
    public class CustomAppSettingsBuilder : AppSettingsExpressionBuilder
    {
        // Use the built-in AppSettingsExpressionBuilder class,
        // but associate it with a custom expression editor class.

    }

    public class CustomAppSettingsEditor : System.Web.UI.Design.ExpressionEditor
    {
        public override object EvaluateExpression(string expression, object parseTimeData, Type propertyType, IServiceProvider serviceProvider)
        {
            KeyValueConfigurationCollection customSettings = null;

            if (serviceProvider != null)
            {
                IWebApplication webApp = (IWebApplication)serviceProvider.GetService(typeof(IWebApplication));
                if (webApp != null)
                {
                    Configuration config = webApp.OpenWebConfiguration(true);
                    if (config != null)
                    {
                        AppSettingsSection settingsSection = config.AppSettings;
                        if (settingsSection != null)
                        {
                            customSettings = settingsSection.Settings;
                        }

                    }
                }
            }

            if (customSettings != null)
            {
                return customSettings[expression];
            }

            return expression;

        }
    }
}
// </Snippet1>
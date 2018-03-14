//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.Windows.Data;

namespace Microsoft.Samples.Activities.Statements.Design
{

    /// <summary>
    /// WPF value converter used to convert the Type of the ModelItem to its first generic type. 
    /// It is used to bind the generic type of the ModelItem to the type of an ExpressionTextBox
    /// 
    /// In this sample, we use it to bind the type of the ExpressionTextBox that contains 
    /// the Result OutArgument to the type of the generic argument of the ModelItem
    /// </summary>
    public class TypeToFirstGenericArgumentConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Type t = (Type)value;
            return t.GetGenericArguments()[0].FullName.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException("Not implemented");
        }
    }
}

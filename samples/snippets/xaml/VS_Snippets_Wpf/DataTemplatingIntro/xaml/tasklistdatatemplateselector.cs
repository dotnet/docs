using System.Windows;
using System.Windows.Controls;

namespace SDKSample
{
    public class TaskListDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate
            SelectTemplate(object item, DependencyObject container)
        {
            if (item != null && item is Task)
            {
                Task taskitem = item as Task;
                Window window = Application.Current.MainWindow;

                if (taskitem.Priority == 1)
                    return
                        window.FindResource("importantTaskTemplate") as DataTemplate;
                else
                    return
                        window.FindResource("myTaskTemplate") as DataTemplate;
            }

            return null;
        }
    }
}

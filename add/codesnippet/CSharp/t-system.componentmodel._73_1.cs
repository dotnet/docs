using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace IListSourceCS
{
    public class EmployeeListSource : Component, IListSource
    {
        public EmployeeListSource() {}

        public EmployeeListSource(IContainer container)
        {
            container.Add(this);
        }

        #region IListSource Members

        bool IListSource.ContainsListCollection
        {
            get { return false; }
        }

        System.Collections.IList IListSource.GetList()
        {
            BindingList<Employee>   ble = new BindingList<Employee>();

            if (!this.DesignMode)
            {
                ble.Add(new Employee("Aaberg, Jesper", 26000000));
                ble.Add(new Employee("Cajhen, Janko", 19600000));
                ble.Add(new Employee("Furse, Kari", 19000000));
                ble.Add(new Employee("Langhorn, Carl", 16000000));
                ble.Add(new Employee("Todorov, Teodor", 15700000));
                ble.Add(new Employee("Vereb�lyi, �gnes", 15700000));
            }

            return ble;
        }

        #endregion
    }
}
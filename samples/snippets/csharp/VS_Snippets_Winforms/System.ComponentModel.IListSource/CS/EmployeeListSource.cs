// <snippet1>
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

        // <snippet2>
        #region IListSource Members

        // <snippet3>
        bool IListSource.ContainsListCollection
        {
            get { return false; }
        }
        // </snippet3>

        // <snippet4>
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
                ble.Add(new Employee("Verebélyi, Ágnes", 15700000));
            }

            return ble;
        }
        // </snippet4>

        #endregion
        // </snippet2>
    }
}
// </snippet1>

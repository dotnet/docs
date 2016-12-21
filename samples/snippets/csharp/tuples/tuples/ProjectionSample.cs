using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tuples
{
    #region 14_ToDoItem
    public class ToDoItem
    {
        public int ID { get; set; }
        public bool IsDone { get; set; }
        public DateTime DueDate { get; set; }
        public string Title { get; set; }
        public string Notes { get; set; }    
    }
    #endregion


    public class ProjectionSample
    {
        private List<ToDoItem> AllItems = new List<ToDoItem>
        {
            new ToDoItem
            {
                ID=0,
                IsDone = false,
                DueDate = DateTime.Now + TimeSpan.FromDays(2),
                Title = "answer email",
                Notes = "This happens every day"
            },
            new ToDoItem
            {
                ID=1,
                IsDone = false,
                DueDate = DateTime.Now + TimeSpan.FromDays(3),
                Title = "Review open PRs",
                Notes = "Look for working code, good tests, and structure"
            },
            new ToDoItem
            {
                ID=2,
                IsDone = false,
                DueDate = DateTime.Now + TimeSpan.FromDays(1),
                Title = "Create updated issues",
                Notes = "Need to track what's getting done"
            },
            new ToDoItem
            {
                ID=3,
                IsDone = false,
                DueDate = DateTime.Now + TimeSpan.FromDays(5),
                Title = "Plan vacation",
                Notes = "The first step is determining where we should go"
            },
            new ToDoItem
            {
                ID=4,
                IsDone = false,
                DueDate = DateTime.Now + TimeSpan.FromDays(7),
                Title = "make reservations for vacation",
                Notes = "Once we decide on a location, find lodging"
            }
        };

        #region 15_QueryReturningTuple
        internal IEnumerable<(int ID, string Title)> GetCurrentItemsMobileList()
        {
            return from item in AllItems
                   where !item.IsDone
                   orderby item.DueDate
                   select (item.ID, item.Title);
        }
        #endregion 
    }
}

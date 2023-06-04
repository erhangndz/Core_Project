using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ToDoList
    {
        public int ToDoListID { get; set; }
        public string Title { get; set; }
        public bool Status { get; set; }
    }
}

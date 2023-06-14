using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ToDoListManager : IToDoListService
    {
        private readonly IToDoListDal _toDoListDal;

        public ToDoListManager(IToDoListDal toDoListDal)
        {
            _toDoListDal = toDoListDal;
        }

        public void TDelete(ToDoList t)
        {
            _toDoListDal.Delete(t);
        }

        public List<ToDoList> TGetbyFilter(Expression<Func<ToDoList, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public ToDoList TGetByID(int id)
        {
            return _toDoListDal.GetByID(id);
        }

        public List<ToDoList> TGetList()
        {
           return _toDoListDal.GetList();
        }

        public void TInsert(ToDoList t)
        {
            _toDoListDal.Insert(t);
        }

        public void TUpdate(ToDoList t)
        {
            _toDoListDal.Update(t);
        }
    }
}

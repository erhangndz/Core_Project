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
    public class WriterManager:IWriterService
    {
        private readonly IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public void TDelete(WriterUser t)
        {
            _writerDal.Delete(t);
        }

        public List<WriterUser> TGetbyFilter(Expression<Func<WriterUser, bool>> filter)
        {
            return _writerDal.GetbyFilter(filter);
        }

        public WriterUser TGetByID(int id)
        {
            return _writerDal.GetByID(id);  
        }

        public List<WriterUser> TGetList()
        {
            return _writerDal.GetList();
        }

        public void TInsert(WriterUser t)
        {
           _writerDal.Insert(t);
        }

        public void TUpdate(WriterUser t)
        {
           _writerDal.Update(t);
        }
    }
}

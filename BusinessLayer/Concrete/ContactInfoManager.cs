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
    public class ContactInfoManager : IContactInfoService
    {
        private readonly IContactInfoDal _contactInfoDal;

        public ContactInfoManager(IContactInfoDal contactInfoDal)
        {
            _contactInfoDal = contactInfoDal;
        }

        public void TDelete(ContactInfo t)
        {
            _contactInfoDal.Delete(t);
        }

        public List<ContactInfo> TGetbyFilter(Expression<Func<ContactInfo, bool>> filter)
        {
           return _contactInfoDal.GetbyFilter(filter);
        }

        public ContactInfo TGetByID(int id)
        {
            return _contactInfoDal.GetByID(id);
        }

        public List<ContactInfo> TGetList()
        {
            return _contactInfoDal.GetList();
        }

        public void TInsert(ContactInfo t)
        {
            _contactInfoDal.Insert(t);
        }

        public void TUpdate(ContactInfo t)
        {
            _contactInfoDal.Update(t);
        }
    }
}

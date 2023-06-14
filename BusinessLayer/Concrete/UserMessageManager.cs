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
    public class UserMessageManager : IUserMessageService
    {
        private readonly IUserMessageDal _userMessageDal;

        public UserMessageManager(IUserMessageDal userMessageDal)
        {
            _userMessageDal = userMessageDal;
        }

        public void TDelete(UserMessage t)
        {
            _userMessageDal.Delete(t);
        }

        public List<UserMessage> TGetbyFilter(Expression<Func<UserMessage, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public UserMessage TGetByID(int id)
        {
           return _userMessageDal.GetByID(id);
        }

        public List<UserMessage> TGetList()
        {
            return _userMessageDal.GetList();
        }

        public List<UserMessage> TGetMessageswithUsers()
        {
            return _userMessageDal.GetMessageswithUsers();
        }

        public void TInsert(UserMessage t)
        {
            _userMessageDal.Insert(t);
        }

        public void TUpdate(UserMessage t)
        {
            _userMessageDal.Update(t);
        }
    }
}

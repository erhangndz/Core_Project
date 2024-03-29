﻿using BusinessLayer.Abstract;
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
    public class SkillManager : ISkillService
    {
        private readonly ISkillDal _skillDal;

        public SkillManager(ISkillDal skillDal)
        {
            _skillDal = skillDal;
        }

        public List<Skill> GetFirst5()
        {
           return _skillDal.GetList().Take(5).ToList();
        }

        public List<Skill> GetLast5()
        {
            return _skillDal.GetList().TakeLast(5).ToList();
        }

        public void TDelete(Skill t)
        {
            _skillDal.Delete(t);
        }

        public List<Skill> TGetbyFilter(Expression<Func<Skill, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Skill TGetByID(int id)
        {
            return _skillDal.GetByID(id);
        }

        public List<Skill> TGetList()
        {
            return _skillDal.GetList();
        }

        public void TInsert(Skill t)
        {
            _skillDal.Insert(t);
        }

        public void TUpdate(Skill t)
        {
            _skillDal.Update(t);
        }
    }
}

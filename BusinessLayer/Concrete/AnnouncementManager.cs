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
	public class AnnouncementManager : IAnnouncementService
	{
		private readonly IAnnouncementDal _announcementDal;

		public AnnouncementManager(IAnnouncementDal announcementDal)
		{
			_announcementDal = announcementDal;
		}

		public void TDelete(Announcement t)
		{
			_announcementDal.Delete(t);
		}

        public List<Announcement> TGetbyFilter(Expression<Func<Announcement, bool>> filter)
        {
            return _announcementDal.GetbyFilter(filter);
        }

        public Announcement TGetByID(int id)
		{
			return _announcementDal.GetByID(id);
		}

		public List<Announcement> TGetList()
		{
			return _announcementDal.GetList();
		}

		public void TInsert(Announcement t)
		{
			_announcementDal.Insert(t);
		}

		public void TUpdate(Announcement t)
		{
			_announcementDal.Update(t);
		}
	}
}

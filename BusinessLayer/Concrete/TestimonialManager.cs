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
    public class TestimonialManager : ITestimonialService
    {
        private readonly ITestimonialDal _testimonialDal;

        public TestimonialManager(ITestimonialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }

        public void TDelete(Testimonial t)
        {
           _testimonialDal.Delete(t);
        }

        public List<Testimonial> TGetbyFilter(Expression<Func<Testimonial, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Testimonial TGetByID(int id)
        {
           return _testimonialDal.GetByID(id);
        }

        public List<Testimonial> TGetList()
        {
           return _testimonialDal.GetList();
        }

        public void TInsert(Testimonial t)
        {
           _testimonialDal.Insert(t);
        }

        public void TUpdate(Testimonial t)
        {
           _testimonialDal.Update(t);
        }
    }
}

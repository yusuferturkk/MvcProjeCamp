using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class HeadingManager : IHeadingService
    {

        IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public void Add(Heading entity)
        {
            _headingDal.Add(entity);
        }

        public void Delete(Heading entity)
        {
            _headingDal.Update(entity);
        }

        public void Update(Heading entity)
        {
            _headingDal.Update(entity);
        }

        public Heading GetById(int id)
        {
            return _headingDal.GetById(x => x.HeadingId == id);
        }

        public List<Heading> GetList()
        {
            return _headingDal.GetList();
        }

        public List<Heading> GetListByWriterId(int id)
        {
            return _headingDal.GetList(x => x.WriterId == id);
        }
    }
}

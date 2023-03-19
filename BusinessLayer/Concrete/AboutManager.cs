using BusinessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {

        EfAboutDal _aboutDal;

        public AboutManager(EfAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void Add(About entity)
        {
            _aboutDal.Add(entity);
        }

        public void Delete(About entity)
        {
            _aboutDal.Delete(entity);
        }

        public void Update(About entity)
        {
            _aboutDal.Update(entity);
        }

        public About GetById(int id)
        {
            return _aboutDal.GetById(x => x.AboutId == id);
        }

        public List<About> GetList()
        {
            return _aboutDal.GetList();
        }
    }
}

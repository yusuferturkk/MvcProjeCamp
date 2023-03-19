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
    public class ContentManager : IContentService
    {

        EfContentDal _contentDal;

        public ContentManager(EfContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void Add(Content entity)
        {
            _contentDal.Add(entity);
        }

        public void Delete(Content entity)
        {
            _contentDal.Delete(entity);
        }

        public void Update(Content entity)
        {
            _contentDal.Update(entity);
        }

        public Content GetById(int id)
        {
            return _contentDal.GetById(x => x.ContentId == id);
        }

        public List<Content> GetList()
        {
            return _contentDal.GetList();
        }

        public List<Content> GetListByContentId(int id)
        {
            return _contentDal.GetList(x => x.HeadingId == id);
        }

        public List<Content> GetListByWriterId(int id)
        {
            return _contentDal.GetList(x => x.WriterId == id);
        }
    }
}

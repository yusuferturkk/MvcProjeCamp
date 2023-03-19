using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WriterManager : IWriterService
    {

        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public void Add(Writer entity)
        {
            _writerDal.Add(entity);
        }

        public void Delete(Writer entity)
        {
            _writerDal.Delete(entity);
        }

        public void Update(Writer entity)
        {
            _writerDal.Update(entity);
        }

        public Writer GetById(int id)
        {
            return _writerDal.GetById(x => x.WriterId == id);
        }

        public List<Writer> GetList()
        {
            return _writerDal.GetList();
        }
    }
}

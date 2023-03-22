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
    public class ImageFileManager : IImageFileService
    {

        IImageFileDal _imageFileDal;

        public ImageFileManager(IImageFileDal imageFileDal)
        {
            _imageFileDal = imageFileDal;
        }

        public void Add(ImageFile entity)
        {
            _imageFileDal.Add(entity);
        }

        public void Delete(ImageFile entity)
        {
            _imageFileDal.Delete(entity);
        }

        public void Update(ImageFile entity)
        {
            _imageFileDal.Update(entity);
        }

        public ImageFile GetById(int id)
        {
            return _imageFileDal.GetById(x => x.ImageId == id);
        }

        public List<ImageFile> GetList()
        {
            return _imageFileDal.GetList();
        }
    }
}

﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {

        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void Add(Message entity)
        {
            _messageDal.Add(entity);
        }

        public void Delete(Message entity)
        {
            _messageDal.Delete(entity);
        }

        public void Update(Message entity)
        {
            _messageDal.Update(entity);
        }

        public Message GetById(int id)
        {
            return _messageDal.GetById(x => x.MessageId == id);
        }

        public List<Message> GetListInbox()
        {
            return _messageDal.GetList(x => x.ReceiverMail == "admin@gmail.com");
        }

        public List<Message> GetListSendbox()
        {
            return _messageDal.GetList(x => x.SenderMail == "admin@gmail.com");
        }

        public List<Message> GetList()
        {
            throw new NotImplementedException();
        }
    }
}

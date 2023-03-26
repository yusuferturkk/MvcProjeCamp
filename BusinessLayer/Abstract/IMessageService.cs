using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService : IGenericService<Message>
    {
        List<Message> GetListInbox();
        List<Message> GetListSendbox();
        List<Message> GetListDraftbox();
        List<Message> GetListTrashbox();
    }
}

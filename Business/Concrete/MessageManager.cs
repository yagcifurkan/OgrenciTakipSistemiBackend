using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concretes;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public IResult Add(Message message)
        {
            _messageDal.Add(message);

            return new SuccessResult();
        }

        public IResult Update(Message message)
        {
            _messageDal.Update(message);

            return new SuccessResult();
        }

        public IResult Delete(Message message)
        {
            _messageDal.Delete(message);

            return new SuccessResult();
        }

        public IDataResult<Message> GetById(int id)
        {
            return new SuccessDataResult<Message>(_messageDal.Get(m => m.Id == id));
        }

        public IDataResult<List<Message>> GetAll()
        {
            return new SuccessDataResult<List<Message>>(_messageDal.GetAll());
        }

        public IDataResult<List<MessageDetailDto>> GetMessageDetailsByReceiverUserId(int receiverUserId)
        {
            return new SuccessDataResult<List<MessageDetailDto>>(_messageDal.GetMessageDetails(m => m.ReciverUserId == receiverUserId));
        }
    }
}

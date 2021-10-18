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
    public class ContactManager : IContactService
    {
        IContactDal _contacDal;

        public ContactManager(IContactDal contacDal)
        {
            _contacDal = contacDal;
        }

        public void ContactDelete(Contact contact)
        {
            _contacDal.Delete(contact);
        }

        public void ContactUpdate(Contact contact)
        {
            _contacDal.Update(contact);
        }

        public void ContactyAdd(Contact contact)
        {
            _contacDal.Insert(contact);
        }

        public Contact GetByID(int id)
        {
            return _contacDal.Get(x => x.ContactID == id);
        }

        public List<Contact> GetList()
        {
            return _contacDal.List();
        }
    }
}

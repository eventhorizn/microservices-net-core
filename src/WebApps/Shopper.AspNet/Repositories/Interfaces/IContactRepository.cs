using Shopper.AspNet.Entities;

namespace Shopper.AspNet.Repositories.Interfaces;

public interface IContactRepository
{
    Task<Contact> SendMessage(Contact contact);
    Task<Contact> Subscribe(string address);
}
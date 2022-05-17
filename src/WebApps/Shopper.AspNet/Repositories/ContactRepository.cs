using Shopper.AspNet.Data;
using Shopper.AspNet.Entities;
using Shopper.AspNet.Repositories.Interfaces;

namespace Shopper.AspNet.Repositories;

public class ContactRepository : IContactRepository
{
    protected readonly Context _dbContext;

    public ContactRepository(Context dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Contact> SendMessage(Contact contact)
    {
        _dbContext.Contacts.Add(contact);
        await _dbContext.SaveChangesAsync();
        return contact;
    }

    public async Task<Contact> Subscribe(string address)
    {
        // implement your business logic
        var newContact = new Contact
        {
            Email = address,
            Message = address,
            Name = address
        };

        _dbContext.Contacts.Add(newContact);
        await _dbContext.SaveChangesAsync();

        return newContact;
    }
}

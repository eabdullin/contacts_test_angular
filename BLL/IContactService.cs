namespace BLL
{
    public interface IContactService
    {
        Result CreateContact(IContactData data);
        Result EditContact(long id, IContactData data);
        Result DeleteContact(long id);
        Result UpdateContact(long contactId, IContactData data);
    }
}
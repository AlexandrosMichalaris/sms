using sms.Models.Database;

namespace sms.Repository.Interfaces;

public interface IMessageRepository
{
    public Task AddMessages(IEnumerable<Message> messages);
}

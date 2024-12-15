using sms.Data;
using sms.Models.Database;
using sms.Repository.Interfaces;

namespace sms.Repository;

public class MessageRepository : IMessageRepository
{
    private readonly IConfiguration _configuration;

    public MessageRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task AddMessages(IEnumerable<Message> messages)
    {
        try
        {
            using (var db = new DatabaseContext(_configuration))
            {
                db.Message.AddRange(messages);

                await db.SaveChangesAsync();
            }
        }
        catch (Exception e)
        {
            throw new ApplicationException($"Couldn't add messages in db. | {e.Message}");
        }
    }
}

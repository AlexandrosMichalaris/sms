using sms.Models.Database;

namespace sms.Models.Domain;

public class MessageRequest
{
    public string Message { get; set; }

    public int Vendor { get; set; }

    public Message ToDatabaseObject()
    {
        return new Message
        {
            MessageContent = this.Message,
            Vendor = this.Vendor,
        };
    }
}

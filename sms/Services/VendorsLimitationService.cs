using sms.Configuration;
using sms.Models.Domain;
using sms.Services.Interfaces;

namespace sms.Services;

public class VendorsLimitationService : IVendorsLimitationService
{
    public bool CheckLength(string message)
    {
        return message.Length <= Constants.MaxLength;
    }

    public List<MessageRequest> MessageSplitter(MessageRequest message)
    {
        if(message.Message.Length < Constants.SplitLength)
            return new List<MessageRequest> { message };

        var messages = new List<MessageRequest>();

        for(int i = 0; i < message.Message.Length; i += Constants.SplitLength)
        {
            messages.Add(new MessageRequest { Message = message.Message.Substring(i, Math.Min(Constants.SplitLength, message.Message.Length - i)), Vendor = message.Vendor });
        }

        return messages;
    }

    public bool IsGreekString(string message)
    {
        return message.All(c => IsGreekCharacter(c));
    }

    private bool IsGreekCharacter(char c)
    {
        return (c >= '\u0370' && c <= '\u03FF') || (c >= '\u1F00' && c <= '\u1FFF');
    }
}

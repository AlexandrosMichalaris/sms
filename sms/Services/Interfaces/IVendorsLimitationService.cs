using sms.Models.Domain;

namespace sms.Services.Interfaces;

public interface IVendorsLimitationService
{
    bool CheckLength(String message);

    bool IsGreekString(String message);

    List<MessageRequest> MessageSplitter(MessageRequest message);
}

using sms.Models.Domain;

namespace sms;

public interface ISend
{
    public IEnumerable<Vendor> Vendor { get; }

    public Task Send(MessageRequest message); 
}

using sms.Models.Domain;
using sms.Repository.Interfaces;
using sms.Services.Interfaces;

namespace sms;

public class SMSVendorCYService : ISend
{
    IEnumerable<Vendor> ISend.Vendor => new[] { Vendor.CY };

    private readonly IVendorsLimitationService _vendorsLimitation;
    private readonly IMessageRepository _repository;

    public SMSVendorCYService(
        IVendorsLimitationService vendorsLimitation,
        IMessageRepository repository)
    {
        _vendorsLimitation = vendorsLimitation;
        _repository = repository;
    }

    public async Task Send(MessageRequest message)
    {
        var messages = _vendorsLimitation.MessageSplitter(message);

        await _repository.AddMessages(messages.Select(s => s.ToDatabaseObject()));
    }
}

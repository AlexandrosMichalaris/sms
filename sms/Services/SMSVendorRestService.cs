using sms.Models.Domain;
using sms.Repository.Interfaces;
using sms.Services.Interfaces;

namespace sms;

public class SMSVendorRestService : ISend
{
    IEnumerable<Vendor> ISend.Vendor => new[] { Vendor.Rest };

    private readonly IVendorsLimitationService _vendorsLimitation;
    private readonly IMessageRepository _repository;

    public SMSVendorRestService(
        IVendorsLimitationService allVendorsLimitation,
        IMessageRepository repository)
    {
        _vendorsLimitation = allVendorsLimitation;
        _repository = repository;
    }

    public async Task Send(MessageRequest message)
    {
        if (!_vendorsLimitation.CheckLength(message.Message))
            throw new Exception($"Message is invalid for vendor: {typeof(SMSVendorRestService)}");

        await _repository.AddMessages(new[] { message.ToDatabaseObject() });
    }
}

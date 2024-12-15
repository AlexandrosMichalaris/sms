using sms.Models.Domain;
using sms.Repository.Interfaces;
using sms.Services.Interfaces;

namespace sms;

public class SMSVendorGRService : ISend
{
    private readonly IVendorsLimitationService _vendorsLimitation;
    private readonly IMessageRepository _repository;

    IEnumerable<Vendor> ISend.Vendor => new[] { Vendor.GR };

    public SMSVendorGRService(
        IVendorsLimitationService allVendorsLimitation,
        IMessageRepository repository)
    {
        _vendorsLimitation = allVendorsLimitation;
        _repository = repository;
    }

    public Task Send(MessageRequest message)
    {
        try
        {
            if (!_vendorsLimitation.IsGreekString(message.Message) || !_vendorsLimitation.CheckLength(message.Message))
                throw new Exception($"Message is invalid for vendor: {typeof(SMSVendorGRService)}");


            _repository.AddMessages(new[] { message.ToDatabaseObject() });

            return Task.CompletedTask;

        }
        catch (Exception ex)
        {
            throw;
        }
    }


}

using sms.Models.Domain;

namespace sms.Services.Strategy;

public interface ISMSVendorStrategy
{
    ISend GetVendor(Vendor vendor);
}

public class SMSVendorStrategy : ISMSVendorStrategy
{
    private readonly IEnumerable<ISend> _senders;

    public SMSVendorStrategy(IEnumerable<ISend> senders)
    {
        _senders = senders;
    }

    public ISend GetVendor(Vendor vendor)
    {
        var strategy = _senders.SingleOrDefault(x => x.Vendor.Contains(vendor));

        if (strategy is null)
            throw new ApplicationException("Invalid strategy type");


        return strategy;
    }
}

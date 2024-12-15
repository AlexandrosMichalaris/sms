using System.ComponentModel.DataAnnotations;

namespace sms.Models.Database;

public class Message
{
    [Key]
    public int Id { get; set; }

    public string MessageContent { get; set; }

    public int Vendor { get; set; }
}

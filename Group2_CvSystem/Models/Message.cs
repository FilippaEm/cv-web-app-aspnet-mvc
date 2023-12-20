using System;
using System.Collections.Generic;

namespace Group2_CvSystem.Models;

public partial class Message
{
    public int MessageId { get; set; }

    public DateTime? SentTime { get; set; }

    public string? Content { get; set; }

    public bool? Read { get; set; }

    public string? Sender { get; set; }

    public string? Receiver { get; set; }

    public virtual User? ReceiverNavigation { get; set; }

    public virtual User? SenderNavigation { get; set; }
}

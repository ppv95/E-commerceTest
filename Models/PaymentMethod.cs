using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class PaymentMethod: AuditClass
{
    public int ID { get; set; }
    public string Name { get; set; }
}

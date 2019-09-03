using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public abstract class AuditClass
{
    public int UserID { get; set; }
    public DateTime  CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}
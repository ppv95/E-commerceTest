using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

public class EcommerceDBContext : DbContext
{

    public EcommerceDBContext()
    {
        
    }

    public EcommerceDBContext(DbContextOptions<EcommerceDBContext> options) :base(options)
    {

    }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<PaymentMethod> PaymentMethods { get; set; }
}
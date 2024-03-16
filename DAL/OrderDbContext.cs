using OrdersAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace OrdersAPI.DAL
{

public class OrderDbContext : DbContext
{
    public DbSet<Order> Orders{get; set;}
    public DbSet<Order_Items> Order_Items{get; set;}

 
     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("Order.db");
    }

}
}
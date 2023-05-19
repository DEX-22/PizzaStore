using Microsoft.EntityFrameworkCore;

namespace PizzaStore.Models;
    
    
class PizzaDb : DbContext{

    public int Id { get; set;}
    public string ? Name { get; set;}
    public string ? Description { get; set;}

    public PizzaDb(DbContextOptions options) : base(options) { }
    public DbSet<PizzaDb> Pizzas { get; set; } = null!;

    // public static void insertPizza(PizzaDb pizza){
        
    //     await db.pizzas.AddAsync( pizza );
    //     await PizzaDb.ToListAsync()
    // }

    
}
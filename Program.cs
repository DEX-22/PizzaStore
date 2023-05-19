using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using PizzaStore.DB;
using PizzaStore.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( c => {
    c.SwaggerDoc("v1",new OpenApiInfo { Title = "aa" , Description = "eee" , Version = "v1" } );
});
builder.Services.AddDbContext<PizzaDb>(
    options => options.UseInMemoryDatabase("items")
);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI( c => {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "PizzaStore API v1");
});

app.MapGet("/", () => "Hello perro!");
app.MapGet("/pizzas/{id}", (int id) => PizzaDB.GetPizza(id));
app.MapGet("/pizzas", async (PizzaDb db) => await db.Pizzas.ToListAsync() );
app.MapPost("/pizzas", (Pizza pizza) => PizzaDB.CreatePizza(pizza));
app.MapPut("/pizzas", (Pizza pizza) => PizzaDB.UpdatePizza(pizza));
app.MapDelete("/pizzas/{id}", (int id) => PizzaDB.RemovePizza(id));


app.Run();

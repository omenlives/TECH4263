using EquipmentAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var equipments = new List<Equipment>();

app.MapPost("/createequipment", (string name, string category, string status, string location) =>
{
    var equipment = new Equipment(name, category, status, location);


    equipments.Add(equipment);

    return Results.Created($"/getequipment/{equipment.Id}", equipment);
})
   .WithName("CreateEquipment")
   .WithOpenApi();


app.MapGet("/getequipments", () => 
{ 
    return Results.Ok(equipments);
})
   .WithName("GetEquipments")
   .WithOpenApi();

app.MapGet("/getequipment/{id}", (int id) => 
{
 var equipment = equipments.FirstOrDefault(e => e.Id == id);
    if (equipment == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(equipment);
})
   .WithName("GetEquipmentById")
   .WithOpenApi();


app.Run();



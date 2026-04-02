using EquipmentAPI.Data;
using EquipmentAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;


// POST /students
app.MapPost("/equipments", async (CreateEquipmentDto dto, AppDbContext context) =>
{
    var equipment = new Equipment(dto.Name, dto.Category, dto.Status, dto.Location);

    context.Equipments.Add(equipment);
    await context.SaveChangesAsync();

    return Results.Created($"/equipments/{equipment.Id}", new EquipmentResponseDto
    {
        Id = equipment.Id,
        Name = dto.Name,
        Category = dto.Category,
        Status = dto.Status,
        Location = dto.Location
    });
}).WithName("CreateEquipment").WithOpenApi();

app.MapGet("/equipments", async (AppDbContext context) =>
{
    var equipments = await context.Equipments.ToListAsync();



    return Results.Ok(equipments.Select(s => new EquipmentResponseDto
    {
        Id = s.Id,
        Name = s.Name,
        Category = s.Category,
        Status = s.Status,
        Location = s.Location
    }));
}).WithName("GetEquipments").WithOpenApi();

// GET /equipments/{id}
app.MapGet("/equipments/{id:int:min(1)}", async (int id, AppDbContext context) =>
{
    var equipment = await context.Equipments.FindAsync(id);

    if (equipment is null)
        return Results.NotFound();

    return Results.Ok(new EquipmentResponseDto
    {
        Id = equipment.Id,
        Name = equipment.Name,
        Category = equipment.Category,
        Status = equipment.Status,
        Location = equipment.Location
    });
}).WithName("GetEquipmentById").WithOpenApi();
app.Run();
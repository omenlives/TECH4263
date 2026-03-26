using EquipmentAPI.Models;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;

// ── GET /students ──────────────────────────────────────────────────────────
app.MapGet("/equipments", async () =>
{
    var students = new List<EquipmentResponseDto>();

    using var conn = new SqlConnection(connectionString);
    await conn.OpenAsync();

    using var cmd = new SqlCommand("SELECT Id, Name, Category, Status, Location FROM Equipments", conn);
    using var reader = await cmd.ExecuteReaderAsync();

    while (await reader.ReadAsync())
    {
        students.Add(new EquipmentResponseDto
        {
            Id = reader.GetInt32(reader.GetOrdinal("Id")),
            Name = reader.GetString(reader.GetOrdinal("Name")),
            Category = reader.GetString(reader.GetOrdinal("Category")),
            Status = reader.GetString(reader.GetOrdinal("Status")),
            Location = reader.GetString(reader.GetOrdinal("Location"))
        });
    }

    return Results.Ok(students);
}).WithName("GetStudents").WithOpenApi();

// ── GET /students/{id} ─────────────────────────────────────────────────────
app.MapGet("/equipments/{id:int:min(1)}", async (int id) =>
{
    using var conn = new SqlConnection(connectionString);
    await conn.OpenAsync();

    using var cmd = new SqlCommand(
        "SELECT Id, Name, Category, Status, Location FROM Equipments WHERE Id = @Id", conn);
    cmd.Parameters.AddWithValue("@Id", id);

    using var reader = await cmd.ExecuteReaderAsync();

    if (!await reader.ReadAsync()) return Results.NotFound();

    return Results.Ok(new EquipmentResponseDto
    {
        Id = reader.GetInt32(reader.GetOrdinal("Id")),
        Name = reader.GetString(reader.GetOrdinal("Name")),
        Category = reader.GetString(reader.GetOrdinal("Category")),
        Status = reader.GetString(reader.GetOrdinal("Status")),
        Location = reader.GetString(reader.GetOrdinal("Location"))
    });
}).WithName("GetEquipmentById").WithOpenApi();

// ── POST /students ─────────────────────────────────────────────────────────
app.MapPost("/equipments", async (CreateEquipmentDto dto) =>
{
    using var connection = new SqlConnection(connectionString);
    await connection.OpenAsync();

    // OUTPUT INSERTED.Id returns the auto-generated Id from SQL Server
    using var command = new SqlCommand(
        @"INSERT INTO Equipments (Name, Category, Status, Location)
          OUTPUT INSERTED.Id
          VALUES (@Name, @Category, @Status, @Location)", connection);

    command.Parameters.AddWithValue("@Name", dto.Name);
    command.Parameters.AddWithValue("@Category", dto.Category);
    command.Parameters.AddWithValue("@Status", dto.Status);
    command.Parameters.AddWithValue("@Location", dto.Location);

    // ExecuteScalarAsync returns the single value from OUTPUT INSERTED.Id
    var newId = (int)(await command.ExecuteScalarAsync())!;

    return Results.Created($"/equipments/{newId}", new EquipmentResponseDto
    {
        Id = newId,
        Name = dto.Name,
        Category = dto.Category,
        Status = dto.Status,
        Location = dto.Location
    });
}).WithName("CreateEquipment").WithOpenApi();

// ── PUT /students/{id} ─────────────────────────────────────────────────────
app.MapPut("/equipments/{id:int:min(1)}", async (int id, CreateEquipmentDto dto) =>
{
    using var conn = new SqlConnection(connectionString);
    await conn.OpenAsync();

    using var cmd = new SqlCommand(
        @"UPDATE Students
          SET Name = @Name, Age = @Age, Major = @Major
          WHERE Id = @Id", conn);

    cmd.Parameters.AddWithValue("@Name", dto.Name);
    cmd.Parameters.AddWithValue("@Category", dto.Category);
    cmd.Parameters.AddWithValue("@Status", dto.Status);
    cmd.Parameters.AddWithValue("@Location", dto.Location);
    cmd.Parameters.AddWithValue("@Id", id);

    int rows = await cmd.ExecuteNonQueryAsync();
    return rows == 0 ? Results.NotFound() : Results.NoContent();
}).WithName("UpdateEquipment").WithOpenApi();

// ── DELETE /students/{id} ──────────────────────────────────────────────────
app.MapDelete("/equipments/{id:int:min(1)}", async (int id) =>
{
    using var conn = new SqlConnection(connectionString);
    await conn.OpenAsync();

    using var cmd = new SqlCommand(
        "DELETE FROM Students WHERE Id = @Id", conn);
    cmd.Parameters.AddWithValue("@Id", id);

    int rows = await cmd.ExecuteNonQueryAsync();
    return rows == 0 ? Results.NotFound() : Results.NoContent();
}).WithName("DeleteEquipment").WithOpenApi();

app.Run();
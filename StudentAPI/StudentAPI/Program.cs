using StudentAPI.Models;
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

var students = new List<Student>(); // In-memory list to store students for demo purposes

app.MapPost("/createstudent", (string name, int age, string major) =>
{
    var student = new Student(name, age, major);

    students.Add(student);

    // In a real application, you'd save the student to a database here
    return Results.Created($"/createstudent/{student.Id}", student);
})
.WithName("CreateStudent")
.WithOpenApi();

app.MapGet("/getstudents", () =>
{
    // In a real application, you'd retrieve students from a database here
    return Results.Ok(students);
})
.WithName("GetStudents")
.WithOpenApi();

app.MapGet("/getstudent/{id}", (int id) =>
{
    var student = students.FirstOrDefault(s => s.Id == id);
    if (student == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(student);
}).
WithName("GetStudentById").
WithOpenApi();

app.Run();



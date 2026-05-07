using CRMS.Api.Auth;
using CRMS.Api.Data;
using CRMS.Api.Helpers;
using CRMS.Api.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("basic", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "basic",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Enter your username and password"
    });
}); builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuthentication("BasicAuth")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthHandler>("BasicAuth", null);

builder.Services.AddAuthorization();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

int GetUserId(ClaimsPrincipal user)
{
    return int.Parse(user.FindFirstValue(ClaimTypes.NameIdentifier)!);
}

// --------------------
// AUTH
// --------------------

app.MapPost("/auth/register", async (RegisterDto dto, AppDbContext db) =>
{
    bool usernameExists = await db.Users.AnyAsync(u => u.Username == dto.Username);

    if (usernameExists)
    {
        return Results.Conflict("Username already exists.");
    }

    var user = new User
    {
        Username = dto.Username,
        PasswordHash = PasswordHasher.Hash(dto.Password),
        Role = "Customer",
        FullName = dto.FullName,
        Email = dto.Email,
        Phone = dto.Phone,
        CreatedAt = DateTime.Now
    };

    db.Users.Add(user);
    await db.SaveChangesAsync();

    return Results.Ok(user);
})
.WithName("Register")
.WithOpenApi();

app.MapGet("/users", async (AppDbContext db) =>
{
    var users = await db.Users
        .Select(u => new
        {
            u.Id,
            u.Username,
            u.Role,
            u.FullName,
            u.Email,
            u.Phone,
            u.CreatedAt
        })
        .ToListAsync();

    return Results.Ok(users);
})
.RequireAuthorization(policy => policy.RequireRole("Admin"))
.WithName("GetUsers")
.WithOpenApi();

// --------------------
// CARS
// --------------------

app.MapGet("/cars", async (AppDbContext db) =>
{
    var cars = await db.Cars.ToListAsync();

    return Results.Ok(cars);
})
.RequireAuthorization()
.WithName("GetCars")
.WithOpenApi();

app.MapGet("/cars/{id:int}", async (int id, AppDbContext db) =>
{
    var car = await db.Cars.FindAsync(id);

    if (car == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(car);
})
.RequireAuthorization()
.WithName("GetCarById")
.WithOpenApi();

app.MapPost("/cars", async (CarDto dto, AppDbContext db) =>
{
    var car = new Car
    {
        Make = dto.Make,
        Model = dto.Model,
        Year = dto.Year,
        Category = dto.Category,
        DailyRate = dto.DailyRate,
        LicencePlate = dto.LicencePlate,
        Color = dto.Color,
        Status = dto.Status
    };

    db.Cars.Add(car);
    await db.SaveChangesAsync();

    return Results.Ok(car);
})
.RequireAuthorization(policy => policy.RequireRole("Admin"))
.WithName("AddCar")
.WithOpenApi();

app.MapPut("/cars/{id:int}", async (int id, CarDto dto, AppDbContext db) =>
{
    var car = await db.Cars.FindAsync(id);

    if (car == null)
    {
        return Results.NotFound();
    }

    car.Make = dto.Make;
    car.Model = dto.Model;
    car.Year = dto.Year;
    car.Category = dto.Category;
    car.DailyRate = dto.DailyRate;
    car.LicencePlate = dto.LicencePlate;
    car.Color = dto.Color;
    car.Status = dto.Status;

    await db.SaveChangesAsync();

    return Results.Ok(car);
})
.RequireAuthorization(policy => policy.RequireRole("Admin"))
.WithName("UpdateCar")
.WithOpenApi();

app.MapDelete("/cars/{id:int}", async (int id, AppDbContext db) =>
{
    var car = await db.Cars.FindAsync(id);

    if (car == null)
    {
        return Results.NotFound();
    }

    db.Cars.Remove(car);
    await db.SaveChangesAsync();

    return Results.Ok("Car deleted.");
})
.RequireAuthorization(policy => policy.RequireRole("Admin"))
.WithName("DeleteCar")
.WithOpenApi();

// --------------------
// BOOKINGS
// --------------------

app.MapPost("/bookings", async (BookingDto dto, AppDbContext db, ClaimsPrincipal user) =>
{
    int customerId = GetUserId(user);

    var car = await db.Cars.FindAsync(dto.CarId);

    if (car == null)
    {
        return Results.NotFound("Car not found.");
    }

    if (dto.ReturnDate <= dto.PickupDate)
    {
        return Results.BadRequest("Return date must be after pickup date.");
    }

    bool overlap = await db.Bookings.AnyAsync(b =>
        b.CarId == dto.CarId &&
        (b.Status == "Approved" || b.Status == "Active") &&
        dto.PickupDate < b.ReturnDate &&
        dto.ReturnDate > b.PickupDate);

    if (overlap)
    {
        return Results.Conflict("Car is already booked for those dates.");
    }

    int days = (dto.ReturnDate.Date - dto.PickupDate.Date).Days;

    if (days < 1)
    {
        days = 1;
    }

    var booking = new Booking
    {
        CustomerId = customerId,
        CarId = dto.CarId,
        PickupDate = dto.PickupDate,
        ReturnDate = dto.ReturnDate,
        TotalAmount = car.DailyRate * days,
        Status = "Pending",
        CreatedAt = DateTime.Now
    };

    db.Bookings.Add(booking);
    await db.SaveChangesAsync();

    return Results.Ok(booking);
})
.RequireAuthorization(policy => policy.RequireRole("Customer"))
.WithName("CreateBooking")
.WithOpenApi();

app.MapGet("/bookings/my", async (AppDbContext db, ClaimsPrincipal user) =>
{
    int customerId = GetUserId(user);

    var bookings = await db.Bookings
        .Include(b => b.Car)
        .Where(b => b.CustomerId == customerId)
        .ToListAsync();

    return Results.Ok(bookings);
})
.RequireAuthorization(policy => policy.RequireRole("Customer"))
.WithName("GetMyBookings")
.WithOpenApi();

app.MapDelete("/bookings/{id:int}", async (int id, AppDbContext db, ClaimsPrincipal user) =>
{
    int customerId = GetUserId(user);

    var booking = await db.Bookings
        .FirstOrDefaultAsync(b => b.Id == id && b.CustomerId == customerId);

    if (booking == null)
    {
        return Results.NotFound();
    }

    if (booking.Status != "Pending")
    {
        return Results.BadRequest("Only pending bookings can be cancelled.");
    }

    booking.Status = "Cancelled";

    await db.SaveChangesAsync();

    return Results.Ok("Booking cancelled.");
})
.RequireAuthorization(policy => policy.RequireRole("Customer"))
.WithName("CancelBooking")
.WithOpenApi();

app.MapGet("/bookings", async (AppDbContext db) =>
{
    var bookings = await db.Bookings
        .Include(b => b.Customer)
        .Include(b => b.Car)
        .ToListAsync();

    return Results.Ok(bookings);
})
.RequireAuthorization(policy => policy.RequireRole("Staff", "Admin"))
.WithName("GetBookings")
.WithOpenApi();

app.MapPut("/bookings/{id:int}/approve", async (int id, AppDbContext db, ClaimsPrincipal user) =>
{
    var booking = await db.Bookings.FindAsync(id);

    if (booking == null)
    {
        return Results.NotFound();
    }

    if (booking.Status != "Pending")
    {
        return Results.BadRequest("Only pending bookings can be approved.");
    }

    booking.Status = "Approved";
    booking.ApprovedById = GetUserId(user);

    await db.SaveChangesAsync();

    return Results.Ok("Booking approved.");
})
.RequireAuthorization(policy => policy.RequireRole("Staff", "Admin"))
.WithName("ApproveBooking")
.WithOpenApi();

app.MapPut("/bookings/{id:int}/reject", async (int id, AppDbContext db, ClaimsPrincipal user) =>
{
    var booking = await db.Bookings.FindAsync(id);

    if (booking == null)
    {
        return Results.NotFound();
    }

    if (booking.Status != "Pending")
    {
        return Results.BadRequest("Only pending bookings can be rejected.");
    }

    booking.Status = "Rejected";
    booking.ApprovedById = GetUserId(user);

    await db.SaveChangesAsync();

    return Results.Ok("Booking rejected.");
})
.RequireAuthorization(policy => policy.RequireRole("Staff", "Admin"))
.WithName("RejectBooking")
.WithOpenApi();

app.MapPut("/bookings/{id:int}/active", async (int id, AppDbContext db) =>
{
    var booking = await db.Bookings
        .Include(b => b.Car)
        .FirstOrDefaultAsync(b => b.Id == id);

    if (booking == null)
    {
        return Results.NotFound();
    }

    if (booking.Status != "Approved")
    {
        return Results.BadRequest("Only approved bookings can become active.");
    }

    booking.Status = "Active";

    if (booking.Car != null)
    {
        booking.Car.Status = "Rented";
    }

    await db.SaveChangesAsync();

    return Results.Ok("Booking is now active.");
})
.RequireAuthorization(policy => policy.RequireRole("Staff", "Admin"))
.WithName("ActivateBooking")
.WithOpenApi();

app.MapPut("/bookings/{id:int}/complete", async (int id, AppDbContext db) =>
{
    var booking = await db.Bookings
        .Include(b => b.Car)
        .FirstOrDefaultAsync(b => b.Id == id);

    if (booking == null)
    {
        return Results.NotFound();
    }

    if (booking.Status != "Active")
    {
        return Results.BadRequest("Only active bookings can be completed.");
    }

    booking.Status = "Completed";

    if (booking.Car != null)
    {
        booking.Car.Status = "Available";
    }

    await db.SaveChangesAsync();

    return Results.Ok("Booking completed.");
})
.RequireAuthorization(policy => policy.RequireRole("Staff", "Admin"))
.WithName("CompleteBooking")
.WithOpenApi();


// --------------------
// SEED DATA
// --------------------

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    db.Database.Migrate();

    if (!db.Users.Any(u => u.Username == "customer1"))
    {
        db.Users.Add(new User
        {
            Username = "customer1",
            PasswordHash = PasswordHasher.Hash("Password123"),
            Role = "Customer",
            FullName = "Customer One",
            Email = "customer1@test.com",
            Phone = "901-555-1111",
            CreatedAt = DateTime.Now
        });
    }

    if (!db.Users.Any(u => u.Username == "staff1"))
    {
        db.Users.Add(new User
        {
            Username = "staff1",
            PasswordHash = PasswordHasher.Hash("Password123"),
            Role = "Staff",
            FullName = "Staff One",
            Email = "staff1@test.com",
            Phone = "901-555-2222",
            CreatedAt = DateTime.Now
        });
    }

    if (!db.Users.Any(u => u.Username == "admin1"))
    {
        db.Users.Add(new User
        {
            Username = "admin1",
            PasswordHash = PasswordHasher.Hash("Password123"),
            Role = "Admin",
            FullName = "Admin One",
            Email = "admin1@test.com",
            Phone = "901-555-3333",
            CreatedAt = DateTime.Now
        });
    }

    await db.SaveChangesAsync();


if (!db.Cars.Any())
    {
        db.Cars.Add(new Car
        {
            Make = "Toyota",
            Model = "Camry",
            Year = 2022,
            Category = "Sedan",
            DailyRate = 55.00m,
            LicencePlate = "ABC123",
            Color = "Silver",
            Status = "Available"
        });

        db.Cars.Add(new Car
        {
            Make = "Ford",
            Model = "Explorer",
            Year = 2021,
            Category = "SUV",
            DailyRate = 85.00m,
            LicencePlate = "SUV456",
            Color = "Black",
            Status = "Available"
        });

        await db.SaveChangesAsync();
    }
}

app.Run();
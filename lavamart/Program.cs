using lavamart.Data;
using lavamart.Data.models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region dbconnection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
#endregion


#region identity
builder.Services.AddIdentity<Users, IdentityRole>(
    option =>
    {
        option.Password.RequiredLength = 8;
        option.Password.RequireUppercase = true;
        option.Password.RequireNonAlphanumeric = true;
        option.User.RequireUniqueEmail = true;
    }
    ).AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddMemoryCache();

#endregion

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();

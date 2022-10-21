global using PMUKTest.Shared.Entities;
global using Microsoft.EntityFrameworkCore;
global using PMUKTest.Server.Data;
global using PMUKTest.Server.Services;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


var dbConnectionString = builder.Configuration.GetConnectionString("PmukTestMySql");
builder.Services.AddDbContext<PmukTestContext>(options =>
{
    options.UseMySql(dbConnectionString, ServerVersion.AutoDetect(dbConnectionString));
});

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
builder.Services.AddHttpContextAccessor();


var app = builder.Build();

app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();

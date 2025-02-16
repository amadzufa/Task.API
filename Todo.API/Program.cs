var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ Enable CORS (Allow all origins for testing)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()  // Allow requests from any frontend
                  .AllowAnyMethod()   // Allow GET, POST, PUT, DELETE
                  .AllowAnyHeader();  // Allow all headers
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ✅ Use CORS before Authorization
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();

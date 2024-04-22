using SignalR_ServerClient.Business;
using SignalR_ServerClient.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.WithOrigins("http://127.0.0.1:5500") // Update this with your client's origin
        .AllowAnyMethod()
        .AllowAnyHeader()
        .SetIsOriginAllowed((host) => true)
        .AllowCredentials(); // Allow credentials
}));
// SignalR 
builder.Services.AddSignalR();
builder.Services.AddTransient<MyBusiness>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapHub<MyHub>("/myhub");
app.MapHub<MessageHub>("/messagehub");
app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("MyPolicy");
app.MapControllers();

app.Run();

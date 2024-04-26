using crud_with_MiniIO.ConfigDI;
using Microsoft.Extensions.Options;
var myPolicy = "";
var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.
builder.Services.DiConfiguration(configuration);
builder.Services.AddControllers();
builder.Services.AddCors(Options =>
{
    Options.AddPolicy(name : myPolicy,
                        policy =>
                        {
                            policy.WithOrigins("http://localhost:5288", "https://localhost:7043");
                        });
});
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
// app.UseCors(myPolicy);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

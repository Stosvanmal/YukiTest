using YukiTest.API.Configuration;
using YukiTest.Application;
using YukiTest.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

YukiAPIConfiguration.AddRegistration(builder.Services);
ApplicationRegistration.AddRegistration(builder.Services);
InfrastructureRegistration.AddRegistration(builder.Services,builder.Configuration);

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



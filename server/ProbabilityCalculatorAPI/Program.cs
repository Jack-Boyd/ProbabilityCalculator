using ProbabilityCalculatorAPI.Application.Handlers;
using ProbabilityCalculatorAPI.Infrastructure.Interfaces;
using ProbabilityCalculatorAPI.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IEventLogger, EventLogger>();
builder.Services.AddTransient<GetCalculationLogsQueryHandler>();
builder.Services.AddTransient<CalculateCommandHandler>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => {
    options.AddPolicy("AllowFrontend",
        policy => policy
            .WithOrigins("http://localhost:3000")
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowFrontend");
app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();

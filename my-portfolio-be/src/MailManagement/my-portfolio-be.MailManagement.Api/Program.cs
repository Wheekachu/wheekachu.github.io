using my_portfolio_be.MailManagement.Application.Configuration;
using my_portfolio_be.MailManagement.Application.Service;
using my_portfolio_be.Shared.Cors;
using System.Globalization;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// 1. Define a CORS policy name
var myAllowSpecificOrigins = "_myAllowSpecificOrigins";

var config = builder.Configuration;

// Add services to the container.


builder.Services.AddControllers();

builder.Services.Configure<MailConfiguration>(builder.Configuration.GetSection("MailConfiguration"));

// Register the email service
builder.Services.AddTransient<IEmailService, EmailService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:5173", "http://localhost:3000") // Add your React URLs here
                                .AllowAnyHeader()
                                .WithMethods(CorsConfiguration.AllowedMethods);
                      });
});

builder.Services.AddRateLimiter(options =>
{
    // Explicitly set the rejection status code to 429
    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

    options.OnRejected = async (context, cancellationToken) =>
    {
        context.HttpContext.Response.StatusCode = StatusCodes.Status429TooManyRequests;

        if (context.Lease.TryGetMetadata(MetadataName.RetryAfter, out var retryAfter))
        {
            context.HttpContext.Response.Headers.RetryAfter = retryAfter.TotalSeconds.ToString(CultureInfo.InvariantCulture);
        }

        await context.HttpContext.Response.WriteAsync("Too many requests. Please try again later.", cancellationToken);
    };

    options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(context =>
    {
        var identity = context.User.Identity?.Name ?? "anonymous";

        return RateLimitPartition.GetTokenBucketLimiter(
            identity,
            _ => new TokenBucketRateLimiterOptions
            {
                TokenLimit = 100,
                TokensPerPeriod = 100,
                ReplenishmentPeriod = TimeSpan.FromSeconds(1),
                AutoReplenishment = true
            });
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(myAllowSpecificOrigins);

app.UseRateLimiter();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

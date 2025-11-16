using SignalR_TestProje.Business;
using SignalR_TestProje.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddControllers();

builder.Services.AddSignalR();
// Client ayrý proje (farklý port) olduðu için CORS gerekli
builder.Services.AddCors( options => 
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials()
              .SetIsOriginAllowed(origin => true);
    });
});

builder.Services.AddTransient<MyBusiness>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
 app.UseExceptionHandler("/Error");
 app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors();
app.UseRouting();


app.UseAuthorization();

app.MapControllers();

app.MapRazorPages();
app.MapHub<ChatHub>("/chatHub");



app.Run();

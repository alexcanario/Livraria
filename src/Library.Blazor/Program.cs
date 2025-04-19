using Library.Blazor.Components;
using Library.Infra.Data;
using Library.Iof;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddInfraStructure(builder.Configuration);

var app = builder.Build();

CreateDatabase(app);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
return;

static void CreateDatabase(WebApplication app)
{
	var serviceScoped = app.Services.CreateScope();
	var dbContext = serviceScoped.ServiceProvider.GetRequiredService<LibraryDbContext>();
	dbContext.Database.EnsureCreated();
}
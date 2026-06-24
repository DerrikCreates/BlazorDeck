using System.Text.Json;
using BlazorDeck.Components;
using BlazorDeck.Components.Config;
using MudBlazor.Services;

var opts = new JsonSerializerOptions() { WriteIndented = true };
var json = JsonSerializer.Serialize(
    new PageConfig() { Buttons = [new ButtonConfig()], GridSizeX = 8, GridSizeY = 4, Name = "Example" }, opts);
//File.WriteAllText("./grid-pages/ExamplePage.json", json);

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<ClientInputInterop>();

GridConfig gridConfig = new();
gridConfig.Load();

builder.Services.AddSingleton(gridConfig);

builder.Services.AddMudServices();

builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
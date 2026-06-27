using System.Text.Json;

namespace BlazorDeck.Services;

public class ConfigWatcher
{
    public Action<BlazorDeckConfig> OnConfigChanged { get; set; }

    private FileSystemWatcher _watcher = new("./", "BlazorDeck.json");

    public ConfigWatcher()
    {
        _watcher.NotifyFilter = NotifyFilters.LastWrite;

        _watcher.Changed += Changed;
    }

    private BlazorDeckConfig _config;

    public BlazorDeckConfig GetConfig()
    {
        if (_config is null)
        {
            _config = JsonSerializer.Deserialize<BlazorDeckConfig>(File.ReadAllText("./BlazorDeck.json"));
        }

        return _config;
    }

    private void Changed(object sender, FileSystemEventArgs e)
    {
        var config = JsonSerializer.Deserialize<BlazorDeckConfig>(File.ReadAllText(e.FullPath));
        if (config is not null)
        {
            OnConfigChanged?.Invoke(config);
        }
    }
}
using System.Text.Json;
using BlazorDeck.Components.Config;

public class GridConfig
{
    public Dictionary<string, PageConfig> Pages = [];

    public void Save()
    {
        var opts = new JsonSerializerOptions() { WriteIndented = true };
        foreach (var pageConfig in Pages)
        {
            try
            {
                File.WriteAllText(pageConfig.Key, JsonSerializer.Serialize(pageConfig.Value, opts));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                continue;
            }
        }
    }

    public void Load()
    {
        var configs = Directory.GetFiles("./grid-pages/", "*.json");

        foreach (var config in configs)
        {
            try
            {
                var json = File.ReadAllText(config);
                var page = JsonSerializer.Deserialize<PageConfig>(json);
                if (page is null)
                {
                    Console.WriteLine($"Config: {config}, produced a null object, skipping");
                    continue;
                }

                Pages.Add(config, page);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Config: {config} ERROR, skipping, exception: {e}");
                continue;
            }
        }
    }
}
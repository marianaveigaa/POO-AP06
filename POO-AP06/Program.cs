-AP06.Servicos;
using Microsoft.Extensions.Configuration;

var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

Directory.CreateDirectory("Data");

InitializeSampleData(config);

var menuService = new MenuService(config);
await menuService.ShowMainMenuAsync();

static void InitializeSampleData(IConfiguration config)
{
    var produtoRepo = new ProdutoRepository(config);
    if (!produtoRepo.GetAll().Any())
    {
        produtoRepo.Add(new Produto { Nome = "Produto Exemplo", Preco = 9.99m, Estoque = 10 });
    }
}
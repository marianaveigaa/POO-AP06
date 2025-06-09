using ConsoleApp.Models;
using ConsoleApp.Repositories;
using Microsoft.Extensions.Configuration;

namespace ConsoleApp.Services;

public class Produto
{
    private readonly ProdutoRepository _repository;

    public Produto(IConfiguration config)
    {
        _repository = new ProdutoRepository(config);
    }

    public async Task ShowMenuAsync()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== GERENCIAMENTO DE PRODUTOS ===");
            Console.WriteLine("1. Listar Todos");
            Console.WriteLine("2. Adicionar Novo");
            Console.WriteLine("3. Editar");
            Console.WriteLine("4. Remover");
            Console.WriteLine("5. Voltar");
            Console.Write("Escolha: ");

            switch (Console.ReadLine())
            {
                case "1":
                    ListarProdutos();
                    break;
                case "2":
                    await AdicionarProdutoAsync();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }

    private void ListarProdutos()
    {
        var produtos = _repository.GetAll();
        Console.WriteLine("\n=== LISTA DE PRODUTOS ===");
        foreach (var p in produtos)
        {
            Console.WriteLine($"{p.Id} - {p.Nome} (R${p.Preco}) - Estoque: {p.Estoque}");
        }
    }

    private async Task AdicionarProdutoAsync()
    {
        Console.Write("\nNome do produto: ");
        var nome = Console.ReadLine();

        Console.Write("Preço: ");
        var preco = decimal.Parse(Console.ReadLine());

        Console.Write("Estoque inicial: ");
        var estoque = int.Parse(Console.ReadLine());

        _repository.Add(new Produto
        {
            Nome = nome,
            Preco = preco,
            Estoque = estoque
        });

        Console.WriteLine("Produto adicionado com sucesso!");
    }
}
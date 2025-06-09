using ConsoleApp.Models;
using ConsoleApp.Repositories;
using Microsoft.Extensions.Configuration;

namespace ConsoleApp.Services;

public class PacienteService
{
    private readonly PacienteRepository _repository;

    public PacienteService(IConfiguration config)
    {
        _repository = new PacienteRepository(config);
    }

    public async Task ShowMenuAsync()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== GERENCIAMENTO DE PACIENTES ===");
            Console.WriteLine("1. Listar Todos");
            Console.WriteLine("2. Adicionar Novo");
            Console.WriteLine("3. Buscar por Faixa Etária");
            Console.WriteLine("4. Voltar");
            Console.Write("Escolha: ");

            switch (Console.ReadLine())
            {
                case "1":
                    ListarPacientes();
                    break;
                case "2":
                    await AdicionarPacienteAsync();
                    break;
                case "3":
                    await BuscarPorFaixaEtariaAsync();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }

    private void ListarPacientes()
    {
        var pacientes = _repository.GetAll();
        Console.WriteLine("\n=== LISTA DE PACIENTES ===");
        foreach (var p in pacientes)
        {
            var idade = DateTime.Now.Year - p.DataNascimento.Year;
            if (p.DataNascimento.Date > DateTime.Now.AddYears(-idade)) idade--;
            Console.WriteLine($"{p.Id} - {p.NomeCompleto} ({idade} anos)");
        }
    }

    private async Task AdicionarPacienteAsync()
    {
        Console.Write("\nNome completo: ");
        var nome = Console.ReadLine();

        Console.Write("Data de nascimento (dd/mm/aaaa): ");
        var dataNasc = DateTime.Parse(Console.ReadLine());

        Console.Write("Contato de emergência: ");
        var contato = Console.ReadLine();

        _repository.Add(new Paciente
        {
            NomeCompleto = nome,
            DataNascimento = dataNasc,
            ContatoEmergencia = contato
        });

        Console.WriteLine("Paciente cadastrado com sucesso!");
    }

    private async Task BuscarPorFaixaEtariaAsync()
    {
        Console.Write("\nIdade mínima: ");
        var min = int.Parse(Console.ReadLine());

        Console.Write("Idade máxima: ");
        var max = int.Parse(Console.ReadLine());

        var pacientes = _repository.ObterPorFaixaEtaria(min, max);
        
        Console.WriteLine($"\nPacientes entre {min} e {max} anos:");
        foreach (var p in pacientes)
        {
            var idade = DateTime.Now.Year - p.DataNascimento.Year;
            if (p.DataNascimento.Date > DateTime.Now.AddYears(-idade)) idade--;
            Console.WriteLine($"{p.NomeCompleto} - {idade} anos");
        }
    }
}
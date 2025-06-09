public async Task ShowMainMenuAsync()
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine("=== MENU PRINCIPAL ===");
        Console.WriteLine("1. Gerenciar Produtos");
        Console.WriteLine("2. Gerenciar Filmes");
        Console.WriteLine("3. Gerenciar Pacientes");
        Console.WriteLine("4. Gerenciar Funcionários");
        Console.WriteLine("5. Gerenciar Equipamentos de TI");
        Console.WriteLine("6. Sair");
        Console.Write("Escolha: ");

        switch (Console.ReadLine())
        {
            case "1":
                await new ProdutoService(_config).ShowMenuAsync();
                break;
            case "2":
                await new FilmeService(_config).ShowMenuAsync();
                break;
            case "3":
                await new PacienteService(_config).ShowMenuAsync();
                break;
            case "4":
                await new FuncionarioService(_config).ShowMenuAsync();
                break;
            case "5":
                await new EquipamentoTIService().ShowMenuAsync();
                break;
            case "6":
                return;
            default:
                Console.WriteLine("Opção inválida!");
                await Task.Delay(1000);
                break;
        }
    }
}
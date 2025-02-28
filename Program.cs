using System;

class Program
{
    static void Main()
    {
       
        Animal[] animais = new Animal[10];
        Cliente[] clientes = new Cliente[10];
        Venda[] vendas = new Venda[10];

        int contadorAnimais = 0;
        int contadorClientes = 0;
        int contadorVendas = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("---- Loja de Pets ----");
            Console.WriteLine("1 - Cadastrar Animal");
            Console.WriteLine("2 - Cadastrar Cliente");
            Console.WriteLine("3 - Registrar Venda");
            Console.WriteLine("4 - Exibir Animais Disponíveis");
            Console.WriteLine("5 - Exibir Clientes Cadastrados");
            Console.WriteLine("6 - Sair");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            if (opcao == "1")
            {
                CadastrarAnimal(animais, ref contadorAnimais);
            }
            else if (opcao == "2")
            {
                CadastrarCliente(clientes, ref contadorClientes);
            }
            else if (opcao == "3")
            {
                RegistrarVenda(animais, clientes, vendas, ref contadorVendas, contadorAnimais, contadorClientes);
            }
            else if (opcao == "4")
            {
                ExibirAnimaisDisponiveis(animais, contadorAnimais);
            }
            else if (opcao == "5")
            {
                ExibirClientesCadastrados(clientes, contadorClientes);
            }
            else if (opcao == "6")
            {
                break;  
            }
            else
            {
                Console.WriteLine("Opção inválida!");
            }

            
        }
    }


    static void CadastrarAnimal(Animal[] animais, ref int contadorAnimais)
    {
        Console.WriteLine("\nCadastro de Animal");
        Console.Write("Digite o nome do animal: ");
        string nome = Console.ReadLine();

        Console.Write("Digite a espécie do animal: ");
        string especie = Console.ReadLine();

        Console.Write("Digite o preço do animal: ");
        decimal preco = decimal.Parse(Console.ReadLine());

        animais[contadorAnimais] = new Animal { Nome = nome, Especie = especie, Preco = preco };
        contadorAnimais++;
        Console.WriteLine("Animal cadastrado com sucesso!");
        Console.WriteLine("Pressione qualquer tecla para voltar.");
        Console.ReadKey();
    }


    static void CadastrarCliente(Cliente[] clientes, ref int contadorClientes)
    {
        Console.WriteLine("\nCadastro de Cliente");
        Console.Write("Digite o nome do cliente: ");
        string nome = Console.ReadLine();

        Console.Write("Digite o telefone do cliente: ");
        string telefone = Console.ReadLine();

        clientes[contadorClientes] = new Cliente { Nome = nome, Telefone = telefone };
        contadorClientes++;
        Console.WriteLine("Cliente cadastrado com sucesso!");
        Console.WriteLine("Pressione qualquer tecla para voltar.");
        Console.ReadKey();
    }


    static void RegistrarVenda(Animal[] animais, Cliente[] clientes, Venda[] vendas, ref int contadorVendas, int contadorAnimais, int contadorClientes)
    {
        Console.WriteLine("\nRegistro de Venda");

        Console.Write("Digite o id do animal (0 a " + (contadorAnimais - 1) + "): ");
        int idAnimal = int.Parse(Console.ReadLine());

        Console.Write("Digite o id do cliente (0 a " + (contadorClientes - 1) + "): ");
        int idCliente = int.Parse(Console.ReadLine());

        vendas[contadorVendas] = new Venda
        {
            Animal = animais[idAnimal],
            Cliente = clientes[idCliente],
            DataVenda = DateTime.Now
        };
        contadorVendas++;

        Console.WriteLine("Venda registrada com sucesso!");
        Console.WriteLine("Pressione qualquer tecla para voltar.");
        Console.ReadKey();
    }

  
    static void ExibirAnimaisDisponiveis(Animal[] animais, int contadorAnimais)
    {
        Console.WriteLine("\nAnimais Disponíveis");
        if (contadorAnimais == 0)
        {
            Console.WriteLine("Não há animais cadastrados.");
        }
        else
        {
            for (int i = 0; i < contadorAnimais; i++)
            {
                Console.WriteLine($"ID: {i} - Nome: {animais[i].Nome}, Espécie: {animais[i].Especie}, Preço: {animais[i].Preco:C}");
            }
        }
        Console.ReadKey();
    }


    static void ExibirClientesCadastrados(Cliente[] clientes, int contadorClientes)
    {
        Console.WriteLine("\nClientes Cadastrados");
        if (contadorClientes == 0)
        {
            Console.WriteLine("Não há clientes cadastrados.");
        }
        else
        {
            for (int i = 0; i < contadorClientes; i++)
            {
                Console.WriteLine($"ID: {i} - Nome: {clientes[i].Nome}, Telefone: {clientes[i].Telefone}");
            }
        }
        Console.ReadKey();
    }
}



class Animal
{
    public string Nome { get; set; }
    public string Especie { get; set; }
    public decimal Preco { get; set; }
}

class Cliente
{
    public string Nome { get; set; }
    public string Telefone { get; set; }
}

class Venda
{
    public Animal Animal { get; set; }
    public Cliente Cliente { get; set; }
    public DateTime DataVenda { get; set; }
}




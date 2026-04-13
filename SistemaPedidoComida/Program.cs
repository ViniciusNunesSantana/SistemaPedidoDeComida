using Microsoft.VisualBasic;
using SistemaPedidoComida;
using System.Globalization;

internal class Program
{
    private static void Main(string[] args)
    {
        Menu();
    }

    public static void Menu()
    {
        List<Produto> produtos = new List<Produto>();
        List<Cliente> clientes = new List<Cliente>();
        List<Pedido> pedidos = new List<Pedido>();

        int escolha;

        do
        {
            Console.WriteLine("============================");
            Console.WriteLine("1 - Criar produto");
            Console.WriteLine("2 - Lista produtos");
            Console.WriteLine("3 - Criar cliente");
            Console.WriteLine("4 - Lista clientes");
            Console.WriteLine("5 - Criar pedido");
            Console.WriteLine("6 - Adicionar item ao pedido");
            Console.WriteLine("7 - Lista de pedidos");
            Console.WriteLine("8 - Cancelar pedido");
            Console.WriteLine("9 - Sair");
            Console.WriteLine("============================");
            Console.Write("\nEscola uma opcao: ");

            if (!int.TryParse(Console.ReadLine(), out escolha))
            {
                Console.WriteLine("Somente numeros sao aceitos");
                continue;
            }

            switch (escolha)
            {
     
                case 1:
                    CriarProduto(produtos);
                    break;
                case 2:
                    TabelaProdutos(produtos);
                    break;
                case 3:
                    CriarCliente(clientes);
                    break;
                case 4:
                    TabelaClientes(clientes);
                    break;
                case 5:
                    CriarPedido(clientes, pedidos);
                    break;
                case 6:
                    AdicionarItemPedido(pedidos, produtos);
                    break;
                case 7:
                    TabelaPedidos(pedidos);
                     break;
                case 8:
                    CancalerPedido(pedidos);
                    break;
                case 9:
                    Console.WriteLine("Saindo...");
                    return;
                default:
                    Console.WriteLine("Somente os numeros que estao na tabela sao validos!");
                    break;
            }

            Console.WriteLine("============================");
            Console.WriteLine("Aperte enter para continuar");
            Console.ReadLine();
            Console.Clear();
        } while (escolha != 9);
       
    }

    public static void CriarProduto(List<Produto> produto)
    {
        Console.Write("Informe o nome do produto: ");
        string nome = Console.ReadLine();

        Console.Write($"Informe o preco do {nome}: ");
        if (!decimal.TryParse(Console.ReadLine(), new CultureInfo("pt-BR"), out decimal preco))
        {
            Console.WriteLine("Somente numeros sao aceitos");
            return;
        }

        Console.Write($"Informe a quantidade do {nome}: ");
        if (!int.TryParse(Console.ReadLine(), out int quantidade))
        {
            Console.WriteLine("Somente numeros sao aceitos");
            return;
        }

        try
        {
            produto.Add(new Produto(nome, preco, quantidade));
            Console.WriteLine("Produto criado com sucesso!");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch(InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public static void TabelaProdutos(List<Produto> produtos)
    {
        if(produtos.Count == 0)
        {
            Console.WriteLine("Lista vazia ainda!");
            return;
        }

        int cont = 1;

        foreach (Produto produto in produtos)
        {
            Console.WriteLine($"Id {cont}: {produto}");
            cont++;
        }
    }

    public static void CriarCliente(List<Cliente> cliente)
    {
        Console.Write("Informe o nome do cliente: ");
        string nome = Console.ReadLine();

        try
        {
            cliente.Add(new Cliente(nome));
            Console.WriteLine("Cliente criado com sucesso!");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public static void TabelaClientes(List<Cliente> clientes)
    {
        if(clientes.Count == 0)
        {
            Console.WriteLine("Lista vazia ainda!");
            return;
        }

        int cont = 1;

        foreach (Cliente cliente in clientes)
        {
            Console.WriteLine($"Id {cont}: {cliente}");
            cont++;
        }
    }

    public static void CriarPedido(List<Cliente> clientes, List<Pedido> pedido)
    {
        if( clientes.Count == 0)
        {
            Console.WriteLine("Erro: Sem clientes nao podemos criar pedido");
            return;
        }

       
        int  cont = 1;
        for (int i = 0; i < clientes.Count; i++)
        {
            Console.WriteLine($"{cont}: {clientes[i].Nome}");
            cont++;
        }

        Console.Write("Escolha por indice o cliente: ");
        if (!int.TryParse(Console.ReadLine(), out int escolhaCliente))
        {
            Console.WriteLine("somente numeros sao aceitos!");
            return;
        }

        escolhaCliente--;

        if (escolhaCliente < 0 || escolhaCliente >= clientes.Count)
        {
            Console.WriteLine("Posicao invalida");
            return;
        }

        Cliente cliente = clientes[escolhaCliente];

        Pedido pedido1 = new Pedido(cliente);

        pedido.Add(pedido1);
        Console.WriteLine("Pedido criado com sucesso!");
    }

    public static void AdicionarItemPedido(List<Pedido> pedidos, List<Produto> produtos)
    {

        if (pedidos.Count == 0 || produtos.Count == 0)
        {
            Console.WriteLine("Nao tem nenhum pedido ou produto ainda");
            return;
        }


        int cont = 1;
        Console.WriteLine("Pedidos:");
        for (int i = 0; i < pedidos.Count; i++)
        {
            Console.WriteLine($"{cont}: {pedidos[i].Cliente.Nome}");
            cont++;
        }

        Console.Write("Escolha por indice o pedido: ");
        if (!int.TryParse(Console.ReadLine(), out int escolhaPedido))
        {
            Console.WriteLine("somente numeros sao aceitos!");
            return;
        }

        escolhaPedido--;

        if (escolhaPedido < 0 || escolhaPedido >= pedidos.Count)
        {
            Console.WriteLine("Posicao invalida");
            return;
        }

     
        Console.WriteLine("\nProdutos:");
        cont = 1;
        for (int i = 0; i < produtos.Count; i++)
        {
            Console.WriteLine($"{cont}: {produtos[i]}");
            cont++;
        }

        Console.Write("Escolha por indice o produto: ");
        if (!int.TryParse(Console.ReadLine(), out int escolhaProduto))
        {
            Console.WriteLine("somente numeros sao aceitos!");
            return;
        }

        escolhaProduto--;

        if (escolhaProduto < 0 || escolhaProduto >= produtos.Count)
        {
            Console.WriteLine("Posicao invalida");
            return;
        }

        Console.Write("Informe a quantidade: ");
        if (!int.TryParse(Console.ReadLine(), out int quantidade))
        {
            Console.WriteLine("somente numeros sao aceitos!");
            return;
        }


        Produto produto = produtos[escolhaProduto];

        try
        {
            pedidos[escolhaPedido].AdicionarPedido(produto, quantidade);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }

    }

    public static void TabelaPedidos(List<Pedido> pedidos)
    {
        if (pedidos.Count == 0)
        {
            Console.WriteLine("Lista vazia");
            return;
        }

        int cont = 1;

        foreach (Pedido pedido in pedidos)
        {
            Console.WriteLine($"Pedido - {cont}: Cliente: {pedido.Cliente.Nome}");

            foreach (ItemPedido item in pedido.Items)
            {
                Console.WriteLine($" {item}");
            }

            Console.WriteLine($"Total: {pedido.Total().ToString("C", new CultureInfo("pt-BR"))}");
            cont++;
            Console.WriteLine("====================");
        }


    }

    public static void CancalerPedido(List<Pedido> pedidos)
    {
        if(pedidos.Count == 0)
        {
            Console.WriteLine("Lista vazia");
            return;
        }


        int cont = 1;

        foreach (Pedido pedido in pedidos)
        {
            Console.WriteLine($"Pedido - {cont}: Cliente: {pedido.Cliente.Nome}");

            foreach (ItemPedido item in pedido.Items)
            {
                Console.WriteLine($" {item}");
            }

            Console.WriteLine($"Total: {pedido.Total().ToString("C", new CultureInfo("pt-BR"))}");
            cont++;
        }

        Console.Write("Escolha um pedido para cancelar: ");

        if(!int.TryParse(Console.ReadLine(), out int escolhaPedido))
        {
            Console.WriteLine("Somente numeros sao aceitos");
            return;
        }

        escolhaPedido--;

        if (escolhaPedido < 0 || escolhaPedido >= pedidos.Count)
        {
            Console.WriteLine("Posicao invalida");
            return;
        }

        Pedido pedidoDeletar = pedidos[escolhaPedido];
        
        pedidoDeletar.CancelarPedido();
        pedidos.Remove(pedidoDeletar);
        Console.WriteLine("Pedido cancelado com sucesso!");
    }
}
namespace SistemaPedidoComida;
internal class Cliente
{
    public Guid Id { get;}
    public string Nome { get; private set; } = string.Empty;

    private List<Pedido> _pedidos = new List<Pedido>();
    public IReadOnlyCollection<Pedido> Pedidos => _pedidos;


    public Cliente(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome invalido");

        Id = Guid.NewGuid();
        Nome = nome;
    }

    public override string ToString()
    {
        return $"Nome: {Nome}";
    }
}

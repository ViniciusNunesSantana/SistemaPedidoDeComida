using System.Globalization;
using System.Text;

namespace SistemaPedidoComida;
internal class Pedido
{
    public Guid Id { get; } = Guid.NewGuid();

    private List<ItemPedido> _items = new List<ItemPedido>();
    public IReadOnlyCollection<ItemPedido> Items => _items;
    public Cliente Cliente { get;}

    public Pedido(Cliente cliente)
    {
        if(cliente is null)
            throw new ArgumentNullException("Dados invalido ", nameof(cliente));

        Cliente = cliente;
    }

    public void AdicionarPedido(Produto produto, int qtd)
    {
        if (produto is null)
            throw new ArgumentNullException("Dados invalidos");

        if (qtd <= 0)
            throw new InvalidOperationException("Quantidade invalida");

        foreach (var item in _items)
        {
            if (item.Produto.Nome.Equals(produto.Nome, StringComparison.OrdinalIgnoreCase))
            {
                item.AumentarQuantidade(qtd);
                item.Produto.DimuinuirEstoque(qtd);
                return;
            }
        }

        produto.DimuinuirEstoque(qtd);

        _items.Add(new ItemPedido(qtd, produto));
    }


    public void CancelarPedido()
    {
        foreach (var item in _items)
        {
            item.Produto.AumentarEstoque(item.Quantidade);
        }
        _items.Clear(); 
    }

    public decimal Total()
    {
        decimal total = 0;

        foreach (var item in _items)
        {
            total += item.SubTotal();
        }

        return total;
    }

}

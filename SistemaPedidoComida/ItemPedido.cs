using System.Globalization;

namespace SistemaPedidoComida;
internal class ItemPedido
{
    public Guid Id { get;}
    public int Quantidade { get; private set; }
    public Produto Produto { get;}

    public ItemPedido(int quantidade, Produto produto)
    {
        if (quantidade <= 0)
            throw new InvalidOperationException("Estoque invalido");

        if(produto is null)
            throw new ArgumentNullException("Dados invalidos");


        Id = Guid.NewGuid();
        Quantidade = quantidade;
        Produto = produto;
    }


    public void AumentarQuantidade(int quantidade)
    {
        if (quantidade <= 0)
            throw new InvalidOperationException("Quantidade invalido");

        Quantidade += quantidade;
    }

    public void DimuinuirQuantidade(int quantidade)
    {
        if (quantidade <= 0)
            throw new InvalidOperationException("Quantidade invalido");

        if (quantidade > Quantidade)
            throw new InvalidOperationException("Quantidade insuficiente!");

        Quantidade -= quantidade;
    }

    public decimal SubTotal()
    {
        return Produto.Preco * Quantidade;
    }


    public override string ToString()
    {
        return $" - {Produto.Nome}  x{Quantidade} - R$ {SubTotal().ToString("C", new CultureInfo("pt-BR"))}";
    }
}

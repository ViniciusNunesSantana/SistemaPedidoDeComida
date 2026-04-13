using System.Globalization;

namespace SistemaPedidoComida;
internal class Produto
{
    public Guid Id { get;}
    public string Nome { get; private set; } = string.Empty;
    public decimal Preco { get; private set; }
    public int Estoque { get; private set; }

    public Produto(string nome, decimal preco, int estoque)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome invalido");

        if (preco <= 0.0m)
            throw new InvalidOperationException("Preco invalido");

        if (estoque <= 0)
            throw new InvalidOperationException("Estoque invalido");

        Id = Guid.NewGuid();
        Nome = nome;
        Preco = preco;
        Estoque = estoque;
    }

    public void AumentarEstoque(int estoque)
    {
        if (estoque <= 0)
            throw new InvalidOperationException("Estoque invalido");

        Estoque += estoque;
    }

    public void DimuinuirEstoque(int estoque)
    {
        if (estoque <= 0)
            throw new InvalidOperationException("Estoque invalido");

        if (estoque > Estoque)
            throw new InvalidOperationException("Estoque insuficiente!");

        Estoque -= estoque;
    }


    public override string ToString()
    {
        return $"Nome: {Nome}, Preco: {Preco.ToString("C", new CultureInfo("pt-BR"))}, Estoque: {Estoque}";
    }
}

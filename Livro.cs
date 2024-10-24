public class Livro : ItemBiblioteca, IEmprestavel, IPesquisavel
{
    // Propriedades
    public string Autor { get; set; }
    public string ISBN { get; set; }
    public string Genero { get; set; }
    public int QuantidadeEmEstoque { get; private set; }

    public Livro(string titulo, string codigo, string autor, string isbn, string genero, int quantidadeEmEstoque)
        : base(titulo, codigo)
    {
        Autor = autor;
        ISBN = isbn;
        Genero = genero;
        QuantidadeEmEstoque = quantidadeEmEstoque;
    }

    public override void Emprestar(Usuario usuario)
    {
        if (QuantidadeEmEstoque > 0)
        {
            QuantidadeEmEstoque--;
            usuario.AdicionarEmprestimo(Titulo);  // Registra o empréstimo
            Console.WriteLine($"Empréstimo realizado com sucesso! {usuario.Nome} emprestou '{Titulo}'.");
        }
        else
        {
            Console.WriteLine($"Desculpe, não há exemplares disponíveis de '{Titulo}'.");
        }
    }

    public void Devolver()
    {
        QuantidadeEmEstoque++;
        Console.WriteLine($"Devolução realizada com sucesso! O livro '{Titulo}' foi devolvido.");
    }

    // Novo método Devolver que aceita um Usuario
    public override void Devolver(Usuario usuario)
    {
        QuantidadeEmEstoque++;
        Console.WriteLine($"Devolução realizada com sucesso! O livro '{Titulo}' foi devolvido.");

        var emprestimo = usuario.GetHistoricoEmprestimos()
            .FirstOrDefault(e => e.Titulo == Titulo);

        bool atraso = false;

        if (emprestimo != null)
        {
            if (DateTime.Now > emprestimo.DataDevolucaoEsperada)
            {
                atraso = true;
            }

            // Remover o empréstimo do histórico após a devolução
            usuario.GetHistoricoEmprestimos().Remove(emprestimo);
        }

        if (atraso)
        {
            usuario.AdicionarMulta(5); // Por exemplo, $5 de multa
            Console.WriteLine($"Multa adicionada ao usuário {usuario.Nome}.");
        }
    }

    public void AtualizarQuantidadeEmEstoque(int novaQuantidade)
    {
        QuantidadeEmEstoque = novaQuantidade;
    }

    // Implementação dos métodos de pesquisa
    public IEnumerable<Livro> PesquisarPorTitulo(string titulo)
    {
        return new List<Livro> { this }.Where(l => l.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));
    }

    public IEnumerable<Livro> PesquisarPorAutor(string autor)
    {
        return new List<Livro> { this }.Where(l => l.Autor.Equals(autor, StringComparison.OrdinalIgnoreCase));
    }

    public IEnumerable<Livro> PesquisarPorGenero(string genero)
    {
        return new List<Livro> { this }.Where(l => l.Genero.Equals(genero, StringComparison.OrdinalIgnoreCase));
    }
}

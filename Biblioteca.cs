public class Biblioteca
{
    public List<Livro> Livros { get; private set; }
    public List<Usuario> Usuarios { get; private set; }

    public Biblioteca()
    {
        Livros = new List<Livro>();
        Usuarios = new List<Usuario>();
    }

    public void CadastrarLivro(Livro livro)
    {
        Livros.Add(livro);
    }

    public void CadastrarUsuario(Usuario usuario)
    {
        Usuarios.Add(usuario);
    }

    public void ListarLivros()
    {
        foreach (var livro in Livros)
        {
            Console.WriteLine($"Título: {livro.Titulo}, Autor: {livro.Autor}, Gênero: {livro.Genero}, Estoque: {livro.QuantidadeEmEstoque}");
        }
    }

    public void ListarUsuarios()
    {
        foreach (var usuario in Usuarios)
        {
            Console.WriteLine($"Nome: {usuario.Nome}, ID: {usuario.NumeroIdentificacao}");
        }
    }

    public void AtualizarUsuario(string numeroIdentificacao, string novoNome, string novoEndereco, string novoContato)
    {
    var usuario = Usuarios.FirstOrDefault(u => u.NumeroIdentificacao == numeroIdentificacao);
    if (usuario != null)
    {
        usuario.AtualizarInformacoes(novoNome, novoEndereco, novoContato); // Chama o método da classe Usuario
        Console.WriteLine($"Usuário '{numeroIdentificacao}' atualizado com sucesso.");
    }
    else
    {
        Console.WriteLine("Usuário não encontrado.");
    }
    }

    public void EmprestarLivro(string codigoLivro, string numeroUsuario)
    {
        var livro = Livros.FirstOrDefault(l => l.Codigo == codigoLivro);
        var usuario = Usuarios.FirstOrDefault(u => u.NumeroIdentificacao == numeroUsuario);

        if (livro != null && usuario != null)
        {
            livro.Emprestar(usuario);
        }
        else
        {
            Console.WriteLine("Livro ou usuário não encontrado.");
        }
    }

    public void DevolverLivro(string codigoLivro)
    {
        var livro = Livros.FirstOrDefault(l => l.Codigo == codigoLivro);

        if (livro != null)
        {
            livro.Devolver();
        }
        else
        {
            Console.WriteLine("Livro não encontrado.");
        }
    }

    public void AtualizarLivro(string codigo, string novoTitulo, string novoAutor, string novoISBN, string novoGenero, int novaQuantidadeEmEstoque)
{
    var livro = Livros.FirstOrDefault(l => l.Codigo == codigo);
    if (livro != null)
    {
        livro.Titulo = novoTitulo;
        livro.Autor = novoAutor;
        livro.ISBN = novoISBN;
        livro.Genero = novoGenero;
        livro.AtualizarQuantidadeEmEstoque(novaQuantidadeEmEstoque); // Atualiza a quantidade
        Console.WriteLine($"Livro '{codigo}' atualizado com sucesso.");
    }
    else
    {
        Console.WriteLine("Livro não encontrado.");
    }
}

    // Métodos de pesquisa
    public IEnumerable<Livro> PesquisarLivrosPorTitulo(string titulo)
    {
        return Livros.Where(l => l.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));
    }

    public IEnumerable<Livro> PesquisarLivrosPorAutor(string autor)
    {
        return Livros.Where(l => l.Autor.Equals(autor, StringComparison.OrdinalIgnoreCase));
    }

    public IEnumerable<Livro> PesquisarLivrosPorGenero(string genero)
    {
        return Livros.Where(l => l.Genero.Equals(genero, StringComparison.OrdinalIgnoreCase));
    }
}



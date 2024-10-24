public interface IEmprestavel
{
    void Emprestar(Usuario usuario);
    void Devolver();
}

public interface IPesquisavel
{
    IEnumerable<Livro> PesquisarPorTitulo(string titulo);
    IEnumerable<Livro> PesquisarPorAutor(string autor);
    IEnumerable<Livro> PesquisarPorGenero(string genero);
}



class Program
{
    static void Main(string[] args)
    {
        Biblioteca biblioteca = new Biblioteca();

        // Cadastrar usuários
        Usuario usuario1 = new Usuario("Alice", "001", "Rua A", "123456789");
        biblioteca.CadastrarUsuario(usuario1);

        // Cadastrar livros
        Livro livro1 = new Livro("O Senhor dos Anéis", "L001", "J.R.R. Tolkien", "978-3-16-148410-0", "Fantasia", 5);
        biblioteca.CadastrarLivro(livro1);

        // Listar livros e usuários
        biblioteca.ListarLivros();
        biblioteca.ListarUsuarios();

        // Empréstimo de um livro
        biblioteca.EmprestarLivro("L001", "001");
        
        // Devolução do livro
        biblioteca.DevolverLivro("L001");
    }
}

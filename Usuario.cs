public class Emprestimo
{
    public string Titulo { get; set; }
    public DateTime DataEmprestimo { get; set; }
    public DateTime DataDevolucaoEsperada { get; set; }

    public Emprestimo(string titulo, DateTime dataEmprestimo, DateTime dataDevolucaoEsperada)
    {
        Titulo = titulo;
        DataEmprestimo = dataEmprestimo;
        DataDevolucaoEsperada = dataDevolucaoEsperada;
    }

    public override string ToString()
    {
        return $"{Titulo} - Emprestado em: {DataEmprestimo.ToShortDateString()} - Devolução esperada em: {DataDevolucaoEsperada.ToShortDateString()}";
    }
}

public class Usuario
{
    public string Nome { get; private set; }
    public string NumeroIdentificacao { get; private set; }
    public string Endereco { get; private set; }
    public string Contato { get; private set; }
    private List<Emprestimo> historicoEmprestimos;

    // Construtor
    public Usuario(string nome, string numeroIdentificacao, string endereco, string contato)
    {
        Nome = nome;
        NumeroIdentificacao = numeroIdentificacao;
        Endereco = endereco;
        Contato = contato;
        historicoEmprestimos = new List<Emprestimo>();
    }

    public void AtualizarInformacoes(string novoNome, string novoEndereco, string novoContato)
    {
        Nome = novoNome;
        Endereco = novoEndereco;
        Contato = novoContato;
    }
    
    public void AdicionarEmprestimo(string titulo)
    {
    var dataEmprestimo = DateTime.Now;
    var dataDevolucaoEsperada = dataEmprestimo.AddDays(14); // Supondo 14 dias para devolução
    historicoEmprestimos.Add(new Emprestimo(titulo, dataEmprestimo, dataDevolucaoEsperada));
    }

   public List<Emprestimo> GetHistoricoEmprestimos() => historicoEmprestimos;

    public decimal Multa { get; private set; } = 0;

    public void AdicionarMulta(decimal valor)
    {
        Multa += valor;
    }

    public void PagarMulta(decimal valor)
    {
        if (valor <= Multa)
        {
            Multa -= valor;
        }
        else
        {
            Console.WriteLine("Valor de pagamento maior que a multa.");
        }
    }

    public void ExibirHistorico()
    {
    Console.WriteLine("Histórico de Empréstimos:");
    foreach (var emprestimo in historicoEmprestimos)
    {
        Console.WriteLine($"- {emprestimo}"); // Chama o ToString() automaticamente
    }
    }


    public void ExibirInformacoes()
    {
        Console.WriteLine("----- Informações do Usuário -----");
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"ID: {NumeroIdentificacao}");
        Console.WriteLine($"Endereço: {Endereco}");
        Console.WriteLine($"Contato: {Contato}");
        Console.WriteLine("-----------------------------------");
        Console.WriteLine($"Multa: {Multa:C}");
    }
}

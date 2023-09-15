namespace API_Cadastro.Domain
{
    public interface ICadastroRepository
    {
        Task<string> CadastrarCliente(Cadastro cadastro);
    }
}

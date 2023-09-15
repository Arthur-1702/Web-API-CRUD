using API_Cadastro.Data;
using API_Cadastro.Domain;
using Dapper;
using System.Data;


namespace API_Cadastro.Repository
{
    public class CadastroRepository : ICadastroRepository
    {
        private readonly IDbConnection _con = ConSQL.CreateConnection(); 

        public List<Cadastro> getCadastros()
        {
            _con.Open();

            var sql = "SELECT * FROM TesteConexaoRegistro";

            List<Cadastro> cadastros = _con.Query<Cadastro>(sql).ToList();

            _con.Close();

            return cadastros;
        }

        public Cadastro getCadastro(int id)
        {
            _con.Open();

            var sql = @"SELECT * FROM TesteConexaoRegistro WHERE id = @id";

            Cadastro result = _con.QueryFirstOrDefault<Cadastro>(sql, new {id});

            _con.Close();

            return result;
        }

        public async Task<string> CadastrarCliente(Cadastro cadastro)
        {
            try
            {
                using IDbConnection conn = ConSQL.CreateConnection();
                var result = await conn.QueryFirstOrDefaultAsync<string>($"EXEC criarCadastro " + $"@nome,@email,@telefone",
                    new
                    {
                        cadastro.nome,
                        cadastro.email,
                        cadastro.telefone
                    });
                conn.Close();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        

        public void addCadastro(Cadastro cadastro)
        {
            _con.Open();

            _con.Execute("INSERT INTO TesteConexaoRegistro (nome, email, telefone) VALUES (@nome, @email, @telefone)", new
            {
                cadastro.nome,
                cadastro.email,
                cadastro.telefone
            });

            _con.Close();

        }

        public void editCadastro(int id, Cadastro cadastro)
        {
            _con.Open();

            var sql = @"UPDATE TesteConexaoRegistro SET nome = @nome, email = @email, telefone = @telefone WHERE id = @id";

            _con.Execute(sql, new
            {
                cadastro.nome,
                cadastro.email,
                cadastro.telefone,
                id
            });

            _con.Close();
        }

        public void deleteCadastro(int id)
        {
            _con.Open();

            var sql = "DELETE FROM TesteConexaoRegistro WHERE id = @id";

            _con.Execute(sql, new {id});

            _con.Close();
        }
    }
}

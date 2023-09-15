using API_Cadastro.Domain;
using API_Cadastro.Repository;

namespace API_Cadastro.Service
{
    public class CadastroService
    {
        private readonly CadastroRepository _repository;

        public CadastroService(CadastroRepository repository)
        {
            _repository = repository;
        }

        public async Task Cadastra(Cadastro cadastro)
        {
            try
            {
                await _repository.CadastrarCliente(cadastro);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Cadastro> getCadastros()
        {
            return _repository.getCadastros();
        }

        public Cadastro getCadastro(int id)
        {
            Cadastro cadastro = _repository.getCadastro(id);

            return cadastro;
        }

        public void addContato(Cadastro cadastro)
        {
            _repository.addCadastro(cadastro);
        }

        public void editCadastro(int id, Cadastro cadastro)
        {

             _repository.editCadastro(id,cadastro);
        }

        public void deleteCadastro(int id)
        {
            _repository.deleteCadastro(id);
        }

    }
}

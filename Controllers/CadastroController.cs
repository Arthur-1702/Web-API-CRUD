using API_Cadastro.Domain;
using API_Cadastro.Repository;
using API_Cadastro.Service;
using Microsoft.AspNetCore.Mvc;


namespace API_Cadastro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        private readonly CadastroService _service;

        public CadastroController(CadastroService service)
        {
            _service = service;
        }



        [HttpGet]
        public IActionResult GetAll()
        {
            List<Cadastro> cadastros = _service.getCadastros();

            return Ok(cadastros);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Cadastro cadastro = _service.getCadastro(id);

            return Ok(cadastro);
        }

        [HttpPost("Teste")]
        public async Task<IActionResult> AddNovo(Cadastro cadastro)
        {
            await _service.Cadastra(cadastro);

            return Created("Criado com sucesso!", cadastro);
        }

        [HttpPost]
        public IActionResult Add(Cadastro cadastro)
        {
            _service.addContato(cadastro);

            return Created("Criado com sucesso!", cadastro);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.deleteCadastro(id);
            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult Edit(int id,[FromBody]Cadastro cadastro)
        {
            _service.editCadastro(id, cadastro); 
            return Ok();
        }

    }
}

using ArchiveReaderAPI.Models;
using ArchiveReaderAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ArchiveReaderAPI.Controllers
{
    [ApiController]
    [Route("api/arquivo")]
    public class ArquivoController : ControllerBase
    {
        private readonly IArquivo _arquivo;
        public ArquivoController(IArquivo arquivo)
        {
            _arquivo = arquivo;
        }

        [HttpPost("/adicionar")]
        public IActionResult adicionarArquivo([FromBody]ArquivoDto arquivo){
            try
            {
                _arquivo.CreateFile(arquivo, DiretorioController.CaminhoDiretorio);
                return Ok("Arquivo adicionar com sucesso ");
            }
            catch (System.Exception e )
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("/editar")]
        public IActionResult editarConteudoArquivo([FromBody]ArquivoDto arquivo){
            try
            {
                _arquivo.SetContent(arquivo, DiretorioController.CaminhoDiretorio);
                return Ok("Arquivo editado com sucesso");
            }
            catch (System.Exception e )
            {
                return StatusCode(500, e.Message);
            }
        }


        [HttpGet("/ler/{tituloArquivo}")]
        public string editarConteudoArquivo(string tituloArquivo){
            try
            {
                return _arquivo.GetContent(tituloArquivo,DiretorioController.CaminhoDiretorio);
            }
            catch (System.Exception e )
            {
                return e.Message;
            }
        }
        [HttpDelete("/excluir/{tituloArquivo}")]
        public IActionResult excluirArquivo(string tituloArquivo){
            try
            {
                 _arquivo.DeleteFile(tituloArquivo,DiretorioController.CaminhoDiretorio);
                 return Ok("Arquivo excluido com sucesso");
            }
            catch (System.Exception e )
            {
                return StatusCode(500, e.Message);
            }
        }

    }
}

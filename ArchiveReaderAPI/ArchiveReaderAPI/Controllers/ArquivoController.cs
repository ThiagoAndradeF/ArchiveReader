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

        [HttpPost("/definirDiretorio")]
        public IActionResult definirDiretorio([FromBody] string caminhoDiretorio){
            try
            {
                _arquivo.SetDiretory(caminhoDiretorio);
                return Ok("Diretorio de arquivos definido com sucesso");
            }
            catch (System.Exception e )
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("/adicionar")]
        public IActionResult adicionarArquivo([FromBody]ArquivoDto arquivo){
            try
            {
                _arquivo.CreateFile(arquivo);
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
                _arquivo.SetContent(arquivo);
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
                return _arquivo.GetContent(tituloArquivo);
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
                 _arquivo.DeleteFile(tituloArquivo);
                 return Ok("Arquivo excluido com sucesso");
            }
            catch (System.Exception e )
            {
                return StatusCode(500, e.Message);
            }
        }

    }
}

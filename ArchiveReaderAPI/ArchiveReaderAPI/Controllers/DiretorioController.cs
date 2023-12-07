using ArchiveReaderAPI.Models;
using ArchiveReaderAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ArchiveReaderAPI.Controllers
{
    [ApiController]
    [Route("api/diretorio")]
    public class DiretorioController : ControllerBase
    {
        public  static string CaminhoDiretorio;
        private readonly IDiretorio _diretorio;
        public DiretorioController(IDiretorio diretorio)
        {
            _diretorio = diretorio;
        }        

        [HttpPost("/definirDiretorio")]
        public IActionResult definirDiretorio([FromBody]DiretorioDto caminhoDiretorio){
            try
            {
                CaminhoDiretorio = _diretorio.SetDiretory(caminhoDiretorio.Endereco);
                return Ok("Diretorio de arquivos definido com sucesso");
            }
            catch (System.Exception e )
            {
                return StatusCode(500, e.Message);
            }
        }

    }
}

using ArchiveReader.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ArchiveReader.Controllers;
[ApiController]
[Route("api/leitor")]

public class LeitorArquivo: ControllerBase
{
    private readonly IReaderRepository _readerRepository;
    public LeitorArquivo(IReaderRepository respository)
    {
        _readerRepository = respository;
    }

    [HttpGet("getValue")]
    public string getValueArchive()
    {
        try
        {
            return _readerRepository.ReadRepository();
        }
        catch (Exception ex)
        {
            return ("Não foi possível ler o arquivo, exception: " + ex);
        }
    }
        
    
    [HttpPut("editValue")]
    public bool updateValueArchive(string valueArchive) {
        try
        {
            return _readerRepository.EditRepository(valueArchive);
        }
        catch (Exception ex) {
            return false;
        }
    }
    [HttpPost("addValue")]
    public IActionResult createNewArchive(string valueArchive, string titleArchive) {
        try
        {
            _readerRepository.CreateRepository(valueArchive, titleArchive);
            return Ok("Arquivo criado com sucesso.");
        }
        catch (Exception ex)
        {
            // Tratar exceções, como InvalidOperationException
            return StatusCode(500, ex.Message);
        }
    }
    [HttpDelete("deleteArchive")]
    public IActionResult deleteArchive(string repositoryName)
    {
        try
        {
            _readerRepository.DeleteRepository(repositoryName);
            return Ok("Arquivo excluido com sucesso");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}

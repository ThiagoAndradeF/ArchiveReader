
using ArchiveReaderAPI.Models;

namespace ArchiveReaderAPI.Repositories;

public class Diretorio : IDiretorio
{
    public string SetDiretory(string pastaDiretorio)
    {   
        if(Directory.Exists(pastaDiretorio)){
            string diretorioFiltrado = pastaDiretorio.Replace("\\", "/");
            return diretorioFiltrado;
            
        }else{
            throw new Exception("Esse caminho não existe no seu computador");
        }
    }
}

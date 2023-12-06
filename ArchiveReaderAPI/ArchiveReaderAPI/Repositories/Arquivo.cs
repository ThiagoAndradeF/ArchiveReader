
using ArchiveReaderAPI.Models;

namespace ArchiveReaderAPI.Repositories;

public class Arquivo : IArquivo
{   
    private string _pastaDiretorio = string.Empty; 
    public bool SetDiretory(string pastaDiretorio)
    {   
        _pastaDiretorio = pastaDiretorio;
        if(Directory.Exists(pastaDiretorio)){
            return true;
        }else{
            throw new Exception("Esse caminho não existe no seu computador");
        }
    }
    public bool CreateFile(ArquivoDto arquivo)
    {
        string filePathComplete = _pastaDiretorio + arquivo.titulo + ".txt";
        if (!File.Exists(filePathComplete))
        {   
            File.WriteAllText(filePathComplete, arquivo.conteudo);
            return true;            
        }
        else
        {
            throw new InvalidOperationException("Já existe um arquivo com esse nome nesse diretório.");
        }
    }

    public bool DeleteFile(string titulo)
    {
        string filePathComplete = _pastaDiretorio + titulo + ".txt";
        if (File.Exists(filePathComplete))
        {
            File.Delete(filePathComplete);
            return true;
        }
        else
        {
            throw new InvalidOperationException("O arquivo não existe.");
        }
        throw new NotImplementedException();
    }

    public string GetContent(string titulo)
    {
        string filePathComplete = _pastaDiretorio + titulo + ".txt";
        if (File.Exists(filePathComplete))
        {
            return File.ReadAllText(filePathComplete);
        }
        else
        {
            throw new InvalidOperationException("Não existe arquivo com esse nome nesse diretório");
        }
        throw new NotImplementedException();
    }

    public bool SetContent(ArquivoDto arquivo)
    {
        string filePathComplete = _pastaDiretorio + arquivo.titulo + ".txt";
        if (File.Exists(filePathComplete))
        {
            File.WriteAllText(filePathComplete, arquivo.conteudo);
            return true;
        }
        else
        {
            throw new InvalidOperationException("Não existe arquivo com esse nome nesse diretório");
        }
        throw new NotImplementedException();
    }

}

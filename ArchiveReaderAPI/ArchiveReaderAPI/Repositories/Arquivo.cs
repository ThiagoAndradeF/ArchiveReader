
using ArchiveReaderAPI.Models;

namespace ArchiveReaderAPI.Repositories;

public class Arquivo : IArquivo
{
    public bool CreateFile(ArquivoDto arquivo , string pastaDiretorio)
    {   
        if(pastaDiretorio != null){
            string filePathComplete = pastaDiretorio  + "/" + arquivo.Titulo + ".txt";
            if (!File.Exists(filePathComplete))
            {   
                File.WriteAllText(filePathComplete, arquivo.Conteudo);
                return true;            
            }
            else
            {
                throw new InvalidOperationException("Já existe um arquivo com esse nome nesse diretório.");
            }
        }
        else{
            throw new InvalidOperationException("Pasta de diretorio não setada.");
        }
        
    }

    public bool DeleteFile(string titulo, string pastaDiretorio)
    {
        if(pastaDiretorio!= null){
            string filePathComplete = pastaDiretorio  + "/" + titulo + ".txt";
            if (File.Exists(filePathComplete))
            {
                File.Delete(filePathComplete);
                return true;
            }
            else
            {
                throw new InvalidOperationException("O arquivo não existe.");
            }
        }
        else{
            throw new InvalidOperationException("Pasta de diretorio não setada.");
        }
    }

    public string GetContent(string titulo, string pastaDiretorio)
    {
        string filePathComplete = pastaDiretorio  + "/" + titulo + ".txt";
        if(pastaDiretorio != null)
        {
            if (File.Exists(filePathComplete))
            {
                return File.ReadAllText(filePathComplete);
            }
            else
            { 
                throw new InvalidOperationException("Não existe arquivo com esse nome nesse diretório");
            }
        }else{
            throw new InvalidOperationException("Pasta de diretorio não setada.");
        }
    }

    public bool SetContent(ArquivoDto arquivo, string pastaDiretorio)
    {
        if(pastaDiretorio != null)
        {
            string filePathComplete = pastaDiretorio  + "/" + arquivo.Titulo + ".txt";
            if (File.Exists(filePathComplete))
            {
                File.WriteAllText(filePathComplete, arquivo.Conteudo);
                return true;
            }
            else
            {
                throw new InvalidOperationException("Não existe arquivo com esse nome nesse diretório");
            }
            throw new NotImplementedException();
        }
        else{
            throw new InvalidOperationException("Pasta de diretorio não setada.");
        }
    }

}

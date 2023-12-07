using ArchiveReaderAPI.Models;

namespace ArchiveReaderAPI.Repositories;
public  interface IArquivo {
    public string GetContent(string titulo, string pastaDiretorio);
    public bool SetContent(ArquivoDto arquivo, string pastaDiretorio);
    public bool CreateFile(ArquivoDto arquivo, string pastaDiretorio);
    public bool DeleteFile(string titulo, string pastaDiretorio);
}
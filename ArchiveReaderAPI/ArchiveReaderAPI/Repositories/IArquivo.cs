using ArchiveReaderAPI.Models;

namespace ArchiveReaderAPI.Repositories;
public  interface IArquivo {
    public bool SetDiretory(string pastaDiretorio);
    public string GetContent(string titulo);
    public bool SetContent(ArquivoDto arquivo);
    public bool CreateFile(ArquivoDto arquivo);
    public bool DeleteFile(string titulo);
}
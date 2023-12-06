namespace ArchiveReader.Repository
{
    public interface IReaderRepository
    {
        string ReadRepository();
        bool EditRepository(string newText);
        void CreateRepository(string repositoryContent, string repositoryName);
        void DeleteRepository(string repositoryName);
    }
}

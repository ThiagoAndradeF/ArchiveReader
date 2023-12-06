using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Reflection.Metadata.Ecma335;

namespace ArchiveReader.Repository
{
    public class ReaderRepository : IReaderRepository
    {
        
        const string filePath = @"C:/dev/ArchiveReader/Archives/text-file.txt";
        const string filePathCreate = @"C:/dev/ArchiveReader/Archives/";

        public void CreateRepository(string content, string title )
        {
            string filePathComplete = filePathCreate + title + ".txt";
            // Verifica se o arquivo já existe
            if (!File.Exists(filePathComplete))
            {
                // Cria um novo arquivo e escreve o conteúdo
                

                File.WriteAllText(filePathComplete, content);
            }
            else
            {
                throw new InvalidOperationException("O arquivo já existe.");
            }
        }

        public string ReadRepository()
        {
                string ValueText = File.ReadAllText(filePath);
                return  ValueText;
           
            
        }
        public void DeleteRepository(string repositoryName)
        {
            string filePathComplete = filePathCreate + repositoryName + ".txt";
            if (File.Exists(filePathComplete))
            {

                File.Delete(filePathComplete);
            }
            else
            {
                throw new InvalidOperationException("O arquivo não existe.");
            }

        }



        public bool EditRepository(string novoTexto)
        {
            File.WriteAllText(filePath, novoTexto);
            if (File.ReadAllText(filePath) == novoTexto)
            {
                return true;
            }
            return false;
        }

    }
}

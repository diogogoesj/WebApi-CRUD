using Newtonsoft.Json;

namespace WebApi.Repository
{
    /// <summary>
    /// Classe genérica para a leitura e escrita de dados em um arquivo de texto no formato JSON.
    /// </summary>
    /// <typeparam name="T">O tipo de dados a ser lido ou escrito no arquivo de texto.</typeparam>
    public class TextFileRepository<T>
    {
        private string _filePath;

        /// <summary>
        /// Inicializa uma nova instância do repositório de arquivo de texto com o caminho do arquivo.
        /// </summary>
        /// <param name="filePath">O caminho do arquivo de texto onde os dados serão armazenados.</param>
        public TextFileRepository(string filePath)
        {
            _filePath = filePath;
        }

        /// <summary>
        /// Obtém todos os dados do arquivo de texto, se existirem.
        /// </summary>
        /// <returns>Uma lista de dados do tipo T obtida a partir do arquivo de texto.</returns>
        public List<T> GetAll()
        {
            List<T>? data = new List<T>();

            try
            {
                if (File.Exists(_filePath))
                {
                    string json = File.ReadAllText(_filePath);
                    data = JsonConvert.DeserializeObject<List<T>>(json);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return data;
        }

        /// <summary>
        /// Salva todos os dados no arquivo de texto no formato JSON.
        /// </summary>
        /// <param name="data">A lista de dados do tipo T a ser salva no arquivo de texto.</param>
        public void SaveAll(List<T> data)
        {
            try
            {
                string json = JsonConvert.SerializeObject(data, Formatting.Indented);
                File.WriteAllText(_filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

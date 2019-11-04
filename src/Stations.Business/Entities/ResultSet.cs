using System.Collections.Generic;
using System.Linq;

namespace Stations.Business.Entities
{
    /// <summary>
    /// Nessa classe temos os resultados da busca em um objeto
    /// </summary>
    public class ResultSet
    {
        /// <summary>
        /// Lista de estações que o usuário recebe depois de digitar o input
        /// </summary>
        public List<string> Stations { get; set; }

        /// <summary>
        /// Lista de todos os possíveis inputs de caracteres que o usuário pode ter depois do primeiro input
        /// </summary>
        public List<char> AllNextCharacters { get; set; }

        /// <summary>
        /// Construtor da classe ResultSet, ele trata a lista de resultados da busca
        /// </summary>
        public ResultSet(IEnumerable<FindStationResult> searchResults)
        {
            Stations = new List<string>();
            AllNextCharacters = new List<char>();

            foreach (var s in searchResults)
            {
                Stations.Add(s.Station);
                AllNextCharacters.Add(s.NextCharacter);
            }

            AllNextCharacters.Remove(AllNextCharacters.FirstOrDefault(c => c == (char)0));
        }
    }
}
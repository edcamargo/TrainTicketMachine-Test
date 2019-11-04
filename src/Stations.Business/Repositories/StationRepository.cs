using System.Collections.Generic;
using System.Linq;
using Stations.Business.Entities;
using Stations.Business.Interfaces;

namespace Stations.Business.Repositories
{
    /// <inheritdoc />
    /// <summary>
    /// Classe com Ações do Repositorio
    /// </summary>
    public class StationRepository : IStationRepository
    {
        /// <summary>
        /// Retorna o array
        /// </summary>
        public string[] GetStations()
        {
            return StationArray.Stations;
        }

        /// <summary>
        /// Retorna as estações possui um nome e possíveis próximos caracteres
        /// </summary>
        /// <param name="input">Input do usuário</param>  
        public List<FindStationResult> GetAllStartedWith(string input)
        {
            try
            {
                var arraystations = GetStations();
                var searchResult = new List<FindStationResult>();
                var lenStations = StationArray.Stations.Length;

                for (var i = 0; i < lenStations; i++)
                {
                    if (arraystations[i].StartsWith(input))
                    {
                        searchResult.Add(new FindStationResult
                        {
                            Station = arraystations[i],
                            NextCharacter = GetNextCharacter(arraystations[i], input)
                        });
                    }
                }

                return searchResult;
            }

            catch
            {
                return Enumerable.Empty<FindStationResult>().ToList();
            }
        }

        /// <summary>
        /// Método que retorna o possível próximo caractere de uma string
        /// </summary>
        /// <param name="reference">É a referência de uma possível estação</param>  
        /// <param name="input">Input do usuário na máquina</param>  
        public char GetNextCharacter(string reference, string input)
        {
            try
            {
                return reference.Replace(input, string.Empty).ToCharArray().ToList()[0];
            }

            catch
            {
                return (char)0;
            }
        }
    }
}
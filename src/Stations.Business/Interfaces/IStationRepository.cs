using System.Collections.Generic;
using Stations.Business.Entities;

namespace Stations.Business.Interfaces
{
    /// <summary>
    /// Interface do Repositorio
    /// </summary>
    internal interface IStationRepository
    {
        /// <summary>
        /// Retorna as estações
        /// </summary>
        string[] GetStations();

        /// <summary>
        /// Retorna estação pelo nome
        /// </summary>
        List<FindStationResult> GetAllStartedWith(string input);

        /// <summary>
        /// Retorna o próximo caractere
        /// </summary>
        char GetNextCharacter(string reference, string input);
    }
}

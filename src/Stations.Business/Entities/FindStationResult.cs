namespace Stations.Business.Entities
{
    public class FindStationResult
    {
        /// <summary>
        /// Estação
        /// </summary>
        public string Station { get; set; }

        /// <summary>
        /// Possível próximo caractere para o usuário digitar
        /// </summary>
        public char NextCharacter { get; set; }
    }
}

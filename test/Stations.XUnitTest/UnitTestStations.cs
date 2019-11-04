using System.ComponentModel;
using Stations.Business.Repositories;
using Stations.Business.Entities;
using Xunit;

namespace Stations.XUnitTest
{
    public class UnitTestStations
    {
        [Theory(DisplayName = "Test Station 1")]
        [InlineData("DART")]
        [Description("Input do usuário - DART")]
        public void TestStation1(string input)
        {
            var stationRep = new StationRepository();
            StationArray.Stations = new[] { "DARTFORD", "DARTMOUTH", "TOWER HILL", "DERBY" };

            var set = new ResultSet(stationRep.GetAllStartedWith(input));

            // assert
            Assert.Contains(set.AllNextCharacters, c => c == 'F');
            Assert.Contains(set.AllNextCharacters, c => c == 'M');
            Assert.Contains(set.Stations, s => s == "DARTFORD");
            Assert.Contains(set.Stations, s => s == "DARTMOUTH");
        }

        [Theory(DisplayName = "Test Station 2")]
        [InlineData("LIVERPOOL")]
        [Description("Input do usuário - LIVERPOOL")]
        public void TestStation2(string input)
        {
            var stationRep = new StationRepository();
            StationArray.Stations = new[] { "LIVERPOOL", "LIVERPOOL LIME STREET", "PADDINGTON" };

            var set = new ResultSet(stationRep.GetAllStartedWith(input));

            // assert
            Assert.Contains(set.AllNextCharacters, c => c == ' ');
            Assert.Contains(set.Stations, s => s == "LIVERPOOL LIME STREET");
        }

        [Theory(DisplayName = "Test Station 3")]
        [InlineData("KINGS CROSS")]
        [Description("Input do usuário - KINGS CROSS")]
        public void TestStation3(string input)
        {
            var stationRep = new StationRepository();
            StationArray.Stations = new[] { "EUSTON", "LONDON BRIDGE", "VICTORIA" };

            var set = new ResultSet(stationRep.GetAllStartedWith(input));

            // assert
            Assert.True(set.AllNextCharacters.Count == 0);
            Assert.True(set.Stations.Count == 0);
        }
    }
}
using System;
using Xunit;
using SomeHttpCli;
using System.Collections.Generic;

namespace HttpTests
{
    public class SomeClientUnitTests
    {
        const string urlBase = @"http://api.zippopotam.us/";
        
        [Fact]
        public void ExecuteGetOnZippopotam()
        {
            var client = new Client(urlBase);
            
            var request = new SimpleGetRequest("us/90210");

            var response = client.Execute<Address>(request);

            Assert.True(response.Success);
        }
    }

     public class Place
    {
        public string placeName { get; set; }
        public string Longitude { get; set; }
        public string State { get; set; }
        public string StateAbbreviation { get; set; }
        public string Latitude { get; set; }
    }

    public class Address
    {
        public string PostCode { get; set; }
        public string Country { get; set; }
        public string CountryAbbreviation { get; set; }
        public IList<Place> Places { get; set; }
    }
}

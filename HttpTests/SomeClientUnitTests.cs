using System;
using Xunit;
using Xunit.Abstractions;
using SomeHttpCli;
using System.Collections.Generic;

namespace HttpTests
{
    public class SomeClientUnitTests
    {
        readonly ITestOutputHelper output;
        const string urlBase = @"http://api.zippopotam.us/";
        public SomeClientUnitTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void ExecuteGetOnZippopotam()
        {
            var client = new Client(urlBase);
            
            var request = new SimpleGetRequest("us/90210");

            var response = client.Execute<Address>(request);

            output.WriteLine(ObjectDumper.Dump(response.Response));
            
            Assert.True(response.Success);
            Assert.NotNull(response.Response);
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

#region OpenPlzApi.GV100AD - Copyright (c) STÜBER SYSTEMS GmbH
/*    
 *    OpenPlzApi.GV100AD 
 *    
 *    Copyright (c) STÜBER SYSTEMS GmbH
 *
 *    Licensed under the MIT License, Version 2.0. 
 * 
 */
#endregion

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace OpenPlzApi.GV100AD.Tests
{
    /// <summary>
    /// Unit tests for <see cref="GV100ADReader<T>"/>.
    /// </summary>
    public class TestGV100ADReader
    {

        [Fact]
        public async Task TestDistrict()
        {
            var textLine = "402022013108221       Heidelberg, Stadtkreis                            Heidelberg                                        42                                                                                                ";

            using var strStream = new StringReader(textLine);

            var gvReader = new GV100ADReader(strStream);

            IAsyncEnumerator<BaseRecord> enumerator = gvReader.ReadAsync().GetAsyncEnumerator();

            Assert.True(await enumerator.MoveNextAsync());
            Assert.Equal(new DateOnly(2022, 1, 31), (enumerator.Current as District).TimeStamp);
            Assert.Equal("08221", (enumerator.Current as District).RegionalCode);
            Assert.Equal("Heidelberg, Stadtkreis", (enumerator.Current as District).Name);
            Assert.Equal("Heidelberg", (enumerator.Current as District).AdministrativeHeadquarters);
            Assert.Equal(DistrictType.Stadtkreis, (enumerator.Current as District).Type);

            Assert.False(await enumerator.MoveNextAsync());
        }

        [Fact]
        public async Task TestFederaleState()
        {
            var textLine = "102022013101          Schleswig-Holstein                                Kiel                                                                                                                                                ";

            using var strStream = new StringReader(textLine);

            var gvReader = new GV100ADReader(strStream);

            IAsyncEnumerator<BaseRecord> enumerator = gvReader.ReadAsync().GetAsyncEnumerator();

            Assert.True(await enumerator.MoveNextAsync());
            Assert.Equal(new DateOnly(2022, 1, 31), (enumerator.Current as FederalState).TimeStamp);
            Assert.Equal("01", (enumerator.Current as FederalState).RegionalCode);
            Assert.Equal("Schleswig-Holstein", (enumerator.Current as FederalState).Name);
            Assert.Equal("Kiel", (enumerator.Current as FederalState).SeatOfGovernment);

            Assert.False(await enumerator.MoveNextAsync());
        }

        [Fact]
        public async Task TestGovernmentRegion()
        {
            var textLine = "2020220131051         Reg.-Bez. Düsseldorf                              Düsseldorf                                                                                                                                          ";

            using var strStream = new StringReader(textLine);

            var gvReader = new GV100ADReader(strStream);

            IAsyncEnumerator<BaseRecord> enumerator = gvReader.ReadAsync().GetAsyncEnumerator();

            Assert.True(await enumerator.MoveNextAsync());
            Assert.Equal(new DateOnly(2022, 1, 31), (enumerator.Current as GovernmentRegion).TimeStamp);
            Assert.Equal("051", (enumerator.Current as GovernmentRegion).RegionalCode);
            Assert.Equal("Reg.-Bez. Düsseldorf", (enumerator.Current as GovernmentRegion).Name);
            Assert.Equal("Düsseldorf", (enumerator.Current as GovernmentRegion).AdministrativeHeadquarters);

            Assert.False(await enumerator.MoveNextAsync());
        }

        [Fact]
        public async Task TestMunicipalAssociation()
        {
            var textLine = "502022013108221   0000Heidelberg, Stadt                                                                                   50                                                                                                ";

            using var strStream = new StringReader(textLine);

            var gvReader = new GV100ADReader(strStream);

            IAsyncEnumerator<BaseRecord> enumerator = gvReader.ReadAsync().GetAsyncEnumerator();

            Assert.True(await enumerator.MoveNextAsync());
            Assert.Equal(new DateOnly(2022, 1, 31), (enumerator.Current as MunicipalAssociation).TimeStamp);
            Assert.Equal("08221", (enumerator.Current as MunicipalAssociation).RegionalCode);
            Assert.Equal("0000", (enumerator.Current as MunicipalAssociation).Association);
            Assert.Equal("Heidelberg, Stadt", (enumerator.Current as MunicipalAssociation).Name);
            Assert.Equal("", (enumerator.Current as MunicipalAssociation).AdministrativeHeadquarters);
            Assert.Equal(MunicipalAssociationType.VerbandsfreieGemeinde, (enumerator.Current as MunicipalAssociation).Type);

            Assert.False(await enumerator.MoveNextAsync());
        }
        
        [Fact]
        public async Task TestMunicipality()
        {
            var textLine = "6020220131082260135001Eberbach, Stadt                                                                                     63    000000081150000001426700000006914    69412*****  2840130262405277                           ";

            using var strStream = new StringReader(textLine);

            var gvReader = new GV100ADReader(strStream);

            IAsyncEnumerator<BaseRecord> enumerator = gvReader.ReadAsync().GetAsyncEnumerator();

            Assert.True(await enumerator.MoveNextAsync());
            Assert.Equal(new DateOnly(2022, 1, 31), (enumerator.Current as Municipality).TimeStamp);
            Assert.Equal("08226013", (enumerator.Current as Municipality).RegionalCode);
            Assert.Equal("5001", (enumerator.Current as Municipality).Association);
            Assert.Equal("Eberbach, Stadt", (enumerator.Current as Municipality).Name);
            Assert.Equal(MunicipalityType.Stadt, (enumerator.Current as Municipality).Type);
            Assert.Equal("69412", (enumerator.Current as Municipality).PostalCode);
            Assert.True((enumerator.Current as Municipality).MultiplePostalCodes);
            Assert.Equal("2840", (enumerator.Current as Municipality).TaxOfficeDistrict);
            Assert.Equal("1", (enumerator.Current as Municipality).HigherRegionalCourtDistrict);
            Assert.Equal("3", (enumerator.Current as Municipality).RegionalCourtDistrict);
            Assert.Equal("02", (enumerator.Current as Municipality).LocalCourtDistrict);
            Assert.Equal("62405", (enumerator.Current as Municipality).EmploymentAgencyDistrict);

            Assert.False(await enumerator.MoveNextAsync());
        }
        
        [Fact]
        public async Task TestRegion()
        {
            var textLine = "30202201310822        Region Rhein-Neckar                               Mannheim                                                                                                                                            ";

            using var strStream = new StringReader(textLine);

            var gvReader = new GV100ADReader(strStream);

            IAsyncEnumerator<BaseRecord> enumerator = gvReader.ReadAsync().GetAsyncEnumerator();

            Assert.True(await enumerator.MoveNextAsync());
            Assert.Equal(new DateOnly(2022, 1, 31), (enumerator.Current as Region).TimeStamp);
            Assert.Equal("0822", (enumerator.Current as Region).RegionalCode);
            Assert.Equal("Region Rhein-Neckar", (enumerator.Current as Region).Name);
            Assert.Equal("Mannheim", (enumerator.Current as Region).AdministrativeHeadquarters);

            Assert.False(await enumerator.MoveNextAsync());
        }
    }
}

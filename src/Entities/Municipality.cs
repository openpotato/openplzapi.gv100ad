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

namespace OpenPlzApi.GV100AD
{
    /// <summary>
    /// Representation of a municipality (Gemeinde) from GV100AD
    /// </summary>
    public class Municipality : BaseRecord
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Municipality"/> class.
        /// </summary>
        /// <param name="line">A text row with Satzart 60</param>
        public Municipality(string line)
            : base(line)
        {
            RegionalCode = line.Substring(10, 8);
            Association = line.Substring(18, 4);
            Type = (MunicipalityType)byte.Parse(line.Substring(122, 2) == "  " ? "0" : line.Substring(122, 2));  
            Area = uint.Parse(line.Substring(128, 11));
            Inhabitants = uint.Parse(line.Substring(139, 11));
            InhabitantsMale = uint.Parse(line.Substring(150, 11));
            PostalCode = line.Substring(165, 5);
            MultiplePostalCodes = !string.IsNullOrEmpty(line.Substring(170, 5).Trim());
            TaxOfficeDistrict = line.Substring(177, 4);
            HigherRegionalCourtDistrict = line.Substring(181, 1);
            RegionalCourtDistrict = line.Substring(182, 1);
            LocalCourtDistrict = line.Substring(183, 2);
            EmploymentAgencyDistrict = line.Substring(185, 5);
        }

        /// <summary>
        /// Area in hectares (EF8)
        /// </summary>
        public uint Area { get; }

        /// <summary>
        /// Gemeindeverband (EF4)
        /// </summary>
        public string Association { get; }

        /// <summary>
        /// Arbeitsagenturbezirk (EF16)
        /// </summary>
        public string EmploymentAgencyDistrict { get; }

        /// <summary>
        /// Oberlandesgerichtsbezirk (EF15U1)
        /// </summary>
        public string HigherRegionalCourtDistrict { get; }

        /// <summary>
        /// Total population (EF9)
        /// </summary>
        public uint Inhabitants { get; }

        /// <summary>
        /// Male population (EF10)
        /// </summary>
        public uint InhabitantsMale { get; }

        /// <summary>
        /// Amtsgerichtsbezirk (EF15U3)
        /// </summary>
        public string LocalCourtDistrict { get; }

        /// <summary>
        /// Multiple postcodes available? (EF12U2)
        /// </summary>
        public bool MultiplePostalCodes { get; }

        /// <summary>
        /// Postalcode (if there are multiple postcodes > postalcode of the Verwaltungssitz) (EF12U1)
        /// </summary>
        public string PostalCode { get; }

        /// <summary>
        /// Landgerichtsbezirk (EF15U2)
        /// </summary>
        public string RegionalCourtDistrict { get; }

        /// <summary>
        /// Finanzamtsbezirk (EF14)
        /// </summary>
        public string TaxOfficeDistrict { get; }
        
        /// <summary>
        /// Kennzeichen (EF7)
        /// </summary>
        public MunicipalityType Type { get; }
    }
}

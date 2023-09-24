#region OpenPlzApi.GV100AD - Copyright (C) 2023 STÜBER SYSTEMS GmbH
/*    
 *    OpenPlzApi.GV100AD 
 *    
 *    Copyright (C) 2023 STÜBER SYSTEMS GmbH
 *
 *    Licensed under the MIT License, Version 2.0. 
 * 
 */
#endregion

namespace OpenPlzApi.GV100AD
{
    /// <summary>
    /// Representation of a municipal association (Gemeindeverband) from GV100AD
    /// </summary>
    public class MunicipalAssociation : BaseRecord
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MunicipalAssociation"/> class.
        /// </summary>
        /// <param name="line">A text row with Satzart 50</param>
        public MunicipalAssociation(string line)
            : base(line)
        {
            RegionalCode = line.Substring(10, 5);
            Association = line.Substring(18, 4);
            AdministrativeHeadquarters = line.Substring(72, 50).TrimEnd();
            Type = (MunicipalAssociationType)byte.Parse(line.Substring(122, 2) == "  " ? "0" : line.Substring(122, 2)); 
        }

        /// <summary>
        /// Verwaltungssitz des Gemeindeverbandes (EF6)
        /// </summary>
        public string AdministrativeHeadquarters { get; }

        /// <summary>
        /// Gemeindeverband (EF4)
        /// </summary>
        public string Association { get; }

        /// <summary>
        /// Kennzeichen (EF7)
        /// </summary>
        public MunicipalAssociationType Type { get; }
    }
}

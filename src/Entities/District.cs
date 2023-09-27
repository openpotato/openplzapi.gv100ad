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
    /// Representation of a district (Kreis) from GV100AD
    /// </summary>
    public class District : BaseRecord
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="District"/> class.
        /// </summary>
        /// <param name="line">A text row with Satzart 40</param>
        public District(string line)
            : base(line)
        {
            RegionalCode = line.Substring(10, 5);
            AdministrativeHeadquarters = line.Substring(72, 50).TrimEnd();
            Type = (DistrictType)byte.Parse(line.Substring(122, 2) == "  " ? "0" : line.Substring(122, 2));
        }

        /// <summary>
        /// Sitz der Kreisverwaltung (EF6)
        /// </summary>
        public string AdministrativeHeadquarters { get; }

        /// <summary>
        /// Kennzeichen (EF7)
        /// </summary>
        public DistrictType Type { get; }
    }
}

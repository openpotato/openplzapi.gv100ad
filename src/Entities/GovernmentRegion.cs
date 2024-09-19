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
    /// Representation of a government region (Regierungsbezirk) from GV100AD
    /// </summary>
    public class GovernmentRegion : BaseRecord
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GovernmentRegion"/> class.
        /// </summary>
        /// <param name="line">A text row with Satzart 20</param>
        public GovernmentRegion(string line)
            : base(line)
        {
            RegionalCode = line.Substring(10, 3);
            AdministrativeHeadquarters = line.Substring(72, 50).TrimEnd();
        }

        /// <summary>
        /// Verwaltungssitz des Regierungsbezirks (EF6)
        /// </summary>
        public string AdministrativeHeadquarters { get; set; }
    }
}

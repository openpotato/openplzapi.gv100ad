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
    /// Representation of a region (Region) from GV100AD
    /// </summary>
    public class Region : BaseRecord
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Region"/> class.
        /// </summary>
        /// <param name="line">A text row with Satzart 30</param>
        public Region(string line)
            : base(line)
        {
            RegionalCode = line.Substring(10, 5).TrimEnd();
            AdministrativeHeadquarters = line.Substring(72, 50).TrimEnd();
        }

        /// <summary>
        /// Verwaltungssitz der Region (EF6)
        /// </summary>
        public string AdministrativeHeadquarters { get; set; }
    }
}

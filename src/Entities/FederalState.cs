#region OpenPlzApi.GV100AD - Copyright (C) 2022 STÜBER SYSTEMS GmbH
/*    
 *    OpenPlzApi.GV100AD 
 *    
 *    Copyright (C) 2022 STÜBER SYSTEMS GmbH
 *
 *    Licensed under the MIT License, Version 2.0. 
 * 
 */
#endregion

namespace OpenPlzApi.GV100AD
{
    /// <summary>
    /// Representation of a federal state (Bundesland) from GV100AD
    /// </summary>
    public class FederalState : BaseRecord
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FederalState"/> class.
        /// </summary>
        /// <param name="line">A text row with Satzart 10</param>
        public FederalState(string line)
            : base(line)
        {
            RegionalCode = line.Substring(10, 2);
            SeatOfGovernment = line.Substring(72, 50).TrimEnd();
        }

        /// <summary>
        /// Sitz der Landesregierung (EF6)
        /// </summary>
        public string SeatOfGovernment { get; set; }
    }
}

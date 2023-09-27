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

using System;
using System.Globalization;

namespace OpenPlzApi.GV100AD
{
    /// <summary>
    /// An abstract representation of a GV100AD record
    /// </summary>
    public abstract class BaseRecord
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRecord"/> class.
        /// </summary>
        /// <param name="line">A text row from a GV100AD file</param>
        public BaseRecord(string line)
        {
            TimeStamp = DateOnly.ParseExact(line.Substring(2, 8), "yyyyMMdd", CultureInfo.InvariantCulture);
            Name = line.Substring(22, 50).TrimEnd();
        }

        /// <summary>
        /// Bezeichnung (EF5)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Regionalschlüssel (EF3)
        /// </summary>
        public string RegionalCode { get; set; }

        /// <summary>
        /// Gebietsstand (EF2)
        /// </summary>
        public DateOnly TimeStamp { get; }
    }
}

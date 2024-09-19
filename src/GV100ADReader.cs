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

namespace OpenPlzApi.GV100AD
{
    /// <summary>
    /// A reader for GV100AD files (Gemeindeverzeichnis) provided by Destatis. 
    /// </summary>
    public class GV100ADReader
    {
        private readonly TextReader _textReader;

        /// <summary>
        /// Initializes a new instance of the <see cref="GV100ADReader"/> class for the specified stream.
        /// </summary>
        /// <param name="textReader">The stream to be read.</param>
        /// </param>
        public GV100ADReader(TextReader textReader)
        {
            _textReader = textReader;
        }

        /// <summary>
        /// Iterates over the internal GV100AD stream and gives back GV100AD records
        /// </summary>
        /// <returns>An enumerator of <see cref="BaseRecord"/> based instances</returns>
        public IEnumerable<BaseRecord> Read()
        {
            string line;
            do
            {
                line = _textReader.ReadLine();
                if (line != null)
                {
                    yield return CreateRecord(line);
                }
            } while (line != null);
        }

        /// <summary>
        /// Iterates over the internal GV100AD stream and gives back GV100AD records
        /// </summary>
        /// <returns>An async enumerator of <see cref="BaseRecord"/> based instances</returns>
        public async IAsyncEnumerable<BaseRecord> ReadAsync()
        {
            string line;
            do
            {
                line = await _textReader.ReadLineAsync();
                if (line != null)
                {
                    yield return CreateRecord(line);
                }
            } while (line != null);
        }

        /// <summary>
        /// Creates the right <see cref="BaseRecord"/> based instance by parsing the first 2 characters (Satzart) 
        /// of the given text line.
        /// </summary>
        /// <param name="line">Text line</param>
        /// <returns>A new <see cref="BaseRecord"/> based instance </returns>
        private static BaseRecord CreateRecord(string line)
        {
            if ((line[0] == '1') && (line[1] == '0'))
            {
                return new FederalState(line);
            }
            else if ((line[0] == '2') && (line[1] == '0'))
            {
                return new GovernmentRegion(line);
            }
            else if ((line[0] == '3') && (line[1] == '0'))
            {
                return new Region(line);
            }
            else if ((line[0] == '4') && (line[1] == '0'))
            {
                return new District(line);
            }
            else if ((line[0] == '5') && (line[1] == '0'))
            {
                return new MunicipalAssociation(line);
            }
            else if ((line[0] == '6') && (line[1] == '0'))
            {
                return new Municipality(line);
            }
            else
            {
                throw new NotSupportedException($"Record type {line[0]}{line[1]} is not supported.");
            }
        }
    }
}

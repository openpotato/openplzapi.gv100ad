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
    /// Municipal association type (Gemeindeverbandskennzeichen) 
    /// </summary>
    public enum MunicipalAssociationType
    {
        None = 0,
        VerbandsfreieGemeinde = 50,
        Amt = 51,
        Samtgemeinde = 52,
        Verbandsgemeinde = 53,
        Verwaltungsgemeinschaft = 54,
        Kirchspielslandgemeinde = 55,
        Verwaltungsverband = 56,
        VGTraegermodell = 57,
        ErfüllendeGemeinde = 58
    }
}

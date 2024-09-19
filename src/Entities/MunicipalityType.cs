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
    /// Municipality type (Gemeindekennzeichen)
    /// </summary>
    public enum MunicipalityType
    {
        None = 0,
        Markt = 60,
        KreisfreieStadt = 61, 
        Stadtkreis = 62, 
        Stadt = 63, 
        KreisangehörigeGemeinde = 64,
        GemeindefreiesGebietBewohnt = 65,
        GemeindefreiesGebietUnbewohnt = 66,
        GroßeKreisstadt = 67
    }
}


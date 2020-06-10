using System.Collections.Generic;

using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;


namespace AddInInfoPuntiInPoligono.variabiliGlobali
{
    internal static class VariabiliGlobali
    {
        // Dizionario contenente le informazioni sul Layer contenuti nella TOC e il loro
        // numero posizionale!
        internal static Dictionary<int, ILayer2> dizNumPosizionaliLayer_ILayer2 =
            new Dictionary<int, ILayer2>();

        // Variabile IFeature contenente l'area cliccata dall'utente sulla quale capire
        // chi casca all'interno!
        internal static IFeature featurePoligonale = null;

        // Stringa contenente il nome del Feature Layer al quale appartiene il poligono cliccato
        // dall'utente in ArcMap.
        // Tale variabile mi serve per popolare una textbox della Dockable Window!
        internal static string nomeFeatureLayerPoligonale = string.Empty;

        internal static bool zoommaAutomaticamente = false;
    }
}

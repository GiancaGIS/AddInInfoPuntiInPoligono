using System;
using System.Collections.Generic;

using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.ADF;



namespace AddInInfoPuntiInPoligono
{
    class analisiSpaziali
    {
        public int selezionaOggettiInPoligono(ILayer2 layerConsiderato, IFeature featurePoligonale, int numeroPosizionale)
        {
            try
            {
                IGeometry geometriaPoligonale = featurePoligonale.ShapeCopy;
                IFeatureClass fClassPoligono = featurePoligonale.Table as IFeatureClass;

                ISpatialFilter filtroSpaziale = new SpatialFilter();
                filtroSpaziale.Geometry = geometriaPoligonale;
                filtroSpaziale.GeometryField = fClassPoligono.ShapeFieldName;
                filtroSpaziale.SpatialRel = esriSpatialRelEnum.esriSpatialRelContains;

                IFeatureLayer2 fLayerConsiderato = layerConsiderato as IFeatureLayer2;
                IFeatureClass fClassConsiderato = fLayerConsiderato.FeatureClass;

                int contatore = 0;

                string OID = String.Empty;
                List<string> listaStringheOID = new List<string>();

                using (ComReleaser comReleaser = new ComReleaser())
                {
                    IFeatureCursor fCursore = fClassConsiderato.Search(filtroSpaziale, true);

                    IFeature feature = fCursore.NextFeature();

                    while (feature != null)
                    {
                        contatore += 1;
                        OID = feature.OID.ToString();
                        listaStringheOID.Add(OID);

                        feature = fCursore.NextFeature();
                    }
                }

                return contatore;
            }
            catch (Exception e)
            {
                string errore = e.Message;
                return -9999;
            }
        
        }
    }
}

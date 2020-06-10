using AddInInfoPuntiInPoligono.raccoglitore;
using AddInInfoPuntiInPoligono.variabiliGlobali;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.CartoUI;
using ESRI.ArcGIS.Desktop.AddIns;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using System;
using System.Collections.Generic;
using System.Windows.Forms;



namespace AddInInfoPuntiInPoligono
{
    public class InfoPuntiInPoligono : ESRI.ArcGIS.Desktop.AddIns.Tool
    {
        private Dictionary<string, ILayer2> dizLayerPuntiPolilinee = 
            new Dictionary<string, ILayer2>();

        private analisiSpaziali classeAnalisiSpaziali = new analisiSpaziali();
        
        private raccogliInfoPerFORM _spazzolaInfo = null;

        public InfoPuntiInPoligono()
        {
            this.Cursor = Cursors.Cross;
        }

        protected override void OnUpdate()
        {
            Enabled = ArcMap.Application != null;
        }

        protected override void OnMouseDown(MouseEventArgs arg)
        {
            try
            {
                IMxDocument mxDocument = ArcMap.Application.Document as IMxDocument;
                IActiveView activeView = mxDocument.ActiveView;

                IMap map = mxDocument.FocusMap;

                analizzaSpazialmente(mxDocument, arg.X, arg.Y);
            }
            catch (Exception errore)
            {
                MessageBox.Show(errore.Message);
            }
        }


        /// <summary>
        /// Scopo di questo metodo è di flashare una IFeature di input nella active view!
        /// </summary>
        /// <param name="feature"></param>
        /// <param name="screenDisplay"></param>
        public void flashaFeature(IFeature feature, IScreenDisplay3 screenDisplay)
        {
            // Eseguo il flash dell'oggetto in ActiveView...
            IFeatureIdentifyObj feature_identify_obj = new FeatureIdentifyObject();
            feature_identify_obj.Feature = feature;

            // Creo l'oggetto IIdentifyObj e lo flasho nello screenDisplay
            IIdentifyObj identifyObj = feature_identify_obj as IIdentifyObj;
            identifyObj.Flash((IScreenDisplay)screenDisplay);
        }


        /// <summary>
        /// Funzione il cui scopo è comprendere quale è il poligono cliccato dall'utente in ArcMap.
        /// E capire quali oggetti cascano all'interno!
        /// Una volta raccolte tutte queste info, si occupa di valorizzare la dockable e farla partire se necessario!
        /// </summary>
        /// <param name="mxDocument"></param>
        /// <param name="xCoord"></param>
        /// <param name="yCoord"></param>
        public void analizzaSpazialmente(IMxDocument mxDocument, int xCoord, int yCoord)
        {
            try
            {
                dizLayerPuntiPolilinee.Clear();
                VariabiliGlobali.dizNumPosizionaliLayer_ILayer2.Clear();

                IActiveView activeView = mxDocument.ActiveView;
                IMap map = activeView.FocusMap;

                IScreenDisplay3 screenDisplay = activeView.ScreenDisplay as IScreenDisplay3;

                IPoint identifyPoint = activeView.ScreenDisplay.DisplayTransformation.ToMapPoint(xCoord, yCoord);

                IBufferConstruction operatoreBuffer = new BufferConstruction();

                IGeometry5 geometriaBuffer = operatoreBuffer.Buffer(identifyPoint, 0.1) as IGeometry5;

                IEnumLayer enumeratoreLayer = map.Layers;

                ILayer2 layer = enumeratoreLayer.Next() as ILayer2;

                IFeatureLayer2 featureLayer = null;

                string nomeLayer = string.Empty;

                bool poligonoOnTopTROVATO = false;

                int numeroPosizionaleLayer = 0;

                while (layer != null)
                {
                    VariabiliGlobali.dizNumPosizionaliLayer_ILayer2.Add(numeroPosizionaleLayer, layer);

                    nomeLayer = layer.Name;

                    if (layer.Visible && !(layer is ICompositeLayer) && !(layer is IGroupLayer))
                    {
                        featureLayer = layer as IFeatureLayer2;

                        esriGeometryType tipologiaFeatureLayer = featureLayer.ShapeType;

                        if (tipologiaFeatureLayer == esriGeometryType.esriGeometryPoint || tipologiaFeatureLayer == esriGeometryType.esriGeometryPolyline)
                        {
                            dizLayerPuntiPolilinee.Add(String.Format("{0}_{1}", numeroPosizionaleLayer, nomeLayer), layer);
                        }

                        else if (!(poligonoOnTopTROVATO) && tipologiaFeatureLayer == esriGeometryType.esriGeometryPolygon)
                        {
                            IIdentify identifyLayer = layer as IIdentify;
                            IArray array = identifyLayer.Identify(geometriaBuffer);

                            if (array != null)
                            {
                                object obj = array.get_Element(0);
                                IFeatureIdentifyObj fobj = obj as IFeatureIdentifyObj;
                                IRowIdentifyObject irow = fobj as IRowIdentifyObject;
                                VariabiliGlobali.featurePoligonale = irow.Row as IFeature;

                                poligonoOnTopTROVATO = true;
                                VariabiliGlobali.nomeFeatureLayerPoligonale = nomeLayer;
                            }
                        }

                        layer = enumeratoreLayer.Next() as ILayer2;
                        numeroPosizionaleLayer += 1;
                    }
                    else
                    {
                        layer = enumeratoreLayer.Next() as ILayer2;
                        numeroPosizionaleLayer += 1;
                    }
                }

                if (poligonoOnTopTROVATO)
                {
                    _spazzolaInfo = raccogliInfoPerFORM.Instance();

                    DockablePunti.AddinImpl dockable_Punti = AddIn.FromID<DockablePunti.AddinImpl>(ThisAddIn.IDs.DockablePunti);

                    DockablePunti avvisiWindow = dockable_Punti.UI;
                    avvisiWindow.svuotaTutto_ext();
                    avvisiWindow.InitLog(_spazzolaInfo);
                    avvisiWindow.aggiornatextBoxLayerPoligonale();


                    string strNomeLayer = String.Empty;
                    ILayer2 layerConsiderato = null;
                    int numeroOggetti = 0;
                    int idxPosizionalePerDizionarioGlobale = 0;

                    foreach (KeyValuePair<string, ILayer2> chiaveValore in dizLayerPuntiPolilinee)
                    {
                        strNomeLayer = chiaveValore.Key.Split('_')[1].ToString();
                        idxPosizionalePerDizionarioGlobale = Convert.ToInt32(chiaveValore.Key.Split('_')[0].ToString());

                        layerConsiderato = chiaveValore.Value;

                        numeroOggetti = classeAnalisiSpaziali.selezionaOggettiInPoligono(layerConsiderato, VariabiliGlobali.featurePoligonale, idxPosizionalePerDizionarioGlobale);

                        _spazzolaInfo.aggiungiInfo(strNomeLayer, numeroOggetti.ToString(), idxPosizionalePerDizionarioGlobale.ToString());
                    }

                    this.flashaFeature(VariabiliGlobali.featurePoligonale, screenDisplay);

                    // Mi occupo della apertura della Dockable Window
                    UID dockableUID = new UID();
                    dockableUID.Value = ThisAddIn.IDs.DockablePunti;

                    IDockableWindow dockable = ArcMap.DockableWindowManager.GetDockableWindow(dockableUID);

                    if (!(dockable.IsVisible()))
                    {
                        dockable.Show(true);
                    }
                }
            }
            catch
            {
                throw; // Rigetto l'errore al Catch di sopra...
            }
        }
    }
}
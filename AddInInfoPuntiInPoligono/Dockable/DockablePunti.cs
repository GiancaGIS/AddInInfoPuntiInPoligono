using System;
using System.Windows.Forms;

using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;

using AddInInfoPuntiInPoligono.raccoglitore;
using AddInInfoPuntiInPoligono.variabiliGlobali;
using ESRI.ArcGIS.Geometry;


namespace AddInInfoPuntiInPoligono
{
    /// <summary>
    /// Designer class of the dockable window add-in. It contains user interfaces that
    /// make up the dockable window.
    /// </summary>
    public partial class DockablePunti : UserControl
    {
        private raccogliInfoPerFORM _spazzolatoreInfo = null;

        public DockablePunti(object hook)
        {
            InitializeComponent();
            this.Hook = hook;
        }

        /// <summary>
        /// Host object of the dockable window
        /// </summary>
        private object Hook
        {
            get;
            set;
        }

        /// <summary>
        /// Implementation class of the dockable window add-in. It is responsible for 
        /// creating and disposing the user interface class of the dockable window.
        /// </summary>
        public class AddinImpl : ESRI.ArcGIS.Desktop.AddIns.DockableWindow
        {
            private DockablePunti m_windowUI;
            
            public AddinImpl()
            {
            }

            /// <summary>
            /// Ritorna la Dockable senza la classe AddinImpl
            /// </summary>
            internal DockablePunti UI
            {
                get { return m_windowUI; }
            }

            protected override IntPtr OnCreateChild()
            {
                m_windowUI = new DockablePunti(this.Hook);
                return m_windowUI.Handle;
            }

            protected override void Dispose(bool disposing)
            {
                if (m_windowUI != null)
                    m_windowUI.Dispose(disposing);

                base.Dispose(disposing);
            }

        }

        public void InitLog(raccogliInfoPerFORM hookHelper)
        {
            if (_spazzolatoreInfo == null)
            {
                _spazzolatoreInfo = hookHelper;
            }
            _spazzolatoreInfo.infoAggiornate -= new EventHandler(_spazzolatore_ListViewUpdated);
            _spazzolatoreInfo.infoAggiornate += new EventHandler(_spazzolatore_ListViewUpdated);
        }

        /// <summary>
        /// Funzione richiamata allo scattare dell'evento, per valorizzare la list view presente nella
        /// Dockable Windows
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _spazzolatore_ListViewUpdated(object sender, EventArgs e)
        {
            listViewFormSTAT.SuspendLayout();

            infoPuntiInPoligono_Eventi infoEvento = e as infoPuntiInPoligono_Eventi;

            ListViewItem item = new ListViewItem();

            item.Text = infoEvento._nomeFeatureLayer;
            item.SubItems.Add(infoEvento._numPunti);
            item.SubItems.Add(infoEvento._numeroPosizionaleLayer);

            // Aggiungo l'item, e lo metto in lista!
            listViewFormSTAT.Items.Add(item);
            // Refresho e soprattutto: RIABILITO la List View!
            listViewFormSTAT.Refresh();
            listViewFormSTAT.ResumeLayout();
        }

        private void buttonPulisci_Click(object sender, EventArgs e)
        {
            this.svuotaTutto_ext();
        }

        /// <summary>
        /// Funzione per svuotare la ListView, per essere richiamata da fuori!
        /// </summary>
        public void svuotaTutto_ext()
        {
            listViewFormSTAT.Items.Clear();
            textBoxFeatureLayerSelezionato.SuspendLayout();
            textBoxFeatureLayerSelezionato.Clear();
            textBoxFeatureLayerSelezionato.Refresh();
            textBoxFeatureLayerSelezionato.ResumeLayout();
            textBoxFeatureLayerSelezionato.Refresh();

            #region Questa parte è stata commentata, in quanto c'è già evento che valorizza tale textBox, pertanto è inutile svuotarla!
            //textBoxLayerPoligonale.SuspendLayout();
            //textBoxLayerPoligonale.Clear();
            //textBoxLayerPoligonale.Refresh();
            //textBoxLayerPoligonale.ResumeLayout();
            //textBoxLayerPoligonale.Refresh();
            #endregion
        }

        private void buttonSeleziona_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewFormSTAT.SelectedItems.Count == 1)
                {
                    IMxDocument mxDoc = ArcMap.Application.Document as IMxDocument;
                    IMap mappa = mxDoc.FocusMap;
                    IActiveView activeView = mxDoc.ActiveView;
                    
                    mappa.ClearSelection();

                    ListViewItem item = listViewFormSTAT.SelectedItems[0];
                    int numeroPosizionale = Convert.ToInt32(item.SubItems[2].Text);

                    IFeature featurePoligono = VariabiliGlobali.featurePoligonale;

                    ILayer2 layer = VariabiliGlobali.dizNumPosizionaliLayer_ILayer2[numeroPosizionale];

                    ISpatialFilter filtroSpaziale = new SpatialFilter();
                    filtroSpaziale.Geometry = featurePoligono.ShapeCopy;
                    filtroSpaziale.SpatialRel = esriSpatialRelEnum.esriSpatialRelContains;

                    IFeatureLayer2 fLayer = layer as IFeatureLayer2;
                    IFeatureSelection fSelection = fLayer as IFeatureSelection;

                    #region Parte commentata non più utile col query filter
                    //List<string> listaOID = new List<string>();
                    //listaOID = VariabiliGlobali.dizNumPosizionaliLayer_OID[numeroPosizionale];

                    //IEnumLayer enumeratoreLayer = mappa.Layers;

                    //ILayer2 layer = mappa.Layer[numeroPosizionale] as ILayer2;

                    //IFeatureLayer2 fLayer = layer as IFeatureLayer2;
                    //IFeatureSelection fSelection = fLayer as IFeatureSelection;

                    //string espressione = String.Format("{0} IN ('', )", fLayer.FeatureClass.OIDFieldName);

                    //foreach (string objectId in listaOID)
                    //{
                    //    espressione = espressione.Replace(")", "" + objectId + ",)");
                    //}

                    //espressione = espressione.Replace(",)", ")");
                    //espressione = espressione.Replace("'',", "");

                    //IQueryFilter queryFilter = new QueryFilterClass();
                    //queryFilter.WhereClause = espressione;
                    #endregion

                    fSelection.SelectFeatures(filtroSpaziale, esriSelectionResultEnum.esriSelectionResultNew, false);

                    ISelectionSet2 selezione = fSelection.SelectionSet as ISelectionSet2;

                    if (VariabiliGlobali.zoommaAutomaticamente)
                    {
                        IEnumGeometry enumGeom = new EnumFeatureGeometry();
                        IEnumGeometryBind enumGeomBind = enumGeom as IEnumGeometryBind;

                        enumGeomBind.BindGeometrySource(null, selezione);

                        IGeometryFactory3 geomFactory = new GeometryEnvironment() as IGeometryFactory3;
                        IGeometry geometriaTotale = geomFactory.CreateGeometryFromEnumerator(enumGeom);

                        mxDoc.ActiveView.Extent = geometriaTotale.Envelope;

                    }

                    mxDoc.ActiveView.Refresh();

                    this.aggiornatextBoxLayerDentro(layer.Name);
                }
            }
            catch (Exception errore)
            {
                MessageBox.Show(errore.Message, "ERRORE NELLA SELEZIONE!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancellaSelezioneMappa(object sender, EventArgs e)
        {
            IMxDocument mxDoc = ArcMap.Application.Document as IMxDocument;
            IMap mappa = mxDoc.FocusMap;
            mappa.ClearSelection();
            mxDoc.ActiveView.Refresh();
        }

        private void textBoxLayerPoligonale_TextChanged(object sender, EventArgs e)
        {
            this.aggiornatextBoxLayerPoligonale();
        }

        public void aggiornatextBoxLayerPoligonale()
        {
            textBoxLayerPoligonale.SuspendLayout();
            textBoxLayerPoligonale.Text = VariabiliGlobali.nomeFeatureLayerPoligonale;
            textBoxLayerPoligonale.Refresh();
            textBoxLayerPoligonale.ResumeLayout();
            textBoxLayerPoligonale.Refresh();
        }

        private void aggiornatextBoxLayerDentro(string nomeLayerSceltoCheCascaDentro)
        {
            textBoxFeatureLayerSelezionato.SuspendLayout();
            textBoxFeatureLayerSelezionato.Text = nomeLayerSceltoCheCascaDentro;
            textBoxFeatureLayerSelezionato.Refresh();
            textBoxFeatureLayerSelezionato.ResumeLayout();
            textBoxFeatureLayerSelezionato.Refresh();
        }

        private void checkBoxZoommaDinamicamente_CheckedChanged(object sender, EventArgs e)
        {
            VariabiliGlobali.zoommaAutomaticamente = checkBoxZoommaDinamicamente.Checked;
        }
    }
}

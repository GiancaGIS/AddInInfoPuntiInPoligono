using System;
using System.Windows.Forms;

using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Framework;


namespace AddInInfoPuntiInPoligono
{
    public class BottoneApriDockable : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        public BottoneApriDockable()
        {
        }

        protected override void OnClick()
        {
            try
            {
                UID dockableUID = new UIDClass();
                dockableUID.Value = ThisAddIn.IDs.DockablePunti;

                IDockableWindow dockable = ArcMap.DockableWindowManager.GetDockableWindow(dockableUID);
                dockable.Show(true);
            }

            catch (Exception errore)
            {
                MessageBox.Show(errore.Message, "ERRORE NELLA APERTURA DELLA DOCKABLE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnUpdate()
        {
        }
    }
}

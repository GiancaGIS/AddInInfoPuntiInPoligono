using System;

namespace AddInInfoPuntiInPoligono.raccoglitore
{
    public class infoPuntiInPoligono_Eventi : System.EventArgs
    {
        public string _nomeFeatureLayer = String.Empty;
        public string _numPunti = String.Empty;
        public string _numeroPosizionaleLayer = String.Empty;

        public infoPuntiInPoligono_Eventi(string nomeFeatureLayer, string numPunti, string numeroPosizionale)
        {
            _numPunti = numPunti;
            _nomeFeatureLayer = nomeFeatureLayer;
            _numeroPosizionaleLayer = numeroPosizionale;
        }
    }

    public class raccogliInfoPerFORM
    {
        private static raccogliInfoPerFORM _istanza = null;

        private raccogliInfoPerFORM()
        {
        }

        public event EventHandler infoAggiornate;

        /// <summary>
        /// Se la classe non è instanziata, la istanzio!
        /// </summary>
        /// <returns></returns>
        public static raccogliInfoPerFORM Instance()
        {
            if (_istanza == null)
            {
                _istanza = new raccogliInfoPerFORM();
            }

            return _istanza;
        }

        public void aggiungiInfo(string nomeFeatureLayer, string numPunti, string numeroPosizionaleLayer)
        {
            // Raise un evento di update
            if (infoAggiornate != null)
            {
                infoAggiornate(this, new infoPuntiInPoligono_Eventi(nomeFeatureLayer, numPunti, numeroPosizionaleLayer));
            }
        }
    }
}

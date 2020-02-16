using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020_02_11_databanken.Business
{
    public class OudleerlingMetStudieRichting
    {
        private int _pKOudleerling;
        private int _pKStudierichting;
        private DateTime _startDatum;
        private bool _geslaagd;
        public int PKOudleerling
        {get { return _pKOudleerling; }}
        public int PKStudierichting
        {get { return _pKStudierichting; }}
        public DateTime StartDatum
        { get { return _startDatum; } }
        public bool Geslaagd
        { get { return _geslaagd; }
          set { _geslaagd = value; }}
        public OudleerlingMetStudieRichting(int pkOLL, int pkStudierichting, DateTime start,  bool geslaagd)
        {
            _pKOudleerling = pkOLL;
            _pKStudierichting = pkStudierichting;
            _startDatum = start;
            _geslaagd = geslaagd;
        }
        
        public OudleerlingMetStudieRichting(int pkOLL, int pkStudierichting, DateTime start)
        {
            _pKOudleerling = pkOLL;
            _pKStudierichting = pkStudierichting;
            _startDatum = start;          
            _geslaagd = false;
        }
        

    }
}

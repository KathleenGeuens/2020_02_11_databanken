using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020_02_11_databanken.Business
{
    static class OudleerlingMetStudierichtingRepository
    {
        private static List<OudleerlingMetStudieRichting> _oudleerlingVolgtStudieRichting = new List<OudleerlingMetStudieRichting>();
        public static List<OudleerlingMetStudieRichting> OudleerlingMetStudieRichtingen
        {
            get { return _oudleerlingVolgtStudieRichting; }
            set { _oudleerlingVolgtStudieRichting = value; }
        }
        public static void addOudleerlingVolgtStudieRichting(OudleerlingMetStudieRichting item)
        {
            _oudleerlingVolgtStudieRichting.Add(item);
        }
        public static void adjustStudie(int idOLL,int idStudieRichting,bool geslaagd)
        {
            foreach(OudleerlingMetStudieRichting item in _oudleerlingVolgtStudieRichting)
            {
                if (item.PKOudleerling == idOLL || item.PKStudierichting == idStudieRichting)
                {
                    item.Geslaagd = geslaagd;
                    return;
                }
            }
        }
       
    }
}

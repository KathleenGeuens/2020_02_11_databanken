using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020_02_11_databanken.Business
{
    static class OudleerlingRepository
    {
        private static List<Oudleerling> _oudleerlingen = new List<Oudleerling>();
        public static List<Oudleerling> Oudleerlingen
        {
            get { return _oudleerlingen; }
            set { _oudleerlingen = value; }
        }
        public static void addOudleerling(Oudleerling item)
        {
            _oudleerlingen.Add(item);
        }
    }
}

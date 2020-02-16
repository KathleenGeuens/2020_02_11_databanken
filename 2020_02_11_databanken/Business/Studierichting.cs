using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020_02_11_databanken.Business
{
    public class Studierichting
    {
        private int _iDStudieRichting;
        private string _naamStudierichting;
        private string _hogeschoolUnif;
        public int IDStudieRichting
        { get { return _iDStudieRichting; } }
        public string NaamStudierichting
        { get { return _naamStudierichting; }
            set { _naamStudierichting = value; }}
        public string HogeschoolUnif
        { get { return _hogeschoolUnif; }
        set { _hogeschoolUnif = value; }}
        public Studierichting(int id,string naam, string naamschool)
        {
            _iDStudieRichting = id;
            _naamStudierichting = naam;
            _hogeschoolUnif = naamschool;
        }
        public Studierichting(string naam, string naamschool)
        {
            _iDStudieRichting = 0;
            _naamStudierichting = naam;
            _hogeschoolUnif = naamschool;
        }
        public override string ToString()
        {
            return _naamStudierichting+ " - " + _hogeschoolUnif;
        }
    }
}

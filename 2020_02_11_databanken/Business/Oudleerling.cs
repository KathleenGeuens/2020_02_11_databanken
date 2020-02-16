using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020_02_11_databanken.Business
{
    public class Oudleerling
    {
        private int _iDOudleerling;
        private string _familienaam;
        private string _voornaam;
        private string _ricthingkOsh;
        private string _straatNr;
        private string _postcode;
        private string _gemeente;
        private string _gSMNummer;
        private string _mailAdres;
        public int IDOudleerling
        { get { return _iDOudleerling; } }
        public string Familienaam
        {
            get { return _familienaam; }
        //    set { _familienaam = value; }
        }
        public string Voornaam
        {
            get { return _voornaam; }
        //    set { _voornaam = value; }
        }
        public string RicthingkOsh
        {
            get { return _ricthingkOsh; }
        //    set { _ricthingkOsh  = value; }
        }
        public string StraatNr
        {
            get { return _straatNr; }
            set { _straatNr = value; }
        }
        public string Postcode
        {
            get { return _postcode; }
            set { _postcode = value; }
        }
        public string Gemeente
        {
            get { return _gemeente; }
            set { _gemeente = value; }
        }
        public string GSMNummer
        {
            get { return _gSMNummer; }
            set { _gSMNummer = value; }
        }
        public string MailAdres
        {
            get { return _mailAdres; }
            set { _mailAdres = value; }
        }

        public Oudleerling(int id, string fn, string vn, string richting, string straatNr, string pc, string gemeente, string gsmnr, string mail)
        {
            _iDOudleerling = id;
            _familienaam = fn;
            _voornaam = vn;
            _ricthingkOsh = richting;
            _straatNr = straatNr;
            _postcode = pc;
            _gemeente = gemeente;
            _gSMNummer = gsmnr;
            _mailAdres = mail;
        }
        public Oudleerling( string fn, string vn, string richting, string straatNr, string pc, string gemeente, string gsmnr, string mail)
        {
            _iDOudleerling =0;
            _familienaam = fn;
            _voornaam = vn;
            _ricthingkOsh = richting;
            _straatNr = straatNr;
            _postcode = pc;
            _gemeente = gemeente;
            _gSMNummer = gsmnr;
            _mailAdres = mail;
        }
        public override string ToString()
        {
            return _voornaam + " " + _familienaam;
        }
    }
}

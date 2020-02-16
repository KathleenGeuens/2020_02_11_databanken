using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020_02_11_databanken.Business
{
    static class StudierichtingRepository
    {
        private static List<Studierichting> _studierichtingen = new List<Studierichting>();
        public static List<Studierichting> Studierichtingen
        {
            get { return _studierichtingen; }
            set { _studierichtingen = value; }
        }
        public static void addStudierichting(Studierichting item)
        {
            _studierichtingen.Add(item);
        }
       
    }
}

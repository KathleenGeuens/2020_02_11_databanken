using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2020_02_11_databanken.Business;

namespace _2020_02_11_databanken.Persistence
{
    public class Controller
    {
        private string _connectionstring;
        public Controller()
        { _connectionstring = "server = localhost; user id = root;password=1234; database=2020_02_11_toets"; }
        public Controller(string connectionstring)
        { _connectionstring = connectionstring; }
        public List<Studierichting> getStudieRichtingen()
        {
            StudierichtingMapper mapper = new StudierichtingMapper(_connectionstring);
            return mapper.getStudierichtingenFromDB();
        }
        public void addStudierichting(Studierichting item)
        {
            StudierichtingMapper mapper = new StudierichtingMapper(_connectionstring);
            mapper.addStudierichtingToDB(item);
        }
        public List<Oudleerling> getOudleerlingen()
        {
            OudleerlingMapper mapper = new OudleerlingMapper(_connectionstring);
            return mapper.getOudleerlingenFromDB();
        }
        public void addOudleerling(Oudleerling item)
        {
            OudleerlingMapper mapper = new OudleerlingMapper(_connectionstring);
            mapper.addOudleerlingToDB(item);
        }
        public List<OudleerlingMetStudieRichting> getOudleerlingenMetStudierichtingen()
        {
            OudleerlingMetStudieRichtingMapper mapper = new OudleerlingMetStudieRichtingMapper(_connectionstring);
            return mapper.getOudleerlingMetStudieRichtingFromDB();
        }
        public void addOLLMetStudieRichting(OudleerlingMetStudieRichting item)
        {
            OudleerlingMetStudieRichtingMapper mapper = new OudleerlingMetStudieRichtingMapper(_connectionstring);
            mapper.addOudleerlingMetStudierichtingToDB(item);
        }
        public void adjustStudie(int idOLL, int idStudieRichting,bool geslaagd)
        {
            OudleerlingMetStudieRichtingMapper mapper = new OudleerlingMetStudieRichtingMapper(_connectionstring);
            mapper.adjustStudieInDB(idOLL, idStudieRichting,  geslaagd);
        }
        public List<string> getGevolgdeOpleidingenFromOudleerling(Oudleerling oll)
        {
            OudleerlingMetStudieRichtingMapper mapper = new OudleerlingMetStudieRichtingMapper(_connectionstring);
            return mapper.getGevolgdeOpleidingenFromOudleerling(oll);
        }
    }
}

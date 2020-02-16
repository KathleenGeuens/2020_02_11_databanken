using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2020_02_11_databanken.Persistence;

namespace _2020_02_11_databanken.Business
{
    public class Controller
    {
        private Persistence.Controller _persistController;

        public Controller()
        {
            _persistController = new Persistence.Controller();
            OudleerlingRepository.Oudleerlingen = _persistController.getOudleerlingen();
            OudleerlingMetStudierichtingRepository.OudleerlingMetStudieRichtingen = _persistController.getOudleerlingenMetStudierichtingen();
            StudierichtingRepository.Studierichtingen = _persistController.getStudieRichtingen();
        }
        public List<Studierichting> getStudierichtingen()
        {
            return StudierichtingRepository.Studierichtingen;
        }
            
        public void addStudierichting(Studierichting item)
        {
            _persistController.addStudierichting(item);
            StudierichtingRepository.addStudierichting(item);
        }
        public List<Oudleerling> getOudleerlingen()
        { return OudleerlingRepository.Oudleerlingen; }
        public void addOudleerling(Oudleerling item)
        {
            _persistController.addOudleerling(item);
            OudleerlingRepository.addOudleerling(item);
        }
        public  void addStudierichtingToOudleerling(int idOLL, int idStudieRichting, DateTime start )
        {
            OudleerlingMetStudieRichting newitem = new OudleerlingMetStudieRichting(idOLL, idStudieRichting, start);
            _persistController.addOLLMetStudieRichting(newitem);
            OudleerlingMetStudierichtingRepository.addOudleerlingVolgtStudieRichting(newitem);
        }
        public void sluitStudierichtingAf(int idOLL, int idStudieRichting,  bool geslaagd)
        {
            OudleerlingMetStudierichtingRepository.adjustStudie(idOLL, idStudieRichting,  geslaagd);
            _persistController.adjustStudie(idOLL, idStudieRichting, geslaagd);
        }
        public List<string> getGevolgdeOpleidingenFromOudleerling(Oudleerling oll)
        {
            return _persistController.getGevolgdeOpleidingenFromOudleerling(oll);

        }
    }
}

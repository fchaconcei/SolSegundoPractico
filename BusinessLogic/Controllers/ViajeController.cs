using CommonSolution.DTOs;
using DataAccess.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Controllers
{
    public class ViajeController
    {
        private Repository _Repository;

        public ViajeController()
        {
            this._Repository = new Repository();
        }

        //8
        public List<DtoViaje> getViajesSinChofer()
        {
            return this._Repository.GetViajeRepository().getViajesSinChofer();
        }

        //9
        public List<DtoViaje> getViajesCantPedidos()
        {
            return this._Repository.GetViajeRepository().getViajesCantPedidos();
        }
    }
}

using BusinessLogic.Interfaces;
using CommonSolution.Interfaces;
using DataAccess.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Controllers
{
    public class ClienteController : IController
    {
        private Repository _Repository;

        public ClienteController()
        {
            this._Repository = new Repository();
        }

        public List<string> Agregar(IDto dto)
        {
            throw new NotImplementedException();
        }

        //5
        public List<string> BorrarCliente(string documento)
        {
            List<string> colErrores = this.ValidarBorrado(documento);

            if (colErrores.Count == 0)
            {
                this._Repository.GetClienteRepository().BorrarCliente(documento);
            }

            return colErrores;
        }

        public List<string> ValidarBorrado(string documento)
        {
            List<string> colErrores = new List<string>();

            if (!this._Repository.GetClienteRepository().ExisteCliente(documento))
            {
                colErrores.Add("El cliente no existe");
            }

            if (this._Repository.GetPedidoRepository().ClienteConPedidos(documento))
            {
                colErrores.Add("No se puede borrar el cliente porque tiene pedidos ingresados");
            }

            return colErrores;
        }

    }
}

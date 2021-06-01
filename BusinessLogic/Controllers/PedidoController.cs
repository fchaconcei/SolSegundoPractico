using BusinessLogic.Interfaces;
using CommonSolution.DTOs;
using CommonSolution.Interfaces;
using DataAccess.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Controllers
{
    public class PedidoController : IController
    {
        private Repository _Repository;

        public PedidoController()
        {
            this._Repository = new Repository();
        }

        //1
        public List<string> Agregar(IDto dto)
        {
            List<string> colErrores = this.ValidarPedido((DtoPedido)dto, false);

            if (colErrores.Count == 0)
            {
                this._Repository.GetPedidoRepository().AgregarPedido((DtoPedido)dto);
            }

            return colErrores;
        }

        //2
        public double getPrecioTotalByPedido(long nuPedido)
        {
            double precioTotal = 0;
            List<DtoDetalle> colDetalle = this._Repository.GetPedidoRepository().GetDetallePedido(nuPedido);
            precioTotal = colDetalle.Sum(s => (s.precioUnitario ?? 0) * (s.cantidad ?? 0));
            return precioTotal;
        }

        //3
        public List<DtoPedido> getPedidoByTelefono(string tel)
        {
            return this._Repository.GetPedidoRepository().getPedidosByTelefono(tel);
        }

        //6
        public void AsignarViajePedidos(long idViaje, List<long> colNuPedido)
        {
            this._Repository.GetPedidoRepository().AsignarViajePedidos(idViaje, colNuPedido);
        }

        public List<string> ValidarPedido(DtoPedido dto, bool esModificacion)
        {
            List<string> errores = new List<string>();

            if (!this._Repository.GetClienteRepository().ExisteCliente(dto.documento))
            {
                errores.Add("El cliente no existe");
            }

            return errores;
        }

        //10
        public List<DtoTopProductos> getTopProductosPedidos()
        {
            List<DtoTopProductos> colTopProd = this._Repository.GetPedidoRepository().TopProductosPedidos();
            colTopProd = colTopProd.OrderByDescending(o => o.cantidad).ToList();

            if (colTopProd.Count > 10)
            {
                colTopProd = colTopProd.Take(10).ToList();
            }

            return colTopProd;

        }



    }
}

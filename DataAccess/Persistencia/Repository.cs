using DataAccess.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Persistencia
{
    public class Repository
    {
        public Repository()
        {
            this.pedidoRepository = new PedidoRepository();
            this.detalleRepository = new DetalleRepository();
            this.clienteRepository = new ClienteRepository();
            this.viajeRepository = new ViajeRepository();
        }

        public PedidoRepository GetPedidoRepository()
        {
            return this.pedidoRepository;
        }

        public ClienteRepository GetClienteRepository()
        {
            return this.clienteRepository;
        }

        public ViajeRepository GetViajeRepository()
        {
            return this.viajeRepository;
        }

        private PedidoRepository pedidoRepository;
        private DetalleRepository detalleRepository;
        private ClienteRepository clienteRepository;
        private ViajeRepository viajeRepository;
    }
}

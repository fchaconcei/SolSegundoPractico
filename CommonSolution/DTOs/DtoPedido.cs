using CommonSolution.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTOs
{
    public class DtoPedido : IDto
    {
        public long NroPedido;
        public string observaciones;
        public string direccion;
        public DateTime fecha_entrega;
        public DateTime fecha_ingreso;
        public string documento;
        public Nullable<long> idViaje;
        public List<DtoDetalle> colDetalles;
    }
}

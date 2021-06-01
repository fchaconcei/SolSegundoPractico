using CommonSolution.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTOs
{
    public class DtoViaje : IDto
    {
        public long idViaje { get; set; }
        public string descripcion { get; set; }
        public Nullable<int> idChofer { get; set; }
        public string estado { get; set; }
        public System.DateTime fecha_ingreso { get; set; }
        public System.DateTime fecha_viaje { get; set; }
        public double horas_estimadas { get; set; }
        public int cantidadPedidos;

    }
}

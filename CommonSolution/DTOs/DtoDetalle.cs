using CommonSolution.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTOs
{
    public class DtoDetalle : IDto
    {
        public long NuPedido;
        public string producto;
        public Nullable<short> cantidad;
        public Nullable<double> precioUnitario;
    }
}

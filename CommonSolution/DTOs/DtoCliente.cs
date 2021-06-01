using CommonSolution.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution
{
    public class DtoCliente : IDto
    {
        public string documento;
        public string nombre;
        public string apellido;
        public string telefono;
        public string direccion; 
    }
}

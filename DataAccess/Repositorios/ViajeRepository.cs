using CommonSolution;
using CommonSolution.DTOs;
using DataAccess.Mapper;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositorios
{
    public class ViajeRepository
    {

        private ViajeMapper _viajeMapper;
        public ViajeRepository()
        {
            this._viajeMapper = new ViajeMapper();
        }


        public List<DtoViaje> getViajesSinChofer()
        {
            List<DtoViaje> colViajes = null;
            using (TrackingEntities context = new TrackingEntities())
            {
                List<Viaje> colViajesEntity = context.Viaje.AsNoTracking().Include("Pedido").Where(w => w.idChofer == null && w.Pedido.Count > 0).ToList();
                colViajes = this._viajeMapper.mapToDto(colViajesEntity);
            }

            return colViajes;
        }


        public List<DtoViaje> getViajesCantPedidos()
        {
            List<DtoViaje> colViajes = null;
            using (TrackingEntities context = new TrackingEntities())
            {
                List<DtoViaje> colViajesEntity = (from viaje in context.Viaje.Include("Pedido")                                               
                                               select new DtoViaje
                                               {
                                                   idViaje = viaje.idViaje,
                                                   descripcion = viaje.descripcion,
                                                   estado = viaje.estado,
                                                   idChofer = viaje.idChofer,
                                                   fecha_ingreso = viaje.fecha_ingreso,
                                                   fecha_viaje = viaje.fecha_viaje,
                                                   cantidadPedidos = viaje.Pedido.Count()
                                               }).ToList();
            }

            return colViajes;
        }



    }
}

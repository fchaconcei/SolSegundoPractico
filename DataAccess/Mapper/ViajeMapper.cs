using CommonSolution.DTOs;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class ViajeMapper
    {
        public DtoViaje mapToDto(Viaje viaje)
        {
            DtoViaje dto = new DtoViaje();
            dto.idViaje = viaje.idViaje;
            dto.fecha_ingreso = viaje.fecha_ingreso;
            dto.estado = viaje.estado;
            dto.fecha_viaje = viaje.fecha_viaje;
            dto.horas_estimadas = viaje.horas_estimadas;
            dto.idChofer = viaje.idChofer;
            dto.descripcion = viaje.descripcion;

            return dto;
        }

        public List<DtoViaje> mapToDto(List<Viaje> colViajes)
        {
            List<DtoViaje> colDtoViaje = new List<DtoViaje>();
            foreach (Viaje entity in colViajes)
            {
                DtoViaje dto = mapToDto(entity);
                colDtoViaje.Add(dto);
            }
            return colDtoViaje;
        }
    }
}

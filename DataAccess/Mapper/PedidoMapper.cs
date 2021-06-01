using CommonSolution.DTOs;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class PedidoMapper
    {
        public DtoPedido mapToDto(Pedido pedido)
        {
            DtoPedido dto = new DtoPedido();
            dto.direccion = pedido.direccion;
            dto.documento = pedido.documento;
            dto.fecha_entrega = pedido.fecha_entrega;
            dto.fecha_ingreso = pedido.fecha_ingreso;
            dto.idViaje = pedido.idViaje;
            dto.NroPedido = pedido.NuPedido;
            dto.observaciones = pedido.observaciones;
            dto.colDetalles = this.mapDetalleToDto(pedido.DetallePedido.ToList());
            return dto;
        }

        public List<DtoPedido> mapToDto(List<Pedido> colPedidos)
        {
            List<DtoPedido> colDtoPedido = new List<DtoPedido>();
            foreach (Pedido entity in colPedidos)
            {
                DtoPedido dto = mapToDto(entity);
                colDtoPedido.Add(dto);
            }
            return colDtoPedido;
        }


        public DtoDetalle mapDetalleToDto(DetallePedido det)
        {
            DtoDetalle dto = new DtoDetalle();
            dto.cantidad = det.cantidad;
            dto.NuPedido = det.NuPedido;
            dto.precioUnitario = det.precioUnitario;
            dto.producto = det.producto;
            return dto;
        }

        public List<DtoDetalle> mapDetalleToDto(List<DetallePedido> colDet)
        {
            List<DtoDetalle> colDtos = new List<DtoDetalle>();

            foreach (DetallePedido entity in colDet)
            {
                DtoDetalle dto = mapDetalleToDto(entity);
                colDtos.Add(dto);
            }         
            return colDtos;
        }

        public Pedido mapToEntity(DtoPedido dto)
        {
            Pedido pedido = new Pedido();
            pedido.direccion = dto.direccion;
            pedido.documento = dto.documento;
            pedido.fecha_entrega = dto.fecha_entrega;
            pedido.fecha_ingreso = dto.fecha_ingreso;
            pedido.idViaje = dto.idViaje;
            pedido.NuPedido = dto.NroPedido;
            pedido.observaciones = dto.observaciones;
            pedido.DetallePedido = this.mapDtoDetalleToEntity(dto.colDetalles);
            return pedido;
        }

        public Pedido mapToEntityPedido(DtoPedido dto)
        {
            Pedido pedido = new Pedido();
            pedido.direccion = dto.direccion;
            pedido.documento = dto.documento;
            pedido.fecha_entrega = dto.fecha_entrega;
            pedido.fecha_ingreso = dto.fecha_ingreso;
            pedido.idViaje = dto.idViaje;
            pedido.NuPedido = dto.NroPedido;
            pedido.observaciones = dto.observaciones;
            return pedido;
        }

        public DetallePedido mapDtoDetalleToEntity(DtoDetalle dto)
        {
            DetallePedido det = new DetallePedido();
            det.cantidad = dto.cantidad;
            det.NuPedido = dto.NuPedido;
            det.precioUnitario = dto.precioUnitario;
            det.producto = dto.producto;
            return det;
        }

        public List<DetallePedido> mapDtoDetalleToEntity(List<DtoDetalle> colDtos)
        {
            List<DetallePedido> detallePedidos = new List<DetallePedido>();
            foreach (DtoDetalle item in colDtos)
            {
                DetallePedido detalle = this.mapDtoDetalleToEntity(item);
                detallePedidos.Add(detalle);
            }
            
            return detallePedidos;
        }

    }
}

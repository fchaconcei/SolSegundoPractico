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
    public class PedidoRepository
    {
        public PedidoRepository()
        {
            this.pedidoMapper = new PedidoMapper();
        }

        private PedidoMapper pedidoMapper;

        public void AgregarPedido(DtoPedido dto)
        {
            //V1
            using (TrackingEntities context = new TrackingEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        Pedido pedidoEntity = this.pedidoMapper.mapToEntity(dto);
                        context.Pedido.Add(pedidoEntity);
                        context.SaveChanges();
                        trann.Commit();
                    }
                    catch (Exception ex)
                    {
                        trann.Rollback();
                    }
                }
            }

            //V2
            /*
            using (TrackingEntities context = new TrackingEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        Pedido pedidoEntity = this.pedidoMapper.mapToEntity(dto);
                        context.Pedido.Add(pedidoEntity);
                        context.SaveChanges();

                        foreach (DtoDetalle detalle in dto.colDetalles)
                        {
                            DetallePedido detalleEntity = this.pedidoMapper.mapDtoDetalleToEntity(detalle);
                            detalleEntity.NuPedido = pedidoEntity.NuPedido;
                            context.DetallePedido.Add(detalleEntity);
                        }

                        context.SaveChanges();
                        trann.Commit();
                    }
                    catch (Exception ex)
                    {
                        trann.Rollback();
                    }
                }
            }
            */
        }

        public List<DtoDetalle> GetDetallePedido(long nuPedido)
        {
            List<DtoDetalle> colDtoDetalle = new List<DtoDetalle>();

            using (TrackingEntities context = new TrackingEntities())
            {
                List<DetallePedido> colDetalleEntity = context.DetallePedido.AsNoTracking().Where(w => w.NuPedido == nuPedido).ToList();
                colDtoDetalle = this.pedidoMapper.mapDetalleToDto(colDetalleEntity);
            }

            return colDtoDetalle;
        }


        public List<DtoPedido> getPedidosByTelefono(string telefono)
        {
            List<DtoPedido> colPedido = null;

            using (TrackingEntities context = new TrackingEntities())
            {
                List<Pedido> colPedidoEntity = context.Pedido.Include("Cliente").Include("DetallePedido").AsNoTracking().Where(w => w.Cliente.telefono == telefono).ToList();
                colPedido = this.pedidoMapper.mapToDto(colPedidoEntity);
            }

            return colPedido;
        }

        public bool ClienteConPedidos(string documento)
        {
            bool result = false;

            using (TrackingEntities context = new TrackingEntities())
            {
                result = context.Pedido.AsNoTracking().Include("Cliente").Any(a => a.Cliente.documento == documento);
            }

            return result;
        }

        public void AsignarViajePedidos(long idViaje, List<long> colNuPedidos)
        {
            using (TrackingEntities context = new TrackingEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        foreach (long nuPedido in colNuPedidos)
                        {
                            Pedido pedidoEntity = context.Pedido.FirstOrDefault(f => f.NuPedido == nuPedido);
                            pedidoEntity.idViaje = idViaje;
                        }

                        context.SaveChanges();
                        trann.Commit();

                    }
                    catch (Exception ex)
                    {
                        trann.Rollback();
                    }
                }
            }
        }

        public List<DtoTopProductos> TopProductosPedidos()
        {
            List<DtoTopProductos> colDto = new List<DtoTopProductos>();

            using (TrackingEntities context = new TrackingEntities())
            {
                //V1
                colDto = (from det in context.DetallePedido.AsNoTracking()
                          group det by det.producto into grp
                          select new DtoTopProductos
                          {
                              producto = grp.Key,
                              cantidad = grp.Count()
                          }).ToList();


                /*-- SQL
                select 
                Producto,
                count(*) as Cantidad
                from 
                DetallePedido
                group by DetallePedido.producto;
               */

                //V2
                colDto = context.DetallePedido.AsNoTracking().GroupBy(grp => grp.producto).Select(s => new DtoTopProductos
                {

                    producto = s.Key,
                    cantidad = s.Count()

                }).ToList();

               

            }

            return colDto;
        }
    }
}

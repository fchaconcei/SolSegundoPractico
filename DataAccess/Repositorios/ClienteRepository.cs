using CommonSolution;
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
    public class ClienteRepository
    {
        public ClienteRepository()
        {

        }

        public bool ExisteCliente(string documento)
        {
            bool existe = false;
            using (TrackingEntities context= new TrackingEntities())
            {
                existe = context.Cliente.AsNoTracking().Any(i => i.documento == documento);
            }
            return existe;
        }


        public void ModificarCliente(DtoCliente dto)
        {
            using (TrackingEntities context = new TrackingEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        Cliente currCliente = context.Cliente.FirstOrDefault(f => f.documento == dto.documento);

                        if (currCliente != null)
                        {
                            currCliente.nombre = dto.nombre;
                            currCliente.telefono = dto.telefono;
                            currCliente.apellido = dto.apellido;
                            currCliente.direccion = dto.direccion;

                            context.SaveChanges();
                            trann.Commit();
                        }
                    }
                    catch (Exception ex)
                    {
                        trann.Rollback();
                    }
                }
            }
        }

        public void BorrarCliente(string documento)
        {
            using (TrackingEntities context = new TrackingEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        Cliente currCliente = context.Cliente.FirstOrDefault(f => f.documento == documento);

                        if (currCliente != null)
                        {
                            context.Cliente.Remove(currCliente);
                            context.SaveChanges();
                            trann.Commit();
                        }
                    }
                    catch (Exception ex)
                    {
                        trann.Rollback();
                    }
                }
            }

        }
    }
}

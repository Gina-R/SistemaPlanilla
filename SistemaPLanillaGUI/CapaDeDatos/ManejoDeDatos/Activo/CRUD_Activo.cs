using CapaDeDatos.Conexiones.Planillas_SQLServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.ManejoDeDatos.Activo
{
    public class CRUD_Activo
    {
        private SistemaControlPlanillaEntities EntidadDeDatos;
        public CRUD_Activo()
        {
            EntidadDeDatos = new SistemaControlPlanillaEntities();
        }
        public Conexiones.Planillas_SQLServer.Activo ConsultarActivoPorID(int IndeitifadorDeactivo)
        {
            try
            {
                var ActivoaBuscar = EntidadDeDatos.Activoes.Where(x => x.ID_Activo.Equals(IndeitifadorDeactivo)).FirstOrDefault();
                if (ActivoaBuscar != null)
                    return ActivoaBuscar;
                else
                {
                    throw new Exception("No existe el activo: " + IndeitifadorDeactivo.ToString() + "Por lo tanto no puede ser modificado.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CrearActivo(Conexiones.Planillas_SQLServer.Activo ActivoAAgregar)
        {
            try
            {
                EntidadDeDatos.Activoes.Add(ActivoAAgregar);
                EntidadDeDatos.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool UpdateActivo(Conexiones.Planillas_SQLServer.Activo ActivoModificar)
        {
            try
            {
                var ActivoaMod = EntidadDeDatos.Activoes.Where(x => x.ID_Activo.Equals(ActivoModificar.ID_Activo)).FirstOrDefault();
                if (ActivoaMod != null)
                {
                    ActivoaMod.Empleadoes = ActivoModificar.Empleadoes;
                    ActivoaMod.Estado = ActivoModificar.Estado;
                    ActivoaMod.Deducciones = ActivoModificar.Deducciones;
                    ActivoaMod.Incapacidades = ActivoModificar.Incapacidades;
                    ActivoaMod.FechaUltActualizacion = System.DateTime.Now;
                    ActivoaMod.UltimoUsuarioActualizador = ActivoModificar.UltimoUsuarioActualizador;
                    EntidadDeDatos.SaveChanges();
                    return true;
                }
                else
                {
                    throw new Exception("No existe el activo: " + ActivoModificar.ID_Activo.ToString() + "Por lo tanto no puede ser modificado.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DeleteActivo(int IdentificadorActivo)
        {
            try
            {
                var ActivoaEliminar = EntidadDeDatos.Activoes.Where(x => x.ID_Activo.Equals(IdentificadorActivo)).FirstOrDefault();
                if (ActivoaEliminar != null)
                {
                    EntidadDeDatos.Activoes.Remove(ActivoaEliminar);
                    EntidadDeDatos.SaveChanges();
                    return true;
                }
                else
                {
                    throw new Exception("No existe el activo: " + IdentificadorActivo.ToString() + "Por lo tanto no puede ser modificado.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

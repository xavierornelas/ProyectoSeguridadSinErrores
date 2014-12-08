using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta.DTO
{
    public class contrasena_fecha
    {
        public int id_usuario { set; get; }
        public string fecha { set; get; }
        public contrasena_fecha() { }

        public contrasena_fecha(int id_usuario,string fecha) 
        {
            this.id_usuario = id_usuario;
            this.fecha = fecha;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Sugerencias
    {
        [Key]

        public int SugerenciaId { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }

        public Sugerencias()
        {
            SugerenciaId = 0;
            Fecha = DateTime.Now;
            Descripcion = string.Empty;
        }
    }
}

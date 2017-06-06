using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalcularPrestamos.Models
{
    public class PT
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// El tama;o maximo de digitos de la cantidad se ponen con el 32767 por que hacer un tipo de dato int al obtener un valor por encima a esta cantida hace que el programa explote
        /// </summary>
        [Required]
        public int Monto { get; set; }

        [Required]
        public double Interes { get; set; }

        [Required]
        public int Plazo { get; set; }

        /// <summary>
        /// no se le puede poner requerido porque es donde se realiza la operacion para calcula las cuotas del prestamos 
        /// </summary>
        public double Cuota { get; set; }

        /// <summary>
        /// Le indicamos la Clave Forarania a EntityFramework
        /// </summary>
        public int CIID { get; set; }
        [ForeignKey("CIID")]
        public CI CI { get; set; }

        /// <summary>
        /// Fecha de inicio de prestamo
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaInicioPrestamo { get; set; }
    }
}
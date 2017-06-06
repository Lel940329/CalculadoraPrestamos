using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CalcularPrestamos.Models
{
    public class CI
    {
            /// <summary>
            /// clave primaria
            /// </summary>
            [Key]
            public int Id { get; set; }

            /// <summary>
            /// nombre obligatorio con un limite de 100 caracteres
            /// </summary>
            [Required]
            [StringLength(100)]
            public string Nombre { get; set; }

            /// <summary>
            /// El tama;o del campo es 13 por que son las cantidad de digitos de la cedula dominicana
            /// </summary>
            [Required]
            [StringLength(13)]
            public string Cedula { get; set; }

            /// <summary>
            /// correo  obligatorio 
            /// </summary>
            [Required]
            [EmailAddress]
            [StringLength(100)]
            public string Correo { get; set; }


            /// <summary>
            /// fecha en la que se registro el cliente
            /// </summary>
            [Required]
            [DataType(DataType.Date)]
            public DateTime FechaIngreso { get; set; }

            /// <summary>
            /// Llmando a los prestamos a la tabla cliente
            /// </summary>
            public List<PT> PT { get; set; }

        
    }
}
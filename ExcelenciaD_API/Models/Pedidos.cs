using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExcelenciaD_API.Models
{
    public class Pedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        
        public int? CustomerId { get; set; }
        public DateTime FechaPedido { get; set; }

        public string Total { get; set; }
        public string Detalles { get; set; }

        

        [ForeignKey("CustomerId")]
        public Customer? Customer { get; set; }
    }
}

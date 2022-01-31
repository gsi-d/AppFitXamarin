using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AplicativoFit.Models
{
    public class Atividade
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public double? Peso { get; set; }
        public string Observacoes { get; set; }
    }
}

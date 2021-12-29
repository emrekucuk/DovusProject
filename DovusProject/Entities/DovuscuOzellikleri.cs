using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using DovusProject.DataAccess.Abstract;

namespace DovusProject.Entities
{
    public class DovuscuOzellikleri : IEntity
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public int CanDegeri { get; set; }
        public int ZırhDegeri { get; set; }
        public int DuzVurusHasari { get; set; }
        public string Yetenek1 { get; set; }
        public int Yetenek1Hasari { get; set; }
        public string Yetenek2 { get; set; }
        public int Yetenek2Hasari { get; set; }
        
    }
}

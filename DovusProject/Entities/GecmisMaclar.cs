using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DovusProject.DataAccess.Abstract;

namespace DovusProject.Entities
{
    public class GecmisMaclar : IEntity
    {
        public int Id { get; set; }
        public DovuscuOzellikleri Oyuncu1 { get; set; }
        public int? Oyuncu1Id { get; set; }
        public DovuscuOzellikleri Oyuncu2 { get; set; }
        public int? Oyuncu2Id { get; set; }
        public int KazananId { get; set; }
    }
}

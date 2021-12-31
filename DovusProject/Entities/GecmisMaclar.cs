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
        public DovuscuOzellikleri Dovuscu1 { get; set; }
        public int? Dovuscu1Id { get; set; }
        public DovuscuOzellikleri Dovuscu2 { get; set; }
        public int? Dovuscu2Id { get; set; }
        public int KazananId { get; set; }
    }
}

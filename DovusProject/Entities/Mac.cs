using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DovusProject.DataAccess.Abstract;

namespace DovusProject.Entities
{
    public class Mac : IEntity
    {
        public int Id { get; set; }
        public int Dovuscu1 { get; set; }
        public int Dovuscu2 { get; set; }
        public int VurmaSirasi { get; set; }
    }
}

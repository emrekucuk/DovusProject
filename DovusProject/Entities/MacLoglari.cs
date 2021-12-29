using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DovusProject.DataAccess.Abstract;

namespace DovusProject.Entities
{
    public class MacLoglari : IEntity
    {
        public int Id { get; set; }
        public string Olaylar { get; set; }
    }
}

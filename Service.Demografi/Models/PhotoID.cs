using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceDemografi.Models
{
    public class PhotoID
    {
        public int Id { get; set; }
        public long NIK { get; set; }
        public string Path_Photo { get; set; }

        public int DemografiId { get; set; }
        public Demografi Demografi { get; set; }
    }
}
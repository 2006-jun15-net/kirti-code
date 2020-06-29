using System;
using System.Collections.Generic;

namespace ChinookApp.DataAccess.Model
{
    public partial class Pdepartment
    {
        public Pdepartment()
        {
            PempDetails = new HashSet<PempDetails>();
            Pemployee = new HashSet<Pemployee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public virtual ICollection<PempDetails> PempDetails { get; set; }
        public virtual ICollection<Pemployee> Pemployee { get; set; }
    }
}

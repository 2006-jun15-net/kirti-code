using System;
using System.Collections.Generic;

namespace ChinookApp.DataAccess.Model
{
    public partial class Pemployee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LatName { get; set; }
        public string Ssn { get; set; }
        public int DeptId { get; set; }

        public virtual Pdepartment Dept { get; set; }
    }
}

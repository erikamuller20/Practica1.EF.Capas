namespace Practica1.EF.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EmployeeTerritories
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EmployeeTerritories()
        {
            Employees = new HashSet<EmployeeTerritories>();
        }

        [Key]
        [StringLength(20)]
        public string EmployeeID{ get; set; }

        [Key]
        [StringLength(20)]
        public string TerritoryID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeTerritories> Employees { get; set; }
    }
}

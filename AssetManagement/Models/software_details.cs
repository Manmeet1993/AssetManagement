//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AssetManagement.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class software_details
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public software_details()
        {
            this.employees = new HashSet<employee>();
        }
    
        public int software_id { get; set; }
        public string name { get; set; }
        public System.DateTime valid_from { get; set; }
        public System.DateTime valid_till { get; set; }
        public Nullable<int> cost_id { get; set; }
    
        public virtual cost_details cost_details { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<employee> employees { get; set; }
    }
}

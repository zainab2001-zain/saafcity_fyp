//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace saafcity_fyp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Complaint
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Complaint()
        {
            this.Complaint_Log = new HashSet<Complaint_Log>();
        }
    
        public int Complaint_ID { get; set; }
        public Nullable<System.DateTime> Complaint_Time { get; set; }
        public string Complaint_Loction { get; set; }
        public string Complaint_Status { get; set; }
        public byte[] Complaint_Image { get; set; }
        public byte[] Verifiction_Image { get; set; }
        public string Comments { get; set; }
        public Nullable<int> ComplainantId { get; set; }
    
        public virtual Complainnt Complainnt { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Complaint_Log> Complaint_Log { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace navettes.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Navette
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Navette()
        {
            this.Offre = new HashSet<Offre>();
        }
    
        public int id { get; set; }
        public string fromCity { get; set; }
        public string toCity { get; set; }
        public Nullable<System.TimeSpan> timeGo { get; set; }
        public Nullable<System.TimeSpan> timeWent { get; set; }
        public Nullable<int> idbus { get; set; }
    
        public virtual bus bus { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Offre> Offre { get; set; }
    }
}

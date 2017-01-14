using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace NorthwindModel.Models
{

	[DataContract]
	public class Customer
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            Orders = new HashSet<Order>();
            CustomerDemographics = new HashSet<CustomerDemographic>();
        }

        [StringLength(5)]
		[DataMember]
        public string CustomerID { get; set; }

        [Required]
        [StringLength(40)]
		[DataMember]
        public string CompanyName { get; set; }

        [StringLength(30)]
		[DataMember]
        public string ContactName { get; set; }

        [StringLength(30)]
		[DataMember]
        public string ContactTitle { get; set; }

        [StringLength(60)]
        public string Address { get; set; }

        [StringLength(15)]
        public string City { get; set; }

        [StringLength(15)]
        public string Region { get; set; }

        [StringLength(10)]
        public string PostalCode { get; set; }

        [StringLength(15)]
        public string Country { get; set; }

        [StringLength(24)]
        public string Phone { get; set; }

        [StringLength(24)]
        public string Fax { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerDemographic> CustomerDemographics { get; set; }
    }
}

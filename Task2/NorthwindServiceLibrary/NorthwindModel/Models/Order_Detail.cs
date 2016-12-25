using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace NorthwindModel.Models
{
	[Table("Order Details")]
	[DataContract]
	[KnownType(typeof(Product))]
    public class Order_Detail
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
		[DataMember]
        public int OrderID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
		[DataMember]
        public int ProductID { get; set; }

        [Column(TypeName = "money")]
		[DataMember]
        public decimal UnitPrice { get; set; }
		[DataMember]
        public short Quantity { get; set; }

		[DataMember]
        public float Discount { get; set; }

        public virtual Order Order { get; set; }
		[DataMember]
		public virtual Product Product { get; set; }
    }
}

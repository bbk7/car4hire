//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Car4Hire.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    public partial class Car
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Car()
        {
            this.Customer = new HashSet<Customer>();
        }

        public int carId { get; set; }

        [Required(ErrorMessage = "Please enter the name of the manufacturer")]
        [StringLength(100, MinimumLength = 1)]
        public string make { get; set; }

        [Required(ErrorMessage = "Please enter the name of the car")]
        [StringLength(100, MinimumLength = 1)]
        public string model { get; set; }

        [Required(ErrorMessage = "Please enter the name of the type")]
        [StringLength(100, MinimumLength = 1)]
        public string type { get; set; }

        [Required(ErrorMessage = "Please enter the name of the fuel")]
        [StringLength(100, MinimumLength = 1)]
        public string fuel { get; set; }

        [Required(ErrorMessage = "Please enter the price per day (to rent)")]
        [Range(1, 10000)]
        [DataType(DataType.Currency)]
        public double price { get; set; }


        //[Required(ErrorMessage = "Please select the image of the car)")]
        public string image { get; set; }
        
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer> Customer { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }

    }
}

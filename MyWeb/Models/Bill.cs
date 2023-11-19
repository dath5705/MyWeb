using System.ComponentModel.DataAnnotations;

namespace MyWeb.Models
{
    public class Bill
    {
        [Key]
        public int Id { get; set; } = 0;
        public int BillNumber { get; set; } = 0;
        public DateTime Date {  get; set; }  = DateTime.Now;
        public int BillOwner { get; set; } = 0;

    }
}

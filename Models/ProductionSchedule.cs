using System.ComponentModel.DataAnnotations;

namespace ChocolateFactoryApi.Models
{
    public class ProductionSchedule
    {
        [Key]
        public int ScheduleId { get; set; }

        public int ProductId {  get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Shift {  get; set; }

        public int SupervisorId {  get; set; }

        public string Status { get; set; }


    }
}

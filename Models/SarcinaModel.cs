using System.ComponentModel.DataAnnotations;

namespace ToDo.Models
{
    public class SarcinaModel
    {
        [Key]
        public int Id { get; set; }
        public string Nume { get; set; }
        public DateTime Limita { get; set; }
        public SarcinaStatus Status { get; set; }
    }
}
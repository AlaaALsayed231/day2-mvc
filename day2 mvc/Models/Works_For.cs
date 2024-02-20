using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace day2_mvc.Models
{
    [PrimaryKey("ESSN", "Pno")]
    public class Works_For

    {
        [ForeignKey("employee")]
        public int? ESSN { get; set; }
        [ForeignKey("project")]
        public int? Pno { get; set; }
        public int Hours { get; set; }
        public Employee employee { get; set; }
        public Project project { get; set; }
    }
}


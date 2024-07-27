using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTaskManagementService.DataAcessLayer.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string FileKeyName { get; set; }
        public DateTime CreatedTime { get; set; }
        public int TaskID { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using PJATK.Models;

namespace PJATK.DataModels
{
    public class GradesDataModel
    {
        public string Name { get; set; }
        public ICollection<Oceny> Grades { get; set; }
    }
}

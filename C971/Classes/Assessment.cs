﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace C971.Classes
{
    [Table("Assessments")]
    public class Assessment
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string AssessmentName { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string AssessmentType { get; set; }
        public int Course { get; set; }
        public int Notifications { get; set; }

    }
}

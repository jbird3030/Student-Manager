using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentManager.Models
{
    public partial class StudentHistory
    {
        public int StudentHistoryId { get; set; }
        public int? StudentId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zip { get; set; }
        public string? ActionTaken { get; set; }
        public string? Username { get; set; }
        public DateTime? Today { get; set; }
        public string Slug => FirstName?.Replace(' ', '-').ToLower()
+ '-' + LastName?.Replace(' ', '-').ToLower();

    }
}

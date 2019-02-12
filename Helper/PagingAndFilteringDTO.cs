using System;

namespace exam.Helper
{
    public class PagingAndFilteringDTO
    {
        public string FilterBy { get; set; }

        public int PageNumber { get; set; }

        public int DeviceNumberPerPage { get; set; }

        public string PropertyValue { get; set; }
        public int? GreatherThan { get; set; }
        public int? GreatherThanOrEqual { get; set; }
        public int? LessThan { get; set; }
        public int? LessThanOrEqual { get; set; }

       public DateTime AfterDate { get; set; }
        public DateTime AfterOrEqualDate { get; set; }
        public DateTime BeforeDate { get; set; }
        public DateTime BeforeOrEqualDate { get; set; }

    }
}
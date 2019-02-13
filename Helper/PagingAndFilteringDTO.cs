using System;

namespace exam.Helper
{
    public class PagingAndFilteringDTO
    {
        public string FilterBy { get; set; }

        public int PageNumber { get; set; }

        public int DeviceNumberPerPage { get; set; }

        public string PropertyValue { get; set; }
        public decimal? GreatherThan { get; set; }
        public decimal? GreatherThanOrEqual { get; set; }
        public decimal? LessThan { get; set; }
        public decimal? LessThanOrEqual { get; set; }

        public DateTime? AfterDate { get; set; }
        public DateTime? AfterOrEqualDate { get; set; }
        public DateTime? BeforeDate { get; set; }
        public DateTime? BeforeOrEqualDate { get; set; }

    }
}
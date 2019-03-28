using System.Collections.Generic;

namespace cinex.Models
{
    public class UpcomingResponseModel
    {
        public List<UpcomingModel> Results { get; set; }
        public int Page { get; set; }
        public int TotalResults { get; set; }
        public UpcomingDates Dates { get; set; }
        public int TotalPages { get; set; }
    }
}

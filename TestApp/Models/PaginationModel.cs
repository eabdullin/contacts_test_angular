using System.Collections.Generic;

namespace TestApp.Models
{
    public class PaginationModel<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalCount { get; set; }
    }
}
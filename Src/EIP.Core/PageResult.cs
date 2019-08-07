using System.Collections.Generic;

namespace EIP.Core
{
    public class PageResult<T> where T : class
    {
        public int Draw { get; set; }

        public int RecordsTotal { get; set; }

        public int RecordsFiltered => RecordsTotal;

        public IEnumerable<T> Data { get; set; }
    }
}
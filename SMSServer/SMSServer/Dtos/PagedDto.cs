using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMSServer.Dtos
{
    public class PagedDto<T>
    {
        public int Total { get; set; }
        public int Current { get; set; }
        public T Data { get; set; }

        public PagedDto(int total, int current, T data)
        {
            Total = total;
            Current = current;
            Data = data;
        }
    }
}

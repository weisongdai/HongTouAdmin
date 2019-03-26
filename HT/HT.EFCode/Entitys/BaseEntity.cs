using System;
using System.Collections.Generic;
using System.Text;

namespace HT.EFCode.Entitys
{
    public class BaseEntity
    {
        public long Id { get; set; } 
        public DateTime CareatTime { get; set; } = DateTime.Now;
    }
}

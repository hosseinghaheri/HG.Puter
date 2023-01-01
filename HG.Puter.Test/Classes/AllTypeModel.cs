using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HG.Puter.Test.Classes
{
    public class AllTypeModel
    {
        public string String { get; set; }
        public int Int { get; set; }
        public long Long { get; set; }
        public double Double { get; set; }
        public short Short { get; set; }
        public float Float { get; set; }
        public ushort Ushort { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime? DateTimeNA { get; set; }
        public List<int> ListInt { get; set; }
    }
    public class StringModel
    {
        public string String { get; set; }
        public string Int { get; set; }
        public string Long { get; set; }
        public string Double { get; set; }
        public string Short { get; set; }
        public string Float { get; set; }
        public string Ushort { get; set; }
        public string DateTime { get; set; }
        public string? DateTimeNA { get; set; }
        public List<int> ListInt { get; set; }
    }
}

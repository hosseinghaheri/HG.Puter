using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HG.Puter
{
    public interface IPuterContext
    {
        ICollection<dynamic> TypeConverters { get; set; }
        void CreateMap<TSource, TResult>(Func<dynamic, dynamic> Converter);
    }
    public class PuterContext : IPuterContext
    {
        public ICollection<dynamic> TypeConverters { get; set; } = new List<dynamic>();
        public void CreateMap<TSource, TResult>(Func<dynamic, dynamic> Converter)
        {
            TypeConverters.Add(new TypeConverter(typeof(TSource), typeof(TResult), Converter));
        }
    }
    public class TypeConverter
    {

        public TypeConverter(Type TSource, Type TResult, Func<dynamic, dynamic> Converter)
        {
            this.SourceType = (TSource);
            this.ResultType = (TResult);
            this.Converter = Converter;
        }
        public Type SourceType { get; set; }
        public Type ResultType { get; set; }
        public Func<dynamic, dynamic> Converter { get; set; }

    }
}

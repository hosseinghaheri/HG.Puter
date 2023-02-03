using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

//namespace HG.Puter
//{
//    public interface IPuterContext
//    {
//        ICollection<dynamic> TypeConverters { get; set; }
//        void CreateMap<TSource, TResult>(Func<dynamic, dynamic> Converter);
//    }
//    public class PuterContext : IPuterContext
//    {
//        public ICollection<dynamic> TypeConverters { get; set; } = new List<dynamic>();
//        public void CreateMap<TSource, TResult>(Func<dynamic, dynamic> Converter)
//        {
//            TypeConverters.Add(new TypeConverter(typeof(TSource), typeof(TResult), Converter));
//        }
//    }
//    public class TypeConverter
//    {

//        public TypeConverter(Type TSource, Type TResult, Func<dynamic, dynamic> Converter)
//        {
//            this.SourceType = (TSource);
//            this.ResultType = (TResult);
//            this.Converter = Converter;
//        }
//        public Type SourceType { get; set; }
//        public Type ResultType { get; set; }
//        public Func<dynamic, dynamic> Converter { get; set; }

//    }
//}

namespace HG.Puter
{
    public interface IPuterContext
    {
        ICollection<TypeConverter> TypeConverters { get; set; }
        void CreateMap<TSource, TResult>(Func<TSource, TResult> Converter);
    }
    public class PuterContext : IPuterContext
    {
        public ICollection<TypeConverter> TypeConverters { get; set; } = new List<TypeConverter>();
        public void CreateMap<TSource, TResult>(Func<TSource, TResult>  Converter)
        {
            TypeConverters.Add(new TypeConverter(typeof(TSource), typeof(TResult), FuncToExpression(Converter)));
        }
        private Expression<Func<TInput, TOutput>> FuncToExpression<TInput, TOutput>(Func<TInput, TOutput> f) => x => f(x);

    }
    public class TypeConverter
    {

        public TypeConverter(Type TSource, Type TResult, LambdaExpression Converter)
        {
            this.SourceType = (TSource);
            this.ResultType = (TResult);
            this.Converter = Converter;
        }
        public Type SourceType { get; set; }
        public Type ResultType { get; set; }
        public LambdaExpression Converter { get; set; }

    }
}

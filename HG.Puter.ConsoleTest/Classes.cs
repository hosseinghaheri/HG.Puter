//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text;
//using System.Threading.Tasks;

//namespace HG.Puter.ConsoleTest
//{
//    public delegate TResult ConverterFunc<in TSource, out TResult>(TSource arg);
//    public static class ObejctExtensions
//    {
//        public static void Put<T>(this object source, T date)
//        {
//            var dataPro = typeof(T).GetProperties().Select(p => p.Name).ToList();
//            source.GetType().GetProperties().ToList().ForEach(p =>
//            {
//                if (dataPro.Any(x => x == p.Name))
//                {
//                    var val = typeof(T).GetProperty(p.Name).GetValue(date, null);
//                    if (val != null)
//                    {
//                        var t1Generic = Nullable.GetUnderlyingType(p.PropertyType);
//                        var t2 = typeof(T).GetProperty(p.Name).PropertyType;
//                        var t2Generic = Nullable.GetUnderlyingType(t2);

//                        if (t1Generic == t2 || (t1Generic != null && t1Generic == t2Generic))
//                        {
//                            p.SetValue(source, val, null);
//                        }
//                        else if (p.PropertyType != typeof(T).GetProperty(p.Name).GetType())
//                        {
//                            p.SetValue(source, Convert.ChangeType(val, p.PropertyType), null);
//                        }
//                    }
//                    else p.SetValue(source, val, null);
//                }
//            });
//        }
//        public static void Put<T>(this IPuterContext context, object source, T date)
//        {
//            var dataPro = typeof(T).GetProperties().Select(p => p.Name).ToList();
//            source.GetType().GetProperties().ToList().ForEach(p =>
//            {
//                if (dataPro.Any(x => x == p.Name))
//                {
//                    var val = typeof(T).GetProperty(p.Name).GetValue(date, null);
//                    if (val != null)
//                    {
//                        var t1Generic = Nullable.GetUnderlyingType(p.PropertyType);
//                        var t2 = typeof(T).GetProperty(p.Name).PropertyType;
//                        var t2Generic = Nullable.GetUnderlyingType(t2);

//                        if (t1Generic == t2 || (t1Generic != null && t1Generic == t2Generic))
//                        {
//                            p.SetValue(source, val, null);
//                        }
//                        else if (p.PropertyType != typeof(T).GetProperty(p.Name).GetType())
//                        {
//                            dynamic converter = null;
//                            if (context != null)
//                            {
//                                converter =
//                                    context.TypeConverters.SingleOrDefault(t =>
//                                        {
//                                            var rt = val.GetType();
//                                            return
//                                                t.SourceType.FullName == rt.FullName
//                                                && t.ResultType.FullName == p.PropertyType.FullName;
//                                        }
//                                    );
//                            }
//                            if (converter != null)
//                            {
//                                var newval = converter.Converter(val);
//                                p.SetValue(source, newval, null);
//                            }
//                            else { p.SetValue(source, Convert.ChangeType(val, p.PropertyType), null); }
//                        }
//                    }
//                    else p.SetValue(source, val, null);
//                }
//            });
//        }
//    }
//    public interface IPuterContext
//    {
//        //List<> TypeConverters { get; set; }
//        //ICollection<dynamic> TypeConverters { get; set; }
//        //void CreateMap<TSource, TResult>(ConverterFunc<dynamic, dynamic> Converter);
//    }
//    public class PuterContext : IPuterContext
//    {
//        public List<TypeConverter> TypeConverters { get; set; } = new List<TypeConverter>();
//        //public void CreateMap<TSource, TResult>(Action<dynamic, dynamic> Converter)
//        //{
//        //    TypeConverters.Add(new TypeConverter(typeof(TSource), typeof(TResult), Converter));
//        //}
//        public void CreateMap<TSource, TResult>(IPuterTypeConverter<TSource, TResult> Converter)
//        {
//            TypeConverters.Add(new TypeConverter(typeof(TSource), typeof(TResult), Converter));
//        }

//    }
//    //public class TypeConverter<TSource, TResult>
//    //{
//    //    public TypeConverter(Action<TSource, TResult> Converter)
//    //    {
//    //        this.SourceType = typeof(TSource);
//    //        this.ResultType = typeof(TResult);
//    //        this.Converter = Converter;
//    //    }
//    //    public Type SourceType { get; set; }
//    //    public Type ResultType { get; set; }
//    //    public Action<TSource, TResult> Converter { get; set; }

//    //    //public delegate TResult Converter<in TSource, out TResult>(TSource arg);
//    //}
//    public class TypeConverter
//    {

//        public TypeConverter(Type TSource, Type TResult, LambdaExpression Converter)
//        {
//            this.SourceType = (TSource);
//            this.ResultType = (TResult);
//            this.Converter = Converter;
//        }
//        public Type SourceType { get; set; }
//        public Type ResultType { get; set; }
//        public LambdaExpression Converter { get; set; }

//    }



//    public interface IPuterTypeConverter<TSource, TResult>
//    {
//        TResult Convert(TSource source, TResult destination, IPuterContext context);
//    }
    


//    public class A
//    {
//        public DateTime Date { get; set; }
//    }
//    public class B
//    {
//        public string Date { get; set; }
//    }
//}

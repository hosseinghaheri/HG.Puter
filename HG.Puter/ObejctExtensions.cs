namespace HG.Puter
{
    public static class ObejctExtensions
    {
        public static void Put<T>(this object source, T data)
        {
            var dataPro = typeof(T).GetProperties().Select(p => p.Name).ToList();
            source.GetType().GetProperties().ToList().ForEach(p =>
            {
                if (dataPro.Any(x => x == p.Name))
                {
                    var val = typeof(T).GetProperty(p.Name).GetValue(data, null);
                    if (val != null)
                    {
                        var t1 = p.PropertyType;
                        var t1Generic = Nullable.GetUnderlyingType(p.PropertyType);
                        var t2 = typeof(T).GetProperty(p.Name).PropertyType;
                        var t2Generic = Nullable.GetUnderlyingType(t2);

                        if (t2Generic == null) { t2Generic = t2; }
                        if (t1Generic == null) { t1Generic = t1; }

                        if (t1Generic == t2 || (t1Generic != null && t1Generic == t2Generic))
                        {
                            p.SetValue(source, val, null);
                        }
                        else if (p.PropertyType != typeof(T).GetProperty(p.Name).GetType())
                        {
                            p.SetValue(source, Convert.ChangeType(val, t1Generic), null);
                        }
                    }
                    else p.SetValue(source, val, null);
                }
            });
        }
        public static void Put<T>(this IPuterContext context, object source, T data)
        {
            var dataPro = typeof(T).GetProperties().Select(p => p.Name).ToList();
            source.GetType().GetProperties().ToList().ForEach(p =>
            {
                if (dataPro.Any(x => x == p.Name))
                {
                    var val = typeof(T).GetProperty(p.Name).GetValue(data, null);
                    var t1 = p.PropertyType;
                    var t1Generic = Nullable.GetUnderlyingType(p.PropertyType);
                    var t2 = typeof(T).GetProperty(p.Name).PropertyType;
                    var t2Generic = Nullable.GetUnderlyingType(t2);

                    if (t2Generic == null) { t2Generic = t2; }
                    if (t1Generic == null) { t1Generic = t1; }

                    if (t1Generic == t2 || (t1Generic != null && t1Generic == t2Generic))
                    {
                        p.SetValue(source, val, null);
                    }
                    else if (p.PropertyType != typeof(T).GetProperty(p.Name).GetType())
                    {
                        TypeConverter converter = null;
                        if (context != null)
                        {
                            converter =
                                context.TypeConverters.SingleOrDefault(t =>
                                {
                                    return
                                        t.SourceType.FullName == t2Generic.FullName//rt.FullName
                                        && t.ResultType.FullName == t1.FullName;// p.PropertyType.FullName;
                                }
                            );
                            if (converter == null)
                            {
                                converter =
                                context.TypeConverters.SingleOrDefault(t =>
                                {
                                    return
                                        t.SourceType.FullName == t2Generic.FullName//rt.FullName
                                        && t.ResultType.FullName == t1Generic.FullName;// p.PropertyType.FullName;
                                }
                            );
                            }
                        }
                        if (converter != null)
                        {
                            p.SetValue(source, converter.Converter.Compile().DynamicInvoke(val), null);
                        }
                        else if (val == null)
                        {
                            p.SetValue(source, val, null);
                        }
                        else { p.SetValue(source, Convert.ChangeType(val, t1Generic), null); }
                    }
                }
            });
        }
    }
}

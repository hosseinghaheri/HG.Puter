namespace HG.Puter
{
    public static class ObejctExtensions
    {
        public static void Put<T>(this object source, T date)
        {
            var dataPro = typeof(T).GetProperties().Select(p => p.Name).ToList();
            source.GetType().GetProperties().ToList().ForEach(p =>
            {
                if (dataPro.Any(x => x == p.Name))
                {
                    var val = typeof(T).GetProperty(p.Name).GetValue(date, null);
                    if (val != null)
                    {
                        var t1 = Nullable.GetUnderlyingType(p.PropertyType);
                        var ww = typeof(T).GetProperty(p.Name).PropertyType;
                        var t2 = Nullable.GetUnderlyingType(ww);

                        if (t1 == ww || (t1 != null && t1 == t2))
                        {
                            p.SetValue(source, val, null);
                        }
                        else if (p.PropertyType != typeof(T).GetProperty(p.Name).GetType())
                        {
                            p.SetValue(source, Convert.ChangeType(val, p.PropertyType), null);
                        }
                    }
                    else p.SetValue(source, val, null);
                }
            });
        }
    }
}

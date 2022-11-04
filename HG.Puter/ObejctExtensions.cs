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
                        var t1Generic = Nullable.GetUnderlyingType(p.PropertyType);
                        var t2 = typeof(T).GetProperty(p.Name).PropertyType;
                        var t2Generic = Nullable.GetUnderlyingType(t2);

                        if (t1Generic == t2 || (t1Generic != null && t1Generic == t2Generic))
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

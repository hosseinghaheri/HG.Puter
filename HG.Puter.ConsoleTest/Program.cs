

using HG.Puter.ConsoleTest;

PuterContext puter = new PuterContext();
puter.CreateMap<string, DateTime>(s =>
{
    return s == null ? default(DateTime) : DateTime.Parse(s);
});
puter.CreateMap<string, DateTime?>(s =>
{
    return s == null ? null : DateTime.Parse(s);
});
puter.CreateMap<DateTime, string>(s =>
{
    return "dddddddddddddddddddddd";
});

A a_dat = new A() { Date = DateTime.Now };
//B b_str = new B() { Date = ("2022-01-01 01:01:01") };
B b_str = new B() { Date = null };
C c_datNa = new C() { Date = DateTime.Now };

//puter.Put(b_str, c_datNa);
puter.Put(c_datNa, b_str);
puter.Put(a_dat, b_str);
//puter.Put(b_str, a_dat);

var ss = "sss";


//var a=Convert.ChangeType("2022-02-02 21:12:55", typeof(DateTime));

//var e = "end";
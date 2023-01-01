using Xunit;
using HG.Puter.Test.Classes;
//using HG.Puter.Test;
using Tynamix.ObjectFiller;
using System;

namespace HG.Puter.Test
{
    public class GeneralTest
    {
        public GeneralTest()
        {

        }
       
        [Fact]
        public void All_Type_To_String()
        {
            var AllTypeModel = new Filler<AllTypeModel>().Create();
            var StringModel = new Filler<StringModel>().Create(); ;
            StringModel.Put(AllTypeModel);

            Assert.Equal(AllTypeModel.String, StringModel.String);
            Assert.Equal(AllTypeModel.Int.ToString(), StringModel.Int);
            Assert.Equal(AllTypeModel.Long.ToString(), StringModel.Long);
            Assert.Equal(AllTypeModel.Double.ToString(), StringModel.Double);
            Assert.Equal(AllTypeModel.Short.ToString(), StringModel.Short);
            Assert.Equal(AllTypeModel.Float.ToString(), StringModel.Float);
            Assert.Equal(AllTypeModel.Ushort.ToString(), StringModel.Ushort);
            Assert.Equal(AllTypeModel.ListInt, StringModel.ListInt);
        }
        [Fact]
        public void String_To_All_Type()
        {
            var _allTypeModel = new Filler<AllTypeModel>().Create();
            var StringModel = new StringModel();
            StringModel.Put(_allTypeModel);

            var AllTypeModel = new AllTypeModel();
            AllTypeModel.Put(StringModel);

            Assert.Equal(AllTypeModel.String, StringModel.String);
            Assert.Equal(AllTypeModel.Int.ToString(), StringModel.Int);
            Assert.Equal(AllTypeModel.Long.ToString(), StringModel.Long);
            Assert.Equal(AllTypeModel.Double.ToString(), StringModel.Double);
            Assert.Equal(AllTypeModel.Short.ToString(), StringModel.Short);
            Assert.Equal(AllTypeModel.Float.ToString(), StringModel.Float);
            Assert.Equal(AllTypeModel.Ushort.ToString(), StringModel.Ushort);
        }

        [Fact]
        public void Type_Converter_Str_To_Date_Test()
        {
            var AllTypeModel = new Filler<AllTypeModel>().Create();
            var StringModel = new Filler<StringModel>().Create();

            PuterContext puter = new PuterContext();

            puter.CreateMap<string, DateTime>(s => DateTime.Parse(s));
            puter.CreateMap<string, int>(s => default(int));
            puter.CreateMap<string, long>(s => default(long));
            puter.CreateMap<string, float>(s => default(float));
            puter.CreateMap<string, double>(s => default(double));
            puter.CreateMap<string, short>(s => default(short));
            puter.CreateMap<string, ushort>(s => default(ushort));
            puter.CreateMap<string, byte>(s => default(byte));

            AllTypeModel.DateTime = DateTime.Now;
            StringModel.DateTime = "2007-01-02 03:04:05";

            puter.Put(AllTypeModel, StringModel);
            Assert.Equal(AllTypeModel.DateTime.Year, 2007);
            Assert.Equal(AllTypeModel.DateTime.Month, 01);
            Assert.Equal(AllTypeModel.DateTime.Day, 02);
            Assert.Equal(AllTypeModel.DateTime.Hour, 03);
            Assert.Equal(AllTypeModel.DateTime.Minute, 04);
            Assert.Equal(AllTypeModel.DateTime.Second, 05);
        }
        [Fact]
        public void Type_Converter_Date_To_Str_Test()
        {
            var AllTypeModel = new Filler<AllTypeModel>().Create();
            var StringModel = new Filler<StringModel>().Create();

            PuterContext puter = new PuterContext();
            puter.CreateMap<DateTime, string>(s =>
            {
                return "dddddd";
            });

            AllTypeModel.DateTime = DateTime.Now;
            StringModel.DateTime = "2007-01-02 03:04:05";

            puter.Put(StringModel, AllTypeModel);
            Assert.Equal(StringModel.DateTime, "dddddd");
        }

    }

   
}
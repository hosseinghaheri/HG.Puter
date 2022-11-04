using Xunit;
using HG.Puter.Test.Classes;
using HG.Puter.Test;
using Tynamix.ObjectFiller;

namespace HG.Puter.Test
{
    public class GeneralTest
    {
        public GeneralTest()
        {

        }
        [Fact]
        public void AllTypeToString()
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
        }
        [Fact]
        public void StringToAllType()
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
    }

   
}
namespace AuthTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            string result = MauiApp2.Services.AccountInfo.testfunction();
            Assert.IsType<string>(result);
        }
    }
}
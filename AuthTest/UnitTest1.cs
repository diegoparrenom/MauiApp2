namespace AuthTest
{
    public class UnitTest1
    {
        string resultToken;

        MauiApp2.Services.Login LoginTest;
        MauiApp2.Services.AccountInfo AccountTest;

        public UnitTest1()
        {
            LoginTest = new MauiApp2.Services.Login();
            AccountTest = new MauiApp2.Services.AccountInfo();
            resultToken = "";
        }

        [Fact]
        public async Task Test1_Login()
        {
            resultToken = await LoginTest.GetLogin();
            Assert.IsType<string>(resultToken);
        }
        [Fact]
        public async Task Test2_TokenLength()
        {
            resultToken = await LoginTest.GetLogin();
            Assert.InRange(resultToken.Length, 5, 200);
        }
        [Fact]
        public async Task TestGenresNumber()
        {
            resultToken = await LoginTest.GetLogin();
          
            var genres_list = await AccountTest.GetGenres(resultToken);
            Assert.InRange(genres_list.Count, 5, 200);
        }
    }
}
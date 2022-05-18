using Xunit;

namespace CE.Tests.DataPersistence
{
    public class DataPersistenceTests
    {
        #region Readonly Fields

        MockApplicationContext dbContext;

        #endregion

        public DataPersistenceTests()
        {
            dbContext = new MockApplicationContext();
        }

        [Fact]
        public void Should_NotReturn_NullList()
        {

            var results = dbContext.GetAll();

            Assert.NotNull(results);
        }
    }
}

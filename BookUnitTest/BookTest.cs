using ApiBooks.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;


namespace BookUnitTest
{
    [TestClass]
    public class BookTest
    {
        Mock<IBook> bookServices = new Mock<IBook>();

        [TestMethod]
        public void GetBooks_FetchBook_RetunrsNotNull ()
        {
           var response = bookServices.Setup(a => a.GetBooks());

            Assert.IsNotNull(response);
        }


        [TestMethod]
        public void GetBookByd_IdParameter_RetunrsABook()
        {
            int id = 8;

            var response = bookServices.Setup(a => a.GetBookById(id));

            Assert.IsNotNull(response);
        }
    }
}

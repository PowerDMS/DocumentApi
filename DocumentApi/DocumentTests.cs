using NUnit.Framework;

namespace DocumentApi
{
    [TestFixture]
    public class DocumentTests
    {
        [Test]
        public void ShouldNotUploadDocumentsThatAlreadyExist()
        {
            Assert.Fail();
        }

        [Test]
        public void ShouldUploadDocumentsThatDoNotAlreadyExist()
        {
            Assert.Fail();
        }
    }
}
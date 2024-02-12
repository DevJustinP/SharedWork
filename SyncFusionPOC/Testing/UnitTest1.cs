using IAS.Handlers.Handlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Testing
{
    [TestClass]
    public class UnitTest1
    {
        SyncFusion _SyncFusion = new SyncFusion();

        [TestInitialize]
        public void TestInitialize()
        {
            if (!Directory.Exists(Path.Combine(AppContext.BaseDirectory, nameof(UnitTest1)))) 
            {
                Directory.CreateDirectory(Path.Combine(AppContext.BaseDirectory, nameof(UnitTest1)));
            }
            if (!Directory.Exists(Path.Combine(AppContext.BaseDirectory, nameof(UnitTest1), nameof(PDF_Test))))
            {
                Directory.CreateDirectory(Path.Combine(AppContext.BaseDirectory, nameof(UnitTest1), nameof(PDF_Test)));
            }
            else
            {
                foreach (var file in Directory.GetFiles(Path.Combine(AppContext.BaseDirectory, nameof(UnitTest1), nameof(PDF_Test))))
                {
                    File.Delete(file);
                }
            }
        }

        [TestMethod]
        public void PDF_Test()
        {
            try
            {
                _SyncFusion.GeneratePDF("<h1>Hello World</h1>", Path.Combine(AppContext.BaseDirectory, nameof(UnitTest1), nameof(PDF_Test), "PDF_Test.pdf"));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            Assert.IsTrue(File.Exists(Path.Combine(AppContext.BaseDirectory, nameof(UnitTest1), nameof(PDF_Test), "PDF_Test.pdf")));
        }
    }
}

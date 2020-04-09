using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using WpfApp;

namespace KABSUApp_UnitTest
{
    [TestFixture]
    public class UnitTests
    {

        [SetUp]
        public void setup()
        {

        }

        [TearDown]
        public void tearDown()
        {

        }

        [Test]
        public void sampleTest()
        {

        }


        [Test]
        public void test_searchValidOwner()
        {
            SearchTerm search = new SearchTerm("0658", "54XB445", "1 Oak", "Test", "Mouse Mick", "Beloit", "KS"); //actual entry
            SearchResults results = new SearchResults();
            List<SearchResult> data = results.retrieveData(search);
            Assert.AreEqual(2, data.Count);
        }
    }
}

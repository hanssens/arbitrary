using System.Reflection;
using Arbitrary;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbitrary.Tests.Extensions
{
    [TestFixture]
    public class IEnumerableExtensionsTests
    {
        [Test]
        public void PickOne_Should_Fetch_Single_Object()
        {
            // arrange
            var collection = new [] { "Harry", "Hermoine", "Albus", "Sneep" };

            // act
            var target = collection.PickOne();

            // assert
            target.Should().NotBeNullOrEmpty();
        }

        [Test]
        public void PickOne_Should_Fetch_Different_Objects_When_Called_Twice()
        {
            // arrange
            var collection = new List<int>();
            for (int i = 0; i < 9999; i++)
                collection.Add(i);

            // act
            var first = collection.PickOne();
            var second = collection.PickOne();

            // assert - ok, it is theoretically possible that the
			// same object will be returned twice. 
            first.Should().NotBe(second);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PickOne_Should_Throw_Exception_If_Collection_IsNull()
        {
            // arrange
            List<string> nullCollection = null;

            // act
            var target = nullCollection.PickOne();

            Assert.Fail("ArgumentNullException was expected");
        }

        [Test]
        public void PickSeveral_Should_Return_One_Instance_If_Requested()
        {
            // arrange
            var requestedAmount = 1;
            var collection = new[] { "Harry", "Hermoine", "Albus", "Sneep" };

            // act
            var target = collection.PickSeveral(requestedAmount);

            // assert
            target.Should().NotBeNullOrEmpty();
            target.Count().Should().Be(requestedAmount);
        }

        [Test]
        public void PickSeveral_Should_Return_Exact_Amount_As_Requested()
        {
            // arrange
            var requestedAmount = 3;
            var collection = new[] { "Harry", "Hermoine", "Albus", "Sneep" };

            // act
            var target = collection.PickSeveral(requestedAmount);

            // assert
            target.Should().NotBeNullOrEmpty();
            target.Count().Should().Be(requestedAmount);
        }
    }
}

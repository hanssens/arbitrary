using Arbitrary.Collections;
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
    public class CollectionExtensionsTests
    {
        [Test]
        public void CollectionOf_Should_Return_Requested_Collection()
        {
            // arrange + act
            var target = Arbitrary.CollectionOf<Name>();

            // assert
            target.Should().NotBeNull();
            target.Count().Should().BeGreaterOrEqualTo(1);
        }

        [Test]
        public void CollectionOf_Should_Be_Chainable_With_PickOne()
        {
            // arrange
            var collection = Arbitrary.CollectionOf<Name>();

            // act
            var target = collection.PickOne();

            // assert
            target.Should().NotBeNull();
        }

        [Test]
        public void CollectionOf_Should_Be_Chainable_With_PickSeveral()
        {
            // arrange
            var expectedAmount = 2;
            var collection = Arbitrary.CollectionOf<Name>();

            // act
            var target = collection.PickSeveral(expectedAmount);

            // assert
            target.Should().NotBeNull();
            target.Count().Should().Be(expectedAmount);
        }

        [Test]
        public void ListAllCollections_Should_Return_All_Types_From_Current_Assembly()
        {
            // arrange + act
            var target = Arbitrary.ListAllCollections();

            // assert
            target.Should().NotBeNull();
            target.Count().Should().BeGreaterOrEqualTo(1);
        }
    }
}

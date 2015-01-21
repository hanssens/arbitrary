using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arbitrary.Collections;
using FluentAssertions;
using NUnit.Framework;

namespace Arbitrary.Tests.Collections
{
    [TestFixture]
    public class CollectionFactoryTests
    {
        [Test]
        public void CollectionFactory_Should_Be_Initializable()
        {
            // arrange + act
            var target = new CollectionFactory();

            // assert
            target.Should().NotBeNull();
        }

        [Test]
        public void CollectionFactory_List_Should_Return_Collection()
        {
            // arrange
            var factory = new CollectionFactory();

            // act
            var target = factory.List<Name>();

            // assert
            target.Should().NotBeNull();
            target.Count().Should().BeGreaterOrEqualTo(1);
        }
    }
}

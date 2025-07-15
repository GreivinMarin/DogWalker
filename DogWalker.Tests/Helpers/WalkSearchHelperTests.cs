using System;
using System.Collections.Generic;
using DogWalker.Core.Entities;
using DogWalker.Core.Helpers;
using Xunit;

namespace DogWalker.Tests.Helpers
{
    public class WalkSearchHelperTests
    {
        [Fact]
        public void SortList_ShouldSortByDateDescending()
        {
            var sample = new List<Walk>
            {
                new Walk { Date = new DateTime(2025, 1, 1).ToString("yyyy-MM-dd") },
                new Walk { Date = new DateTime(2025, 5, 1).ToString("yyyy-MM-dd") },
                new Walk { Date = new DateTime(2025, 3, 1).ToString("yyyy-MM-dd") }
            };

            var sorted = WalkSearchHelper.SortList(sample, "Date", false);

            Assert.Equal(new DateTime(2025, 5, 1).ToString("yyyy-MM-dd"), sorted[0].Date);
            Assert.Equal(new DateTime(2025, 3, 1).ToString("yyyy-MM-dd"), sorted[1].Date);
            Assert.Equal(new DateTime(2025, 1, 1).ToString("yyyy-MM-dd"), sorted[2].Date);
        }

        [Fact]
        public void SortList_ShouldSortByClientNameAscending()
        {
            var sample = new List<Walk>
            {
                new Walk { ClientName = "Zelda" },
                new Walk { ClientName = "Anna" },
                new Walk { ClientName = "Mario" }
            };

            var sorted = WalkSearchHelper.SortList(sample, "ClientName", true);

            Assert.Equal("Anna", sorted[0].ClientName);
            Assert.Equal("Mario", sorted[1].ClientName);
            Assert.Equal("Zelda", sorted[2].ClientName);
        }

        [Fact]
        public void SortList_WithInvalidProperty_ShouldThrowException()
        {
            var sample = new List<Walk>
            {
                new Walk { ClientName = "Test" }
            };

            Assert.Throws<ArgumentException>(() =>
                WalkSearchHelper.SortList(sample, "InvalidProp", true));
        }

        [Fact]
        public void SortList_WithNullSource_ShouldReturnEmptyList()
        {
            List<Walk> sample = null;

            var sorted = WalkSearchHelper.SortList(sample, "Date", true);

            Assert.NotNull(sorted);
            Assert.Empty(sorted);
        }
    }
}

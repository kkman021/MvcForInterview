using System;
using System.Linq;
using AutoFixture;
using FluentAssertions;
using Xunit;

namespace EIP.Core.Extensions.Tests
{
    public class QueryableExtensionTests
    {
        private class FakeEmp
        {
            public int Id { get; set; }

            public string EmpNo { get; set; }
        }

        [Fact]
        public void ToPagedListTest_WhenTotalDataCount11_WhenPageSize10_WhenSkip10_ShouldReturn1Record()
        {
            //arrange
            var fixture = new Fixture();
            var data = fixture.CreateMany<FakeEmp>(11).OrderBy(x => x.Id).AsQueryable();
            int draw = 1, skipCount = 10, pageSize = 10;
            var expect = data.Last();
            var expectCount = 1;
            var expectTotalRecord = 11;

            //act
            var result = data.OrderBy(x => x.Id).ToPagedList(draw, skipCount, pageSize);

            //assert
            result.RecordsTotal.Should().Be(expectTotalRecord);
            result.Data.Count().Should().Be(expectCount);
            result.Data.FirstOrDefault().Should().Be(expect);
        }

        [Fact]
        public void Where_WhenConditionIsMing_ShouldGetOneRecord()
        {
            //arrange
            var fixture = new Fixture();
            var data = fixture.CreateMany<FakeEmp>(3).ToList();
            var expect = new FakeEmp {Id = 1, EmpNo = "Ming"};
            data.Add(expect);
            var keyword = expect.EmpNo;
            var expectCount = 1;

            //act
            var result = data
                .AsQueryable()
                .Where(keyword, x => x.EmpNo.Equals(keyword, StringComparison.OrdinalIgnoreCase));

            //Assert
            result.Count().Should().Be(expectCount);
            result.FirstOrDefault().Should().Be(expect);
        }

        [Fact]
        public void Where_WhenConditionStrEmpty_ShouldNoDataFilter()
        {
            //arrange
            var fixture = new Fixture();
            var data = fixture.CreateMany<FakeEmp>(3).ToList();
            data.Add(new FakeEmp {Id = 1, EmpNo = "Ming"});
            var keyword = string.Empty;
            var expectCount = 4;

            //act
            var result = data
                .AsQueryable()
                .Where(keyword, x => x.EmpNo.Equals(keyword, StringComparison.OrdinalIgnoreCase));

            //Assert
            result.Count().Should().Be(expectCount);
        }
    }
}
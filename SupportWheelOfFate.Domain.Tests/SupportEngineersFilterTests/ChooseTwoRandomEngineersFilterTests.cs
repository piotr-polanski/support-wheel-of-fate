﻿using System.Linq;
using Shouldly;
using SupportWheelOfFate.Domain.Exceptions;
using SupportWheelOfFate.Domain.SupportEngineersFilters;
using SupportWheelOfFate.Domain.Tests.Builders;
using Xunit;

namespace SupportWheelOfFate.Domain.Tests.SupportEngineersFilterTests
{
    public class ChooseTwoRandomEngineersFilterTests
    {
        [Fact]
        public void Filter_Given_MoreThanOneEngineer_Returns_TwoRandomEngineers()
        {
            //arrange
            var engineers = new SupportEngineerMocksBuilder()
                .WithEngineersWhoDidntHadShiftYesterday(2)
                .Build();
            var sut = new ChooseTwoRandomEngineersFilter();

            //act
            var chosenOnes = sut.Filter(engineers);

            //assert
            engineers.ShouldContain(chosenOnes.First());
            engineers.ShouldContain(chosenOnes.Last());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void Filter_Given_LessThanTwoEngineers_Throws_NotEnoughEngineersException(int engineersNumber)
        {
            //arrange
            var engineers = new SupportEngineerMocksBuilder()
                .WithEngineersWhoDidntHadShiftYesterday(engineersNumber)
                .Build();
            var sut = new ChooseTwoRandomEngineersFilter();

            //act and assert
            Assert.Throws<NotEnoughEngineersException>(() => sut.Filter(engineers));
        }

        [Fact]
        public void Filter_Given_null_Throws_NotEnoughEngineersException()
        {
            //arrange
            var sut = new ChooseTwoRandomEngineersFilter();

            //act and assert
            Assert.Throws<NotEnoughEngineersException>(() => sut.Filter(null));
        }

    }
}

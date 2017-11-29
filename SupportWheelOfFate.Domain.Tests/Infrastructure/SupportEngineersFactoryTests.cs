﻿using System.Linq;
using FakeItEasy;
using Ploeh.AutoFixture;
using Shouldly;
using SupportWheelOfFate.Domain.Abstract;
using SupportWheelOfFate.Domain.Infrastructure;
using SupportWheelOfFate.Domain.Repository;
using Xunit;

namespace SupportWheelOfFate.Domain.Tests.Infrastructure
{
    public class SupportEngineersFactoryTests
    {
        [Fact]
        public void CreateSupportEngineers_Give_SupportEngineerDtos_Return_SupportEngineers()
        {
            //arrange
            var fixture = new Fixture();
            var supportEngineerDto = fixture.CreateMany<SupportEngineerDto>();

            var sut = new SupportEngineersFactory(null, null);

            //act
            var supportEngineers = sut.CreteSupportEngineers(supportEngineerDto);

            //assert
            supportEngineers.Count().ShouldBe(supportEngineerDto.Count());
        }
    }
}

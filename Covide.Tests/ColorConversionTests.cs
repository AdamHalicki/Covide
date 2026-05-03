using Covide.Application.Interfaces;
using Covide.Tests.Fakes;
using FluentAssertions;
using System;
using Xunit;

public class ColorConversionTests
{
    private readonly IColorConversionService _service;

    public ColorConversionTests()
    {
        _service = new ColorConversionService(
            new FakeColorRepository(),
            new FakeHslConverter(),
            new FakeHsvConverter(),
            new FakeXyzConverter(),
            new FakeCmykConverter()
        );
    }

    [Fact]
    public void Convert_8e35ef_ShouldReturnExpectedResult()
    {
        var result = _service.Convert("8e35ef");

        result.HexTriplet.Should().Be("8e35ef");
        result.Name.Should().Be("Purple");

        result.RgbDecimal.Should().BeEquivalentTo(new[] { 142, 53, 239 });
        result.RgbPercentage.Should().BeEquivalentTo(new[] { 55.7, 20.8, 93.7 });
        result.Cmyk.Should().BeEquivalentTo(new[] { 41, 78, 0, 6 });
        result.Hsl.Should().BeEquivalentTo(new[] { 269, 85.3, 57.3 });
        result.Hsv.Should().BeEquivalentTo(new[] { 269, 77.8, 93.7 });
        result.Xyz.Should().BeEquivalentTo(new[] { 28.008, 14.529, 82.99 });
    }

    [Theory]
    [InlineData("8E35E")]
    [InlineData("8E35EF1")]
    [InlineData("#8E35EF")]
    public void Convert_InvalidHex_ShouldThrowOrFail(string hex)
    {
        Action act = () => _service.Convert(hex);

        act.Should().Throw<ArgumentException>()
            .WithMessage("*Invalid HEX*");
    }
}
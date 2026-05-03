using Covide.Application.Converters;
using Covide.Application.Interfaces;
using Covide.Domain.Entities;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

public class ColorConversionService : IColorConversionService
{
    private static readonly Regex _hexRegex = new Regex("^[0-9a-fA-F]{6}$", RegexOptions.Compiled);
    private readonly IColorRepository _repository;
    private readonly IHslConverter _hsl;
    private readonly IHsvConverter _hsv;
    private readonly IXyzConverter _xyz;
    private readonly ICmykConverter _cmyk;

    public ColorConversionService(
        IColorRepository repository,
        IHslConverter hsl,
        IHsvConverter hsv,
        IXyzConverter xyz,
        ICmykConverter cmyk)
    {
        _repository = repository;
        _hsl = hsl;
        _hsv = hsv;
        _xyz = xyz;
        _cmyk = cmyk;
    }

    public bool IsValidHex(string hex)
    {
        if (string.IsNullOrWhiteSpace(hex))
            return false;

        return _hexRegex.IsMatch(hex);
    }

    public ColorResult Convert(string hex)
    {
        if (!IsValidHex(hex))
            throw new ArgumentException("Invalid HEX format");

        int r = int.Parse(hex.Substring(0, 2), NumberStyles.AllowHexSpecifier);
        int g = int.Parse(hex.Substring(2, 2), NumberStyles.AllowHexSpecifier);
        int b = int.Parse(hex.Substring(4, 2), NumberStyles.AllowHexSpecifier);

        double rn = r / 255.0;
        double gn = g / 255.0;
        double bn = b / 255.0;

        var rgbPercentage = ColorPercentageConverter.FromRgb(r, g, b);

        return new ColorResult
        {
            HexTriplet = hex.ToLower(),
            Name = _repository.GetColorName(hex),
            RgbDecimal = new[] { r, g, b },
            RgbPercentage= rgbPercentage,
            Hsl = _hsl.Convert(rn, gn, bn),
            Hsv = _hsv.Convert(rn, gn, bn),
            Xyz = _xyz.Convert(rn, gn, bn),
            Cmyk = _cmyk.Convert(rn, gn, bn)
        };
    }
}
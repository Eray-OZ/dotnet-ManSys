using api.DTOs;
using api.Models;

namespace api.Mappers;

public static class CoverageMapper
{
    public static Coverage ToCoverageFromCoverageDto(this CoverageDto coverageDto)
    {
        return new Coverage
        {
            Code = coverageDto.Code,
            Name = coverageDto.Name,
            Limit = coverageDto.Limit
        };
    }
}


using AutoMapper;
using AutoMapper.QueryableExtensions;
using HexPersonalSoft.Application.Common.Interfaces;
using HexPersonalSoft.Application.Common.Mappings;
using HexPersonalSoft.Application.Common.Models;
using MediatR;

namespace HexPersonalSoft.Application.Polizas.Queries.GetPolizaWhitPagination;

public record GetPolizPlacaPolizaWithPaginationQuery : IRequest<PaginatedList<PolizaListDto>>
{
    public required string Polizaa { get; init; }
    public required string Placa { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}
public class GetPolizaPlacaPolizaWithPaginationQueryHandler : IRequestHandler<GetPolizPlacaPolizaWithPaginationQuery, PaginatedList<PolizaListDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPolizaPlacaPolizaWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<PolizaListDto>> Handle(GetPolizPlacaPolizaWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Polizas
            .Where(x => x.Placa == request.Placa)
            .OrderBy(x => x.Polizaa)
            .ProjectTo<PolizaListDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}


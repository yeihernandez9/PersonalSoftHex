using AutoMapper;
using AutoMapper.QueryableExtensions;
using HexPersonalSoft.Application.Common.Interfaces;
using HexPersonalSoft.Application.Common.Mappings;
using HexPersonalSoft.Application.Common.Models;
using MediatR;

namespace HexPersonalSoft.Application.Polizas.Queries.GetPolizaWhitPagination;

public record GetPolizaWithPaginationQuery : IRequest<PaginatedList<PolizaListDto>>
{
    public int ListId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetPolizaWithPaginationQueryHandler : IRequestHandler<GetPolizaWithPaginationQuery, PaginatedList<PolizaListDto>>{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPolizaWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<PolizaListDto>> Handle(GetPolizaWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Polizas
            .Where(x => x.ListId == request.ListId)
            .OrderBy(x => x.Polizaa)
            .ProjectTo<PolizaListDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}


using MediatR;

namespace GymMamagerApplication.Tickets.Queries.GetTicketById;

public class GetTicketBuIdQueryHandler : IRequestHandler<GetTicketByIdQuery, TicketDto>
{
    public async Task<TicketDto> Handle(GetTicketByIdQuery request, CancellationToken cancellationToken)
    {
        var id = request.Id;
        //pobieraniedanych z bazy danych

        return new TicketDto { Id = request.Id, Name = "Name" };
    }
}

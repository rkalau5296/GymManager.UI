using MediatR;

namespace GymMamagerApplication.Tickets.Queries.GetTicketById
{
    public class GetTicketByIdQuery : IRequest<TicketDto>
    {
        public int Id { get; set; }
    }
}

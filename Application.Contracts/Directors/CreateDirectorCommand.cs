using MediatR;

namespace Application.Contracts.Directors
{
    public class CreateDirectorCommand : IRequest
    {
        public string Name { get; set; }
        public int Rating { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgrnClient.Dto;
public class ConfirmationStatusRequestDto : IRequest
{
    public Guid[] ResponseIds { get; set; } = Array.Empty<Guid>();
}
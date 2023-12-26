using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgrnClient.Dto;
public class PackageRequestDto : IRequest
{
    public Guid PackageId { get; set; } = default;
}

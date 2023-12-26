using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgrnClient.Dto;
public class StatusGetRequestDto
{
    public Guid?[] PackageIds { get; set; } = Array.Empty<Guid?>();
}